using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Desktop.Win.Model {

	public class WallpaperImage {

		[Key]
		[DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public long WallpaperImageID { get; set; }

		[StringLength( 260 )]
		public string URLAddress { get; set; }

		[StringLength( 260 )]
		public string Filename { get; set; }

		[StringLength( 100 )]
		public string Category { get; set; }

		[StringLength( 35 )]
		public string Size { get; set; }

		public long Views { get; set; }
		
		public int Height { get; set; }

		public int Width { get; set; }	

		public bool Enabled { get; set; }

		public WallpaperImage ()
			: base() {
			this.WallpaperImageTags = new HashSet<WallpaperImageTag>();
			this.WallpaperImageColors = new HashSet<WallpaperImageColor>();
		}

		public virtual ICollection<WallpaperImageTag> WallpaperImageTags { get; set; }
		public virtual ICollection<WallpaperImageColor> WallpaperImageColors { get; set; }

	}

}