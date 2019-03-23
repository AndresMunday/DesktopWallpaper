using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AM.Desktop.Win.Tool {

	public enum StyleDesktop : int {
		Fill,
		Fit,
		Span,
		Stretch,
		Tile,
		Center
	}

	public class WallpaperTool : IDisposable {

		internal class Wallpaper {
			internal string Fullname { get; set; }
			internal bool Revisted { get; set; } = false;
			internal double Ratio { get; set; }
		}

		private const int MAX_PATH = 260;

		private const int SPI_GETDESKWALLPAPER = 0x73;
		private const int SPI_SETDESKWALLPAPER = 0x14;

		private const int SPIF_UPDATEINIFILE = 0x01;
		private const int SPIF_SENDWININICHANGE = 0x02;

		private const string SD_WALLPAPERSTYLE = @"WallpaperStyle";
		private const string SD_WALLPAPERTILE = @"TileWallpaper";

		[DllImport( "user32.dll", CharSet = CharSet.Auto )]
		private static extern int SystemParametersInfo ( int uAction, int uParam, string lpvParam, int fuWinIni );

		internal StyleDesktop StyleDesktop { get; private set; }
		internal string WallpaperLast { get; private set; }
		internal IEnumerable<Wallpaper> WallpaperAllFiles { get; private set; }
		internal IEnumerable<DirectoryInfo> Roots { get; private set; } = new DirectoryInfo[0];
		internal Wallpaper Next { get; private set; } = null;

		internal bool IsAssignedFiles {
			get {
				return this.WallpaperAllFiles != null && this.WallpaperAllFiles.Count() > 0;
			}
		}

		internal WallpaperTool ()
			: base() {
		}

		public void Dispose () {

		}

		public string GetDesktopWallpaper () {
			var wallpaper = new String( '\0', MAX_PATH );

			SystemParametersInfo( SPI_GETDESKWALLPAPER, (int) wallpaper.Length, wallpaper, 0 );

			return wallpaper.Substring( 0, wallpaper.IndexOf( '\0' ) );
		}
		private void SetDesktopWallpaper ( string filename ) {
			SystemParametersInfo(
				SPI_SETDESKWALLPAPER,
				0,
				filename,
				SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE );
		}
		private void SetStyleDesktop ( StyleDesktop wallpaperStyle ) {
			if ( this.StyleDesktop != wallpaperStyle ) {
				this.StyleDesktop = wallpaperStyle;

				RegistryKey key = Registry.CurrentUser.OpenSubKey( @"Control Panel\Desktop", true );

				switch ( ( wallpaperStyle ) ) {
					case StyleDesktop.Fill:
						key.SetValue( SD_WALLPAPERSTYLE, 10.ToString() );
						key.SetValue( SD_WALLPAPERTILE, 0.ToString() );
						break;
					case StyleDesktop.Fit:
						key.SetValue( SD_WALLPAPERSTYLE, 6.ToString() );
						key.SetValue( SD_WALLPAPERTILE, 0.ToString() );
						break;
					case StyleDesktop.Span:
						key.SetValue( SD_WALLPAPERSTYLE, 22.ToString() );
						key.SetValue( SD_WALLPAPERTILE, 0.ToString() );
						break;
					case StyleDesktop.Tile:
						key.SetValue( SD_WALLPAPERSTYLE, 0.ToString() );
						key.SetValue( SD_WALLPAPERTILE, 1.ToString() );
						break;
					case StyleDesktop.Center:
						key.SetValue( SD_WALLPAPERSTYLE, 0.ToString() );
						key.SetValue( SD_WALLPAPERTILE, 0.ToString() );
						break;
					case StyleDesktop.Stretch:
					default:
						key.SetValue( SD_WALLPAPERSTYLE, 2.ToString() );
						key.SetValue( SD_WALLPAPERTILE, 0.ToString() );
						break;
				}
			}
		}

		//internal void SetLast() {
		//	this.WallpaperLast = GetDesktopWallpaper();
		//}

		//private void SetRoots ( IEnumerable<DirectoryInfo> roots ) {
		//	this.Roots = roots;
		//}
		private bool IsRootChanges ( IEnumerable<DirectoryInfo> roots ) {
			var rest =
				from r in roots.DefaultIfEmpty()
				from q in this.Roots.DefaultIfEmpty()
				where ( r != null && q != null && r.FullName == q.FullName )
					|| ( r != null && q == null )
					|| ( r == null && q != null )
				where r == null || q == null
				select new { In = r, Out = q };

			return rest.Count() > 0;
		}
		private void RefreshImagesFromDisk ( bool seekAllDirectories ) {
			this.WallpaperAllFiles =
					this.Roots
						.SelectMany( r => r.GetFiles( "*.jpg", !seekAllDirectories ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories ) )
						.Distinct()
						.Select( q => new Wallpaper { Fullname = q.FullName } );
		}
		internal void RemoveWallpaper ( string filename ) {
			this.WallpaperAllFiles =
					from w in this.WallpaperAllFiles
					where w.Fullname != filename
					select w;
		}
		internal void SetWallpaper ( StyleDesktop styleDesktop, string filename ) {
			this.WallpaperLast = GetDesktopWallpaper();

			SetStyleDesktop( styleDesktop );
			SetDesktopWallpaper( filename );
		}
		private Wallpaper GetNextWallpaper ( StyleDesktop styleDesktop, double minRatio ) {
			var rndSeed = new Random( DateTime.UtcNow.Millisecond );

			Random seek;
			Wallpaper[] fileNotRevisted;
			Wallpaper current = new Wallpaper();
			bool wasAllRevisted = false;

			do {
				seek = new Random( rndSeed.Next( Int32.MaxValue ) );
				fileNotRevisted = (
						from w in this.WallpaperAllFiles
						where !w.Revisted
						select w ).ToArray();

				if ( !( wasAllRevisted = fileNotRevisted.Count() <= 0 ) ) {
					current = fileNotRevisted[seek.Next( fileNotRevisted.Count() )];
					current.Revisted = true;

					using ( var img = Image.FromFile( current.Fullname ) ) {
						current.Ratio = (double) img.Width / img.Height;
					}

					if ( current.Ratio < 1 ) {

					}
				}
			} while ( !wasAllRevisted && current.Ratio < minRatio );

			if ( !wasAllRevisted && !String.IsNullOrWhiteSpace( current.Fullname ) ) {
				return current;

			} else if ( wasAllRevisted && (
											from w in this.WallpaperAllFiles
											where w.Revisted && w.Ratio >= minRatio
											select w ).Count() > 0 ) {

				foreach ( var w in this.WallpaperAllFiles ) { w.Revisted = false; }

				return GetNextWallpaper( styleDesktop, minRatio );
			}

			return null;
		}
		private bool ChangeWallpaper ( StyleDesktop styleDesktop, double minRatio ) {
			if ( this.WallpaperAllFiles.Count() > 0 ) {
				if ( this.Next == null ) {
					SetWallpaper( styleDesktop, GetNextWallpaper( styleDesktop, minRatio ).Fullname );
				} else {
					SetWallpaper( styleDesktop, this.Next.Fullname );	
				}

				this.Next = GetNextWallpaper( StyleDesktop, minRatio );

				////var rndSeed = new Random( DateTime.UtcNow.Millisecond );

				////Random seek;
				////Wallpaper[] fileNotRevisted;
				////Wallpaper current = new Wallpaper();
				////bool wasAllRevisted = false;

				////do {
				////	seek = new Random( rndSeed.Next( Int32.MaxValue ) );
				////	fileNotRevisted = (
				////			from w in this.WallpaperAllFiles
				////			where !w.Revisted
				////			select w ).ToArray();

				////	if ( !( wasAllRevisted = fileNotRevisted.Count() <= 0 ) ) {
				////		current = fileNotRevisted[seek.Next( fileNotRevisted.Count() )];
				////		current.Revisted = true;

				////		using ( var img = Image.FromFile( current.Fullname ) ) {
				////			current.Ratio = (double) img.Width / img.Height;
				////		}

				////		if ( current.Ratio < 1 ) {

				////		}
				////	}
				////} while ( !wasAllRevisted && current.Ratio < minRatio );

				////if ( !wasAllRevisted && !String.IsNullOrWhiteSpace( current.Fullname ) ) {
				////	SetWallpaper( styleDesktop, current.Fullname );

				////} else if ( wasAllRevisted && (
				////								from w in this.WallpaperAllFiles
				////								where w.Revisted && w.Ratio >= minRatio
				////								select w ).Count() > 0 ) {

				////	foreach ( var w in this.WallpaperAllFiles ) { w.Revisted = false; }

				////	return ChangeWallpaper( styleDesktop, minRatio );
				////}

				return true;

			} else {
				return false;
			}
		}

		internal bool ChangeWallpaper ( IEnumerable<DirectoryInfo> dirRoots, bool allDirectories,
										StyleDesktop styleDesktop, double minRatio ) {

			if ( dirRoots.Count() > 0 ) {
				bool isRootChanged = false;

				if ( isRootChanged = this.IsRootChanges( dirRoots ) ) {
					this.Roots = dirRoots;
				}

				if ( isRootChanged || !this.IsAssignedFiles ) {
					this.RefreshImagesFromDisk( allDirectories );
				}

				return this.ChangeWallpaper( styleDesktop, minRatio );

			} else {
				return false;
			}
		}

	}

}
