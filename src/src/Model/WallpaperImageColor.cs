using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Desktop.Win.Model {

	public class WallpaperImageColor {


		[Key]
		[Column( Order = 0 )]
		public long WallpaperImageID { get; set; }

		[Key]
		[Column( Order = 1 )]
		public long ColorIndexID { get; set; }

		public bool Enabled { get; set; }

		public WallpaperImageColor () 
			: base() {
		}

		public virtual WallpaperImage WallpaperImage { get; set; }
		public virtual ColorIndex ColorIndex { get; set; }

	}

}
