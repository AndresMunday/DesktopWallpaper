using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Desktop.Win.Model {

	public class WallpaperImageTag {

		[Key]
		[Column( Order = 0 )]
		public long WallpaperImageID { get; set; }

		[Key]
		[Column( Order = 1 )]
		public long TagIndexID { get; set; }

		public bool Enabled { get; set; }

		public WallpaperImageTag ()
			: base() {
		}

		public virtual WallpaperImage WallpaperImage { get; set; }
		public virtual TagIndex TagIndex { get; set; }

	}

}
