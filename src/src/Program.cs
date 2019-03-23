using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AM.Desktop.Win {

	public static class Program {

		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		public static void Main () {
			try {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault( false );
				Application.Run( new frmDesktop() );

			} catch ( Exception exp ) {
				File.WriteAllLines(
					Application.StartupPath + @"\errors-app.txt",
					new string[] { 
						"Source: " + exp.Source,
						"Message: " + exp.Message,
						"Method Name: " + exp.TargetSite.Name,
						"StackTrace:" + exp.StackTrace
					} );
			}
		}

	}

}
