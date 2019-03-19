using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Desktop.Win.Model {

	public class ColorIndex {

		[Key]
		[DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public long ColorIndexID { get; set; }

		public string ColorNumber { get; set; }

		public bool Enabled { get; set; }

		public ColorIndex ()
			: base() {
			this.WallpaperImageColors = new HashSet<WallpaperImageColor>();
		}

		public virtual ICollection<WallpaperImageColor> WallpaperImageColors { get; set; }

	}

}