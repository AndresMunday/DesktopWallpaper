using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Desktop.Win.Model {

	public class TagIndex {

		[Key]
		[DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public long TagIndexID { get; set; }

		public int OriginId { get; set; }

		public string Text { get; set; }

		public bool Enabled { get; set; }

		public TagIndex ()
			: base() {
			this.WallpaperImageTags = new HashSet<WallpaperImageTag>();
		}

		public virtual ICollection<WallpaperImageTag> WallpaperImageTags { get; set; }

	}
}