namespace AM.Desktop.Win.Model {
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Data.Entity.ModelConfiguration.Conventions;
	using AM.Desktop.Win.Json;
	using AM.Desktop.Win.Enumeration;

	public partial class dbImagesModel : DbContext {

		public DbSet<SourceAddress> SourceAddresses { get; set; }
		public DbSet<WallpaperImage> WallpaperImages { get; set; }
		public DbSet<ColorIndex> ColorIndexes { get; set; }
		public DbSet<TagIndex> TagIndexes { get; set; }
		public DbSet<WallpaperImageTag> WallpaperImageTags { get; set; }
		public DbSet<WallpaperImageColor> WallpaperImageColors { get; set; }

		public dbImagesModel ()
			: base( "name=dbModel" ) {
		}

		protected override void OnModelCreating ( DbModelBuilder modelBuilder ) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder
				.Entity<WallpaperImageColor>()
				.HasRequired( wic => wic.WallpaperImage )
				.WithMany( wi => wi.WallpaperImageColors )
				.HasForeignKey( wic => wic.WallpaperImageID )
				.WillCascadeOnDelete( false );

			modelBuilder
				.Entity<WallpaperImageColor>()
				.HasRequired( wic => wic.ColorIndex )
				.WithMany( c => c.WallpaperImageColors )
				.HasForeignKey( wic => wic.ColorIndexID )
				.WillCascadeOnDelete( false );

			modelBuilder
				.Entity<WallpaperImageTag>()
				.HasRequired( wit => wit.WallpaperImage )
				.WithMany( wi => wi.WallpaperImageTags )
				.HasForeignKey( wit => wit.WallpaperImageID )
				.WillCascadeOnDelete( false );

			modelBuilder
				.Entity<WallpaperImageTag>()
				.HasRequired( wit => wit.TagIndex )
				.WithMany( t => t.WallpaperImageTags )
				.HasForeignKey( wit => wit.TagIndexID )
				.WillCascadeOnDelete( false );

			base.OnModelCreating( modelBuilder );
		}

		internal void AddImage ( WallhavenDetail detail, string filename ) {
			var colors = this.ColorIndexes.AddRange(
				from c in detail.Colors
				join r in this.ColorIndexes
							on new { Color = c } equals new { Color = r.ColorNumber }
							into rgh

				from f in rgh.DefaultIfEmpty()
				where f == null
				select new ColorIndex {
					ColorNumber = c,
					Enabled = true
				}
			);

			this.SaveChangesAsync().Wait();

			var tags = this.TagIndexes.AddRange(
				from t in detail.Tags
				join r in this.TagIndexes
							on t.Text equals r.Text
							into gh

				from o in gh.DefaultIfEmpty()
				where o == null
				select new TagIndex {
					Text = t.Text,
					OriginId = t.Id,
					Enabled = true
				}
			);

			this.SaveChangesAsync().Wait();

			var img = (
				from w in this.WallpaperImages
				where w.URLAddress == detail.FullImage
				select w ).SingleOrDefault();

			if ( img == null ) {
				img = this.WallpaperImages.Add(
					new WallpaperImage {
						URLAddress = detail.FullImage,
						Filename = filename,
						Category = detail.Category,
						Height = detail.Height,
						Size = detail.Size,
						Views = detail.Views,
						Width = detail.Width,
						Enabled = true
					} );

			} else {
				img.Category = detail.Category;
				img.Filename = filename;
				img.Height = detail.Height;
				img.Size = detail.Size;
				img.Views = detail.Views;
				img.Width = detail.Width;

				img.Enabled = true;
			}

			this.SaveChangesAsync().Wait();

			var wiTags = this.WallpaperImageColors.AddRange(
				from c in detail.Colors
				join r in this.ColorIndexes
								on new { Color = c } equals new { Color = r.ColorNumber }
								into yuj

				from j in yuj.DefaultIfEmpty()
				where j != null
				join wic in this.WallpaperImageColors
								on new { j.ColorIndexID, img.WallpaperImageID } equals new { wic.ColorIndexID, wic.WallpaperImageID }
								into kop

				from p in kop.DefaultIfEmpty()
				where p == null
				select new WallpaperImageColor {
					ColorIndexID = j.ColorIndexID,
					WallpaperImageID = img.WallpaperImageID,
					Enabled = true
				}
			);

			var wiColors = this.WallpaperImageTags.AddRange(
				from t in detail.Tags
				join w in this.TagIndexes
								on t.Text equals w.Text
								into hju

				from k in hju.DefaultIfEmpty()
				where k != null
				join wit in this.WallpaperImageTags
								on new { k.TagIndexID, img.WallpaperImageID } equals new { wit.TagIndexID, wit.WallpaperImageID }
								into klo

				from r in klo.DefaultIfEmpty()
				where r == null
				select new WallpaperImageTag {
					TagIndexID = k.TagIndexID,
					WallpaperImageID = img.WallpaperImageID,
					Enabled = true
				}
			);

			this.SaveChangesAsync().Wait();
		}
		internal void AddAddressSource ( TypeSourceEnum typeSource, string address ) {
			var existing = (
				from adr in this.SourceAddresses
				where adr.TypeSource == typeSource
					&& adr.Address == address
				select adr ).SingleOrDefault();

			if ( existing == null ) {
				existing = this.SourceAddresses.Add(
					new SourceAddress {
						TypeSource = typeSource,
						Address = address,
						Enabled = true
					}
				);

				this.SaveChangesAsync().Wait();
			}
		}

	}

}
