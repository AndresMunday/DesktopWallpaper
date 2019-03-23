using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AM.Desktop.Win.Tool {

	public class ShellManager {

		/// <summary>
		/// Possible flags for the SHFileOperation method.
		/// </summary>
		[Flags]
		public enum FileOperationFlags : ushort {
			/// <summary>
			/// Do not show a dialog during the process
			/// </summary>
			FOF_SILENT = 0x0004,
			/// <summary>
			/// Do not ask the user to confirm selection
			/// </summary>
			FOF_NOCONFIRMATION = 0x0010,
			/// <summary>
			/// Delete the file to the recycle bin.  (Required flag to send a file to the bin
			/// </summary>
			FOF_ALLOWUNDO = 0x0040,
			/// <summary>
			/// Do not show the names of the files or folders that are being recycled.
			/// </summary>
			FOF_SIMPLEPROGRESS = 0x0100,
			/// <summary>
			/// Surpress errors, if any occur during the process.
			/// </summary>
			FOF_NOERRORUI = 0x0400,
			/// <summary>
			/// Warn if files are too big to fit in the recycle bin and will need
			/// to be deleted completely.
			/// </summary>
			FOF_WANTNUKEWARNING = 0x4000,
		}

		/// <summary>
		/// File Operation Function Type for SHFileOperation
		/// </summary>
		public enum FileOperationType : uint {
			/// <summary>
			/// Move the objects
			/// </summary>
			FO_MOVE = 0x0001,
			/// <summary>
			/// Copy the objects
			/// </summary>
			FO_COPY = 0x0002,
			/// <summary>
			/// Delete (or recycle) the objects
			/// </summary>
			FO_DELETE = 0x0003,
			/// <summary>
			/// Rename the object(s)
			/// </summary>
			FO_RENAME = 0x0004,
		}

		/// <summary>
		/// SHFILEOPSTRUCT for SHFileOperation from COM
		/// </summary>
		[StructLayout( LayoutKind.Sequential, CharSet = CharSet.Auto )]
		private struct SHFILEOPSTRUCT {
			public IntPtr hwnd;

			[MarshalAs( UnmanagedType.U4 )]
			public FileOperationType wFunc;

			public string pFrom;
			public string pTo;
			public FileOperationFlags fFlags;

			[MarshalAs( UnmanagedType.Bool )]
			public bool fAnyOperationsAborted;

			public IntPtr hNameMappings;
			public string lpszProgressTitle;
		}

		[DllImport( "shell32.dll", CharSet = CharSet.Auto )]
		private static extern int SHFileOperation ( ref SHFILEOPSTRUCT FileOp );

		private List<string> FileToDelete { get; set; }
		internal bool IsNowDeleting { get; private set; } = false;

		internal bool ExistFileToDelete {
			get {
				return this.FileToDelete != null && this.FileToDelete.Count() > 0;
			}
		}
		internal bool ExistErrors {
			get {
				return this.Errors.Nodes().Count() > 0;
			}
		}

		private XElement Errors { get; set; } = new XElement( "errors" );

		public ShellManager ()
			: base() {
			FileInfo fi;
			if ( ( fi = new FileInfo ( Application.StartupPath + @"\" + "errors.xml" ) ).Exists ) {
				try {
					fi.CopyTo( Application.StartupPath + @"\" + "errors_" + fi.CreationTime.ToString( @"yyy/mm/dd" ) + ".xml" );
					fi.Delete();
				} catch ( Exception exp ) {
					this.Errors.Add( exp );
				}
			}
		}

		/// <summary>
		/// Send file to recycle bin
		/// </summary>
		/// <param name="path">Location of directory or file to recycle</param>
		/// <param name="flags">FileOperationFlags to add in addition to FOF_ALLOWUNDO</param>
		private bool Send ( string path, FileOperationFlags flags ) {
			try {
				var fs = new SHFILEOPSTRUCT {
					wFunc = FileOperationType.FO_DELETE,
					pFrom = path + '\0' + '\0',
					fFlags = FileOperationFlags.FOF_ALLOWUNDO | flags
				};

				var response = SHFileOperation( ref fs );

				return response == 0;       // response == 0 it's Ok process!

			} catch ( Exception ) {
				return false;
			}
		}

		/// <summary>
		/// Send file to recycle bin.  Display dialog, display warning if files are too big to fit (FOF_WANTNUKEWARNING)
		/// </summary>
		/// <param name="path">Location of directory or file to recycle</param>
		private bool Send ( string path ) {
			return Send( path, FileOperationFlags.FOF_NOCONFIRMATION | FileOperationFlags.FOF_WANTNUKEWARNING );
		}

		/// <summary>
		/// Send file silently to recycle bin.  Surpress dialog, surpress errors, delete if too large.
		/// </summary>
		/// <param name="path">Location of directory or file to recycle</param>
		internal bool MoveToRecycleBin ( string path ) {
			return Send( path, FileOperationFlags.FOF_NOCONFIRMATION | FileOperationFlags.FOF_NOERRORUI | FileOperationFlags.FOF_SILENT );
		}

		internal void DeleteFiles () {
			if ( !this.IsNowDeleting ) {
				this.IsNowDeleting = true;

				var toDeletes = this.FileToDelete.ToArray();
				for ( int indx = 0, len = toDeletes.Length ; indx < len ; indx++ ) {
					var fil = toDeletes[indx];

					if ( MoveToRecycleBin( fil ) ) {
						this.FileToDelete = (
								from f in this.FileToDelete
								where f != fil
								select f ).ToList();
					}
				}

				this.IsNowDeleting = false;
			}
		}

		internal void AddToDelete ( string path ) {
			if ( this.FileToDelete == null ) {
				this.FileToDelete = new List<string>();
			}

			if ( this.FileToDelete.Where( f => f == path ).Count() == 0 ) {
				this.FileToDelete.Add( path );
			}
		}

		internal string AddErrors ( Exception exp ) {
			var module = exp.TargetSite != null && exp.TargetSite.Module != null ? exp.TargetSite.Module.FullyQualifiedName : "NoModule";
			var method = exp.TargetSite != null ? exp.TargetSite.Name : "NoMethodName";

			var current = new XElement(
				"error",
				new XElement( "exception", exp.GetType().FullName ),
				new XElement( "message", exp.Message ),
				new XElement( "source", exp.Source ),
				new XElement( "module", module ),
				new XElement( "method", method ),
				new XElement( "innerException", AddErrors( exp.InnerException ) ),
				new XElement( "data", ( (Dictionary<string, object>) exp.Data.Values ).Select( v => new XElement( v.Key, v.Value.ToString() ) ).ToArray() ),
				new XElement( "stack", exp.StackTrace )
			);

			this.Errors.Add( current );

			return current.ToString();
		}
		internal void SaveErrors () {
			if ( this.ExistErrors ) {
				XElement xmlRoot;

				string filename = Application.CommonAppDataPath + @"\" + "errors.xml";
				FileInfo fi;
				if ( ( fi = new FileInfo( filename ) ).Exists ) {
					xmlRoot = XElement.Load( fi.FullName );
					//xmlRoot.FirstNode.Add( this.Errors.Nodes );

				} else {
					xmlRoot = this.Errors;
				}

				xmlRoot.Save( filename );
			}

		}

	}

}
