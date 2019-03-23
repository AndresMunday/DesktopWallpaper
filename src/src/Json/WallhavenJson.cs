using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Desktop.Win.Json {


	internal class WallhavenTag {

		[JsonProperty( "id" )]
		internal int Id { get; set; }

		[JsonProperty( "text" )]
		internal string Text { get; set; }
	}

	internal class WallhavenDetail {

		[JsonProperty( "fullImage" )]
		internal string FullImage { get; set; }

		[JsonProperty( "tags" )]
		internal ICollection<WallhavenTag> Tags { get; set; }

		[JsonProperty( "category" )]
		internal string Category { get; set; }

		[JsonProperty( "size" )]
		internal string Size { get; set; }

		[JsonProperty( "views" )]
		internal long Views { get; set; }

		[JsonProperty( "width" )]
		internal int Width { get; set; }

		[JsonProperty( "height" )]
		internal int Height { get; set; }

		[JsonProperty( "colors" )]
		internal ICollection<string> Colors { get; set; }
	}


}
