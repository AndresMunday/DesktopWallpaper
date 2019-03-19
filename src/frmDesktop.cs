using AM.Desktop.Win.Enumeration;
using AM.Desktop.Win.Json;
using AM.Desktop.Win.Model;
using AM.Desktop.Win.Tool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AM.Desktop.Win {

	public partial class frmDesktop : Form {
		private const string ___userAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36 OPR/54.0.2952.64";

		internal enum ScrollDirectionEnum : int {
			Decrement = -1,
			Increment = 1
		}
		internal enum SortingEnum : int {
			No_Assign = 0,
			Relevance = 1,
			Random,
			Date_Added,
			Views,
			Favorites
		}
		internal enum LapsusEnum : int {
			Seconds,
			Minutes,
			Hours,
			Days,
			Weeks,
			Months
		}

		internal class WatchTimming {

			public TimeSpan HttpTime { get; set; } = new TimeSpan();

			public WatchTimming ()
				: base() {
			}

			public void Clear () {
				this.HttpTime = new TimeSpan();
			}

			public TimeSpan AddHttp ( DateTime begin ) {
				return this.AddHttp( DateTime.UtcNow - begin );
			}
			public TimeSpan AddHttp ( TimeSpan adding ) {
				this.HttpTime += adding;

				return this.HttpTime;
			}

		}
		internal class DropDownListItem {
			public string Text { get; set; }
			public int Value { get; set; }
			public Enum Origin { get; set; }

		}
		internal class MemSource {

			internal string Address { get; set; }
			internal int Index { get; set; } = 0;
			internal bool Ended { get; set; } = false;
			internal TypeSourceEnum TypeSource { get; set; }

			public override string ToString () {
				return
					String.Format(
						"[{0}] {1}",
						this.TypeSource.ToString(),
						this.Address
					);
			}

		}
		internal class MemPicture {
			internal long Id { get; set; }
			internal string KeyWord { get; set; }
			internal int Width { get; set; }
			internal int Height { get; set; }
			internal string Thumb { get; set; }
			internal TypeSourceEnum TypeSource { get; set; }
			internal WallhavenDetail Detail { get; set; }

			internal string DiskPath { get; set; }
			internal string DiskFilename { get; set; }

			internal string DiskFullFilename {
				get {
					return Path.Combine( this.DiskPath, this.DiskFilename );
				}
			}

			public bool IsFilenameValid {
				get {
					return !String.IsNullOrWhiteSpace( this.DiskPath ) && !String.IsNullOrWhiteSpace( this.DiskFilename );
				}
			}

			public MemPicture ()
				: base() {
			}

		}

		internal class WallhavenThumb {

			[JsonProperty( "id" )]
			internal long Id { get; set; }

			[JsonProperty( "width" )]
			internal int Width { get; set; }

			[JsonProperty( "height" )]
			internal int Height { get; set; }

			[JsonProperty( "thumb" )]
			internal string Thumb { get; set; }

		}
		internal class WallhavenSearch {

			[JsonProperty( "end" )]
			internal bool End { get; set; }

			[JsonProperty( "totalPages" )]
			internal int TotalPages { get; set; }

			[JsonProperty( "images" )]
			internal WallhavenThumb[] Images { get; set; }

		}

		private long __optionCounter = 0;

		private int ErrorCounter { get; set; } = 0;
		private bool WorkingSet { get; set; } = false;
		private DateTime NextWallpaperChange { get; set; }

		private WallpaperTool Wall { get; set; } = new WallpaperTool();
		private WatchTimming Watch { get; set; } = new WatchTimming();
		private CancellationTokenSource CancelToken { get; set; }
		private ShellManager Shell { get; set; } = new ShellManager();
		

		private ScrollDirectionEnum ScrollDirection { get; set; } = ScrollDirectionEnum.Increment;
		//private ICollection<MemSource> ControlViewer { get; set; }

		public frmDesktop () {
			InitializeComponent();

			tspbProgress.Visible = false;
			ActivateViewerWallpaperView( false );

			#region Adding ComboBox data enumerations

			ddSorting.DisplayMember = "Text";
			ddSorting.ValueMember = "Value";
			ddSorting.Items.AddRange(
				Enum
					.GetValues( typeof( SortingEnum ) )
					.Cast<SortingEnum>()
					.Select( se => new DropDownListItem {
						Text = se.ToString().Replace( '_', ' ' ),
						Value = (int) se,
						Origin = se
					} ).ToArray()
			);

			ddLapsus.DisplayMember = "Text";
			ddLapsus.ValueMember = "Value";
			ddLapsus.Items.AddRange(
				Enum
					.GetValues( typeof( LapsusEnum ) )
					.Cast<LapsusEnum>()
					.Select( le => new DropDownListItem {
						Text = le.ToString(),
						Value = (int) le,
						Origin = le
					} ).ToArray()
			);

			ddLapsus.SelectedIndex = 1;     // Minutes!

			ddStyleDesktop.DisplayMember = "Text";
			ddStyleDesktop.ValueMember = "Value";
			ddStyleDesktop.Items.AddRange(
				Enum
					.GetValues( typeof( StyleDesktop ) )
					.Cast<StyleDesktop>()
					.Select( sd => new DropDownListItem {
						Text = sd.ToString(),
						Value = (int) sd,
						Origin = sd
					} ).ToArray()
			);
			#endregion

			ddLapsus.SelectedIndex = 1;
			ddStyleDesktop.SelectedIndex = 0;

			using ( var db = new dbImages() ) {
				//lstAddresses.Items.AddRange( ( 
				clbAddresses.Items.AddRange( (
					from sa in db.SourceAddresses
					where sa.Enabled
					select new MemSource {
						Address = sa.Address,
						TypeSource = sa.TypeSource
					} ).ToArray()
				);
			}

		}

		private Image GetThumb ( string srcAddress, int width ) {
			using ( var pic = Image.FromFile( srcAddress ) ) {
				return GetThumb( pic, width );
			}
		}
		private Image GetThumb ( Image pic, int width ) {
			var ratio = (double) pic.Width / width;
			var height = (int) ( pic.Height / ratio );

			var newImage = new Bitmap( width, height );
			using ( var graph = Graphics.FromImage( newImage ) ) {
				graph.DrawImage( pic, 0, 0, width, height );
			}

			return newImage;
		}
		private string GetImagesPath ( string source, string key ) {
			return Path.Combine( Application.StartupPath, "Images", source, key );
		}
		private async Task<Stream> GetResponseStandard ( string urlAddress ) {
			DateTime begin = DateTime.UtcNow;
			Stream response = Stream.Null;

			try {
				var req = (HttpWebRequest) WebRequest.Create( urlAddress );

				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

				req.Method = "GET";
				req.UserAgent = ___userAgent;
				req.AuthenticationLevel = AuthenticationLevel.None;
				req.KeepAlive = true;
				req.AllowAutoRedirect = true;
				req.UseDefaultCredentials = false;

				response = ( await req.GetResponseAsync() ).GetResponseStream();

			} catch ( NotSupportedException nse ) {
				var ddd = 233;

			} catch ( ArgumentNullException ane ) {
				var ddd = 233;

			} catch ( SecurityException se ) {
				var ddd = 233;

			} catch ( UriFormatException ufe ) {
				var ddd = 233;

			} catch ( Exception ex ) {
				var ddd = 233;
			}

			this.Watch.AddHttp( begin );

			return response;
		}
		private async Task InsertImageToPanel ( string sAddress, TypeSourceEnum typeSource, WallhavenThumb thumb, string keyword ) {
			try {
				var columns = nudColumns.Value;
				var margin = (int) nudMargin.Value;
				var width = (int) ( ( flpPictures.DisplayRectangle.Width / columns ) - margin * ( columns - 1 ) );

				var pic = typeSource == TypeSourceEnum.Directory
										? GetThumb( sAddress, width )
										: GetThumb( Image.FromStream( await GetResponseStandard( sAddress ) ), width );

				var height = (int) ( width * (decimal) pic.Height / pic.Width ) - 2 * margin;

				if ( pic.Width > 800 || pic.Height > 600 ) {

				}

				var detail = typeSource == TypeSourceEnum.Wallhaven
									? JsonConvert.DeserializeObject<WallhavenDetail>(
											await new StreamReader(
												await GetResponseStandard(
													String.Format( "https://wallhaven-api.now.sh/details/{0}", thumb.Id )
												)
											).ReadToEndAsync()
										)
									: null;

				var tg = new MemPicture {
					TypeSource = typeSource,
					KeyWord = keyword,
					Detail = detail,
					Thumb = typeSource == TypeSourceEnum.Wallhaven ? thumb.Thumb : sAddress,
					Id = typeSource == TypeSourceEnum.Wallhaven ? thumb.Id : -1,
					Height = typeSource == TypeSourceEnum.Wallhaven ? thumb.Height : pic.Height,
					Width = typeSource == TypeSourceEnum.Wallhaven ? thumb.Width : pic.Width
				};

				if ( typeSource != TypeSourceEnum.Directory && detail != null ) {
					tg.DiskPath = GetImagesPath( "Wallhaven", keyword );
					tg.DiskFilename = tg.Detail.FullImage.Split( '/' ).Last();
				}

				var img = new PictureBox() {
					Name = "imgPic_" + Guid.NewGuid().ToString(),
					Image = pic,
					Width = width,
					Height = height,
					Dock = DockStyle.Fill,
					SizeMode = PictureBoxSizeMode.Zoom,
					Margin = new Padding( 0 )
				};
				var pPic = new Panel() {
					Name = "pPic_" + Guid.NewGuid().ToString(),
					Width = width,
					Height = height,
					Padding = new Padding( margin ),
					Margin = new Padding( 0 ),
					Tag = tg
				};

				if ( typeSource != TypeSourceEnum.Directory && tg.IsFilenameValid && File.Exists( tg.DiskFullFilename ) ) {
					img.Controls.Add( AddLabelExist( height, width ) );

				} else if ( tg.IsFilenameValid ) {
					img.DoubleClick += async delegate ( object sender, EventArgs e ) {
						var s = sender as PictureBox;
						var tag = s.Parent.Tag as MemPicture;

						if ( tag.TypeSource == TypeSourceEnum.Wallhaven ) {
							try {
								var image = Image.FromStream( await GetResponseStandard( tag.Detail.FullImage ) );

								if ( !Directory.Exists( tag.DiskPath ) ) { Directory.CreateDirectory( tag.DiskPath ); }

								image.Save( tag.DiskFullFilename, ImageFormat.Jpeg );

								using ( var db = new dbImages() ) { db.AddImage( tag.Detail, tag.DiskFullFilename ); }

								s.Controls.Add( AddLabelExist( s.Height, s.Width ) );

							} catch ( UnauthorizedAccessException uaae ) {
								var jdjdd = 32;
							} catch ( ArgumentNullException anu ) {
								var jdjdd = 32;
							} catch ( ArgumentException ae ) {
								var jdjdd = 32;
							} catch ( PathTooLongException ptle ) {
								var jdjdd = 32;
							} catch ( DirectoryNotFoundException dnfe ) {
								var jdjdd = 32;
							} catch ( IOException ioe ) {
								var jdjdd = 32;
							} catch ( NotSupportedException nse ) {
								var jdjdd = 32;
							} catch ( ExternalException ee ) {
								var jdjdd = 32;
							} catch ( Exception ex ) {
								var jdjdd = 32;
							}
						}
					};

				} else {
					if ( typeSource != TypeSourceEnum.Directory ) {
						tsslErrors.Text = String.Format( "Error: {0}", ++this.ErrorCounter );

						pPic.Visible = !cbFilterNotFound.Checked;
						img.Controls.Add(
							new Label {
								Name = "lbNotFound_" + Guid.NewGuid().ToString(),
								Top = 4,
								Left = 0,
								Width = width,
								Text = "X",
								BackColor = Color.FromArgb( 176, Color.DarkRed ),
								ForeColor = Color.White,
								Font = new Font( this.Font.FontFamily, 12, FontStyle.Bold ),
								Anchor = AnchorStyles.Top | AnchorStyles.Left
							}
						);
					}
				}

				pPic.Controls.Add( img );
				flpPictures.Controls.Add( pPic );

			} catch ( FileNotFoundException ome ) {
				var kdkdkd = 3232;
			} catch ( OutOfMemoryException ome ) {
				var kdkdkd = 3232;
			} catch ( ArgumentNullException ane ) {
				var kdkdkd = 3232;
			} catch ( ObjectDisposedException ode ) {
				var kdkdkd = 3232;
			} catch ( InvalidOperationException ioe ) {
				var kdkdkd = 3232;
			} catch ( ArgumentOutOfRangeException aore ) {
				var kdkdkd = 3232;
			} catch ( ArgumentException ane ) {
				var kdkdkd = 3232;
			}
		}
		private Label AddLabelExist ( int height, int width ) {
			return new Label {
				Name = "lbPictureName_" + Guid.NewGuid().ToString(),
				Text = "«",
				Top = height - 30,
				Left = 0,
				Height = 22,
				Width = width,
				TextAlign = ContentAlignment.MiddleCenter,
				Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
				ForeColor = Color.Red,
				BackColor = Color.FromArgb( 80, Color.Black ),
				Font = new Font( new FontFamily( "Wingdings" ), 15, FontStyle.Bold ),
				Tag = "Repos"
			};
		}
		private async Task ReviewSelectedAddress ( CancellationToken token ) {
			if ( !this.WorkingSet ) {
				this.WorkingSet = true;
				this.UseWaitCursor = true;
				this.ErrorCounter = 0;

				cbAllDirectories.Enabled = false;
				cbNSFW.Enabled = false;
				cbSketchy.Enabled = false;
				cbFilterNotFound.Enabled = false;
				cbShowDirectory.Enabled = false;
				btNextPage.Enabled = false;

				lbSorting.Enabled = false;
				ddSorting.Enabled = false;
				lbPager.Enabled = false;
				nudPaging.Enabled = false;
				//lstAddresses.Enabled = false;
				clbAddresses.Enabled = false;

				//lbParsing.Visible = true;
				tspbProgress.Visible = true;
				btCancelSeeking.Visible = true;

				tsslMessage.Text = "";
				tsslErrors.Text = "";

				//var items = lstAddresses.SelectedItems;
				var items = clbAddresses.SelectedItems;
				var em = items.Cast<MemSource>().ToArray();
				var bFinished = false;

				for ( int iPaging = 0, lenPagging = (int) nudPaging.Value ; !bFinished && !token.IsCancellationRequested && iPaging < lenPagging ; iPaging++ ) {
					foreach ( var ms in em ) {
						if ( !token.IsCancellationRequested ) {
							tspbProgress.Value = 0;

							if ( !ms.Ended && !token.IsCancellationRequested ) {
								++ms.Index;

								//lbParsing.Text = "Parsing: 00";
								lbPages.Text = String.Format( "{0:00}", ms.Index );

								if ( ms.TypeSource == TypeSourceEnum.Directory ) {
									await ShowingDirectory( ms, token );
									bFinished = true;

								} else if ( ms.TypeSource == TypeSourceEnum.Wallhaven ) {
									if ( cbShowDirectory.Checked ) {
										await ShowingDirectory( ms, token );
										bFinished = true;

									} else {
										DropDownListItem sorting = null;
										SortingEnum? sortingSelected = null;

										if ( ddSorting.SelectedIndex == -1
													|| ( sorting = ddSorting.Items[ddSorting.SelectedIndex] as DropDownListItem ) != null
															&& ( sortingSelected = (SortingEnum?) sorting.Origin ) != null ) {

											using ( var s = await GetResponseStandard(
																	String.Format( @"https://wallhaven-api.now.sh/search?keyword={0}&page={1}", ms.Address.Replace( " ", "%20" ), ms.Index )
																		+ ( sorting != null
																				&& sortingSelected != null
																				&& sortingSelected != SortingEnum.No_Assign
																							? "&sorting=" + sortingSelected.ToString().ToLower()
																							: "" )

																		+ ( cbSketchy.Checked ? "&sketchy=true" : "" )
																		+ ( cbNSFW.Checked ? "&nsfw=true" : "" ) ) ) {

												var searchData = JsonConvert
																	.DeserializeObject<WallhavenSearch>(
																		await new StreamReader( s ).ReadToEndAsync()
																	);

												tsslMessage.Text = String.Format(
																			"[Wallhavem]{2}Total Pages: {0} | Images: {1}",
																			searchData.TotalPages,
																			searchData.Images.Length,
																			searchData.End ? " [END] " : " " );

												DateTime begin = DateTime.UtcNow;
												for ( int indx = 0, len = searchData.Images.Length ; !token.IsCancellationRequested && indx < len ; indx++ ) {
													var r = searchData.Images[indx];

													//lbParsing.Text = String.Format( "Parsing: {0:00}", len - indx );
													tspbProgress.Value = (int) Math.Floor( 100 * (double) ( indx + 1 ) / len );
													tsslTimming.Text = String.Format( "| {0} | Rest Time: {1}", len - indx, GetTimeRestFormatted( DateTime.UtcNow - begin, indx + 1, len ) );

													await InsertImageToPanel( r.Thumb, ms.TypeSource, r, ms.Address );
												}

												ms.Ended = searchData.End;
											}
										}

									}
								}
							}
						}
					}
				}

				btCancelSeeking.Visible = false;
				tspbProgress.Visible = false;
				//lbParsing.Visible = false;

				//lstAddresses.Enabled = true; 
				clbAddresses.Enabled = true;
				btNextPage.Enabled = true;
				cbAllDirectories.Enabled = true;
				cbNSFW.Enabled = true;
				cbSketchy.Enabled = true;
				cbFilterNotFound.Enabled = true;
				cbShowDirectory.Enabled = true;

				lbPager.Enabled = true;
				nudPaging.Enabled = true;
				lbSorting.Enabled = true;
				ddSorting.Enabled = true;

				this.UseWaitCursor = false;
				this.WorkingSet = false;
			}
		}
		private string GetTimeRestFormatted ( TimeSpan time, int current, int maximum ) {
			var rest = new TimeSpan( (long) ( TimeSpan.TicksPerMillisecond * ( maximum - current ) * time.TotalMilliseconds / current ) );
			return GetTimeFormatted( rest, true );
		}
		private string GetTimeFormatted ( TimeSpan rest, bool withMiliseconds = false ) {
			if ( rest.TotalDays >= 1 ) {
				return rest.ToString( @"dd hh\:mm\:ss" + ( withMiliseconds ? @"\.fff" : @"" ) );
			} else if ( rest.TotalHours >= 1 ) {
				return rest.ToString( @"hh\:mm\:ss" + ( withMiliseconds ? @"\.fff" : @"" ) );
			} else if ( rest.TotalMinutes >= 1 ) {
				return rest.ToString( @"mm\:ss" + ( withMiliseconds ? @"\.fff" : @"" ) );
			} else {
				return rest.ToString( @"ss" + ( withMiliseconds ? @"\.fff" : @"" ) );
			}
		}
		private async Task ShowingDirectory ( MemSource ms, CancellationToken token ) {
			var directory = ms.TypeSource != TypeSourceEnum.Directory ? GetImagesPath( "Wallhaven", ms.Address ) : ms.Address;

			if ( Directory.Exists( directory ) ) {
				var allFiles = Directory.GetFiles( directory, "*.jpg",
									cbAllDirectories.Checked
											? SearchOption.AllDirectories
											: SearchOption.TopDirectoryOnly );

				var begin = DateTime.UtcNow;
				string fil;
				for ( int indx = 0, len = allFiles.Length ; !token.IsCancellationRequested && indx < len ; indx++ ) {
					fil = allFiles[indx];

					tspbProgress.Value = (int) Math.Floor( 100 * (double) ( indx + 1 ) / len );
					tsslTimming.Text = String.Format( "Rest Time: {0}", GetTimeRestFormatted( DateTime.UtcNow - begin, indx + 1, len ) );

					await InsertImageToPanel( fil, TypeSourceEnum.Directory, null, "" );
				}
			}
		}
		private void ResizePictures () {
			flpPictures.SuspendLayout();

			var margin = (int) nudMargin.Value;
			var minPanelWidth = flpPictures.Width > flpPictures.DisplayRectangle.Width
												? flpPictures.DisplayRectangle.Width
												: flpPictures.Width;

			var width = (int) ( ( minPanelWidth - 2 * margin ) / nudColumns.Value );

			foreach ( var c in flpPictures.Controls.OfType<Panel>() ) {
				var pic = c.Controls.OfType<PictureBox>().FirstOrDefault();

				if ( pic != null ) {
					c.Margin = new Padding( 0 );
					c.Padding = new Padding( margin );
					c.Height = (int) ( width * (decimal) pic.Image.Height / pic.Image.Width );
					c.Width = width;

					foreach ( var lbl in pic.Controls.OfType<Label>() ) {
						lbl.BringToFront();
						lbl.Width = c.Width;

						if ( lbl.Tag != null && (string) lbl.Tag == "Repos" ) {
							lbl.Top = c.Height - 30;
						}
					}
				}
			}

			flpPictures.ResumeLayout();
		}
		private void AddAddress ( TypeSourceEnum typeSource, string address ) {
			using ( var db = new dbImages() ) { db.AddAddressSource( typeSource, address ); }

			//lstAddresses.Items.Add( new MemSource {
			clbAddresses.Items.Add( new MemSource {
				Address = address,
				TypeSource = typeSource
			} );
		}
		private bool ChangeDesktopWallpaper () {
			//using ( var wall = new WallpaperTool() ) {
			//this.Wall.SetLast();

			var changing = this.Wall.ChangeWallpaper(
				clbAddresses
					.CheckedItems
					.Cast<MemSource>()
					.Select( ms => new DirectoryInfo( ms.TypeSource != TypeSourceEnum.Directory
																? GetImagesPath( "Wallhaven", ms.Address )
																: ms.Address ) ),
				cbAllDirectories.Checked,
				(StyleDesktop) ( (DropDownListItem) ddStyleDesktop.Items[ddStyleDesktop.SelectedIndex] ).Origin,
				(double) nudRatio.Value );

			if ( changing ) {
				SetWallpaperView();
			}

			return changing;
			//}
		}
		private void ActivateWallpaperLapsus () {
			tWallpaperLapsus.Interval = GetTotalInterval();
			tWallpaperLapsus.Start();

			this.NextWallpaperChange = DateTime.UtcNow.AddMilliseconds( tWallpaperLapsus.Interval );
		}

		private void cmsSources_ItemClicked ( object sender, ToolStripItemClickedEventArgs e ) {

		}
		private void tsmiExplore_Click ( object sender, EventArgs e ) {
			var resBrowse = fbdBrowse.ShowDialog();

			if ( resBrowse == DialogResult.OK ) {
				AddAddress( TypeSourceEnum.Directory, fbdBrowse.SelectedPath );
			}
		}
		private void tsmiWallhaven_Click ( object sender, EventArgs e ) {
			using ( var wall = new frmWallhaven() ) {
				var resDialog = wall.ShowDialog( this );

				if ( resDialog == DialogResult.OK ) {
					AddAddress( TypeSourceEnum.Wallhaven, wall.Keyword );
				}
			}
		}
		private async void tsmiShowOnlinePagging_Click ( object sender, EventArgs e ) {
			var source = cmsAdresses.Tag as MemSource;

			var index = clbAddresses.Items.IndexOf( source );
			if ( index >= 0 ) {
				clbAddresses.Tag = true;
				clbAddresses.SelectedIndex = index;

				await ReviewFromInitialPosition();
			}
		}
		private void tsmiShowDirectory_Click ( object sender, EventArgs e ) {
			var source = cmsAdresses.Tag as MemSource;

			Process.Start( new ProcessStartInfo {
				FileName = source.TypeSource == TypeSourceEnum.Directory
										? source.Address
										: GetImagesPath( "Wallhaven", source.Address ),
				UseShellExecute = true,
				Verb = "Open"
			} );
		}
		private void tsmiDeleteAddress_Click ( object sender, EventArgs e ) {
			var source = cmsAdresses.Tag as MemSource;

			//lstAddresses.Items.Remove( source );
			clbAddresses.Items.Remove( source );
		}

		private void nudColumns_ValueChanged ( object sender, EventArgs e ) {
			ResizePictures();
		}
		private void nudMargin_ValueChanged ( object sender, EventArgs e ) {
			ResizePictures();
		}
		private void flpPictures_Resize ( object sender, EventArgs e ) {
			ResizePictures();
		}

		private void btCancelSeeking_Click ( object sender, EventArgs e ) {
			this.CancelToken.Cancel();
		}
		private async void btNextPage_Click ( object sender, EventArgs e ) {
			await ReviewSelectedAddress( ( this.CancelToken = new CancellationTokenSource() ).Token );
		}

		private void btDeleteWallpaper_Click ( object sender, EventArgs e ) {
			var currentWall = this.Wall.GetDesktopWallpaper();

			if ( ChangeDesktopWallpaper() ) {
				ActivateWallpaperLapsus();

				this.Wall.RemoveWallpaper( currentWall );
				this.Shell.AddToDelete( currentWall );
			}
		}
		private void btNextWallpaper_Click ( object sender, EventArgs e ) {
			if ( ChangeDesktopWallpaper() ) {
				ActivateWallpaperLapsus();
			}
		}
		private void btWallpaperLapsus_Click ( object sender, EventArgs e ) {
			var isActive = ( (bool?) btWallpaperLapsus.Tag ).GetValueOrDefault( false );

			if ( !isActive ) {
				if ( ChangeDesktopWallpaper() ) {
					btWallpaperLapsus.Tag = true;
					btWallpaperLapsus.Text = "■";
					btWallpaperLapsus.BackColor = Color.Red;
					btWallpaperLapsus.ForeColor = Color.White;

					lbLapsusRest.Visible = true;

					tLapsusRevision.Interval = 500;
					tLapsusRevision.Start();

					ActivateWallpaperLapsus();
				}

			} else {
				tLapsusRevision.Stop();
				tWallpaperLapsus.Stop();

				lbLapsusRest.Visible = false;
				btWallpaperLapsus.Tag = false;
				btWallpaperLapsus.Text = "►";
				btWallpaperLapsus.BackColor = SystemColors.Control;
				btWallpaperLapsus.ForeColor = Color.Indigo;
			}
		}
		private void btWarning_Click ( object sender, EventArgs e ) {
			this.Hide();

			tWallpaperLapsus.Tag = tWallpaperLapsus.Enabled;
			tWallpaperLapsus.Stop();

			this.Wall.SetWallpaper(
				StyleDesktop.Fit,
				Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.Windows ), "Web", "Wallpaper", "Windows", "img0.jpg" )
			);
		}
		private void niDesktopWallpaper_DoubleClick ( object sender, EventArgs e ) {
			this.Show();

			this.Wall.SetWallpaper(
				(StyleDesktop) ( (DropDownListItem) ddStyleDesktop.Items[ddStyleDesktop.SelectedIndex] ).Origin,
				this.Wall.WallpaperLast
			);

			if ( ( (bool?) tWallpaperLapsus.Tag ).GetValueOrDefault( false ) ) {
				tWallpaperLapsus.Tag = false;

				ActivateWallpaperLapsus();
			}
		}
		private void btSourceSelect_Click ( object sender, EventArgs e ) {
			cmsSources.Show( btSourceSelect.PointToScreen( new Point( 0, btSourceSelect.Height ) ) );
		}

		private void nudWallpaperLapsus_ValueChanged ( object sender, EventArgs e ) {
			var kkkd = 3223;
		}
		private void ddLapsus_SelectedIndexChanged ( object sender, EventArgs e ) {
			var kdkd = 3232;
		}
		private void tWallpaperLapsus_Tick ( object sender, EventArgs e ) {
			if ( ChangeDesktopWallpaper() ) {
				ActivateWallpaperLapsus();
			}
		}
		private void tLapsusRevision_Tick ( object sender, EventArgs e ) {
			if ( tWallpaperLapsus.Enabled ) {
				TimeSpan resting = this.NextWallpaperChange - DateTime.UtcNow;

				lbLapsusRest.ForeColor = resting.TotalMilliseconds <= 0.1 * GetTotalInterval()
															? Color.IndianRed
															: SystemColors.ControlText;

				lbLapsusRest.Text = GetTimeFormatted( resting );
			}

			if ( !this.Shell.IsNowDeleting && this.__optionCounter == 0 && this.Shell.ExistFileToDelete ) {
				this.Shell.DeleteFiles();
			}

			++this.__optionCounter;
			if ( this.__optionCounter >= 5 ) { this.__optionCounter = 0; }
		}

		private async void flpPictures_Scroll ( object sender, ScrollEventArgs e ) {
			////if ( e.ScrollOrientation == ScrollOrientation.VerticalScroll ) {
			////	var newDirection = e.NewValue >= e.OldValue ? ScrollDirectionEnum.Increment : ScrollDirectionEnum.Decrement;
			////	if ( newDirection == this.ScrollDirection ) {
			////		if ( e.NewValue != 0
			////					&& e.NewValue == e.OldValue
			////					&& e.NewValue + flpPictures.VerticalScroll.LargeChange == flpPictures.VerticalScroll.Maximum + 1 ) {
			////			await ReviewSelectedAddress();
			////		}
			////	}

			////	this.ScrollDirection = newDirection;
			////}
		}

		private async Task ReviewFromInitialPosition () {
			flpPictures.Controls.Clear();

			GC.Collect();
			GC.WaitForPendingFinalizers();

			//foreach ( var ms in lstAddresses.SelectedItems.Cast<MemSource>().ToList() ) {
			foreach ( var ms in clbAddresses.SelectedItems.Cast<MemSource>().ToList() ) {
				ms.Index = 0;
				ms.Ended = false;
			}

			await ReviewSelectedAddress( ( this.CancelToken = new CancellationTokenSource() ).Token );
		}
		private int GetSecondsFromLapsus ( LapsusEnum lapsus ) {
			switch ( lapsus ) {
				case LapsusEnum.Seconds:
					return (int) nudWallpaperLapsus.Value * 1000;
				case LapsusEnum.Minutes:
					return (int) nudWallpaperLapsus.Value * 1000 * 60;
				case LapsusEnum.Hours:
					return (int) nudWallpaperLapsus.Value * 1000 * 60 * 60;
				case LapsusEnum.Days:
					return (int) nudWallpaperLapsus.Value * 1000 * 60 * 60 * 24;
				case LapsusEnum.Weeks:
					return (int) nudWallpaperLapsus.Value * 1000 * 60 * 60 * 24 * 7;
				case LapsusEnum.Months:
					return (int) nudWallpaperLapsus.Value * 1000 * 60 * 60 * 24 * 28;
				default:
					throw new ArgumentOutOfRangeException( "Lapsus doesn't exist" );
			}
		}
		private int GetTotalInterval () {
			var lapsus = ddLapsus.Items[ddLapsus.SelectedIndex] as DropDownListItem;
			return GetSecondsFromLapsus( (LapsusEnum) lapsus.Value );
		}
		private void ActivateViewerWallpaperView ( bool activeSetting ) {
			picWallpaper.Visible = activeSetting;
			flpPictures.Visible = !activeSetting;

			if ( activeSetting ) {
				picWallpaper.Dock = DockStyle.Fill;
				flpPictures.Dock = DockStyle.None;
			} else {
				picWallpaper.Dock = DockStyle.None;
				flpPictures.Dock = DockStyle.Fill;
			}
		}
		private void SetWallpaperView () {
			if ( picWallpaper.Visible ) {
				picWallpaper.Image = GetThumb( this.Wall.GetDesktopWallpaper(), picWallpaper.Width );
				picWallpaper.SizeMode = PictureBoxSizeMode.Zoom;

				var wallNext = this.Wall.Next;
				if ( wallNext != null ) {
					var width = picWallpaper.Width / 4;
					var height = picWallpaper.Height / 4;

					var picInner = new PictureBox() {
						Name = "picInner_" + Guid.NewGuid().ToString(),
						Width = width,
						Height = height,
						SizeMode = PictureBoxSizeMode.Zoom,
						Top = picWallpaper.Height - (int) ( height * 1.1 ),
						Left = picWallpaper.Width - (int) ( width * 1.1 ),
						Image = GetThumb( wallNext.Fullname, width ),
						Anchor = AnchorStyles.Bottom | AnchorStyles.Right
					};

					picWallpaper.Controls.Clear();
					picWallpaper.Controls.Add( picInner );
				}
			}
		}

		////private void lstAddresses_Click ( object sender, EventArgs e ) {
		////	//var jjjd = 3232;

		////}
		////private void lstAddresses_MouseClick ( object sender, MouseEventArgs e ) {
		////	////var jjjd = 3232;
		////	////if ( e.Button == MouseButtons.Right ) {
		////	////	var sdf = 3232;

		////	////}
		////}
		////private void lstAddresses_MouseDown ( object sender, MouseEventArgs e ) {
		////	////var jjjd = 3232;
		////	////if ( e.Button == MouseButtons.Right ) {
		////	////	var sdf = 3232;

		////	////}
		////}
		////private void lstAddresses_MouseUp ( object sender, MouseEventArgs e ) {
		////	////if ( e.Button == MouseButtons.Right ) {
		////	////	var index = lstAddresses.IndexFromPoint( e.Location );
		////	////	if ( index >= 0 ) {
		////	////		var current = lstAddresses.Items[index];

		////	////		tsmiDeleteAddress.Text = String.Format(
		////	////										@"Delete '{0}' addressing",
		////	////										( current as MemSource ).ToString() );

		////	////		tsmiShowDirectory.Text = String.Format(
		////	////										@"Open '{0}' directory.",
		////	////										( current as MemSource ).ToString() );

		////	////		cmsAdresses.Tag = current;
		////	////		cmsAdresses.Show( lstAddresses, e.Location );
		////	////	}

		////	////}
		////}
		////private async void lstAddresses_SelectedIndexChanged ( object sender, EventArgs e ) {
		////	////await ReviewFromInitialPosition();
		////}

		private void clbAddresses_Click ( object sender, EventArgs e ) {
			var kfkf = 32;
		}
		private void clbAddresses_MouseClick ( object sender, MouseEventArgs e ) {
			var jjjd = 3232;
			if ( e.Button == MouseButtons.Right ) {
				var sdf = 3232;

			}
		}
		private void clbAddresses_MouseDown ( object sender, MouseEventArgs e ) {
			var jjjd = 3232;
			if ( e.Button == MouseButtons.Right ) {
				var sdf = 3232;

			}
		}
		private void clbAddresses_MouseUp ( object sender, MouseEventArgs e ) {
			if ( e.Button == MouseButtons.Right ) {
				var index = clbAddresses.IndexFromPoint( e.Location );
				if ( index >= 0 ) {
					var current = clbAddresses.Items[index];

					tsmiDeleteAddress.Text = String.Format(
													@"Delete '{0}' addressing",
													( current as MemSource ).ToString() );

					tsmiShowDirectory.Text = String.Format(
													@"Open '{0}' directory.",
													( current as MemSource ).ToString() );

					cmsAdresses.Tag = current;
					cmsAdresses.Show( clbAddresses, e.Location );
				}
			}
		}
		private async void clbAddresses_SelectedIndexChanged ( object sender, EventArgs e ) {
			if ( ( !(bool?) clbAddresses.Tag ).GetValueOrDefault( false ) ) {
				await ReviewFromInitialPosition();
			} else {
				clbAddresses.Tag = false;
			}
		}
		private void clbAddresses_ItemCheck ( object sender, ItemCheckEventArgs e ) {
			clbAddresses.Tag = true;
		}

		private async void cbNSFW_CheckedChanged ( object sender, EventArgs e ) {
			await ReviewFromInitialPosition();
		}
		private async void cbSketchy_CheckedChanged ( object sender, EventArgs e ) {
			await ReviewFromInitialPosition();
		}
		private async void ddSorting_SelectedIndexChanged ( object sender, EventArgs e ) {
			await ReviewFromInitialPosition();
		}
		private void cbFilterNotFound_CheckedChanged ( object sender, EventArgs e ) {
			flpPictures.SuspendLayout();

			foreach ( var panel in flpPictures.Controls.OfType<Panel>() ) {
				var tag = panel.Tag as MemPicture;

				if ( tag.TypeSource != TypeSourceEnum.Directory && tag.Detail == null ) {
					panel.Visible = !cbFilterNotFound.Checked;
				}
			}

			ResizePictures();
			flpPictures.ResumeLayout();
		}

		private async void cbShowDirectory_CheckedChanged ( object sender, EventArgs e ) {
			await ReviewFromInitialPosition();
		}

		private void cbSwitchWallpaper_CheckedChanged ( object sender, EventArgs e ) {
			if ( cbSwitchWallpaper.Checked ) {
				ActivateViewerWallpaperView( true );
				SetWallpaperView();
			} else {
				ActivateViewerWallpaperView( false );
			}
		}

	}

}
