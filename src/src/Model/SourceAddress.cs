using AM.Desktop.Win.Enumeration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Desktop.Win.Model {

	public class SourceAddress {

		[Key]
		[DatabaseGenerated( DatabaseGeneratedOption.Identity )]
		public int SourceAddressID { get; set; }

		public TypeSourceEnum TypeSource { get; set; }

		[StringLength( 260 )]
		public string Address { get; set; }

		public bool Enabled { get; set; }

		public SourceAddress ()
			: base() {
		}

	}

}
