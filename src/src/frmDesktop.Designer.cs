namespace AM.Desktop.Win {
	partial class frmDesktop {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesktop));
			this.btSourceSelect = new System.Windows.Forms.Button();
			this.cmsSources = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiExplore = new System.Windows.Forms.ToolStripMenuItem();
			this.tssSourceSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiWallhaven = new System.Windows.Forms.ToolStripMenuItem();
			this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
			this.flpPictures = new System.Windows.Forms.FlowLayoutPanel();
			this.scPrincipal = new System.Windows.Forms.SplitContainer();
			this.clbAddresses = new System.Windows.Forms.CheckedListBox();
			this.picWallpaper = new System.Windows.Forms.PictureBox();
			this.cbAllDirectories = new System.Windows.Forms.CheckBox();
			this.lbColumn = new System.Windows.Forms.Label();
			this.nudColumns = new System.Windows.Forms.NumericUpDown();
			this.cbNSFW = new System.Windows.Forms.CheckBox();
			this.cbSketchy = new System.Windows.Forms.CheckBox();
			this.lbPages = new System.Windows.Forms.Label();
			this.ddSorting = new System.Windows.Forms.ComboBox();
			this.lbSorting = new System.Windows.Forms.Label();
			this.ssPrincipal = new System.Windows.Forms.StatusStrip();
			this.tsslMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslErrors = new System.Windows.Forms.ToolStripStatusLabel();
			this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tsslTimming = new System.Windows.Forms.ToolStripStatusLabel();
			this.cbFilterNotFound = new System.Windows.Forms.CheckBox();
			this.gbTools = new System.Windows.Forms.GroupBox();
			this.btWarning = new System.Windows.Forms.Button();
			this.gbWallpaperLapsus = new System.Windows.Forms.GroupBox();
			this.lbRatio = new System.Windows.Forms.Label();
			this.nudRatio = new System.Windows.Forms.NumericUpDown();
			this.btDeleteWallpaper = new System.Windows.Forms.Button();
			this.btNextWallpaper = new System.Windows.Forms.Button();
			this.lbStyleDesktop = new System.Windows.Forms.Label();
			this.ddStyleDesktop = new System.Windows.Forms.ComboBox();
			this.lbLapsusRest = new System.Windows.Forms.Label();
			this.ddLapsus = new System.Windows.Forms.ComboBox();
			this.nudWallpaperLapsus = new System.Windows.Forms.NumericUpDown();
			this.lbLapsus = new System.Windows.Forms.Label();
			this.btWallpaperLapsus = new System.Windows.Forms.Button();
			this.cbShowDirectory = new System.Windows.Forms.CheckBox();
			this.nudPaging = new System.Windows.Forms.NumericUpDown();
			this.lbPager = new System.Windows.Forms.Label();
			this.btCancelSeeking = new System.Windows.Forms.Button();
			this.lbPageTitle = new System.Windows.Forms.Label();
			this.btNextPage = new System.Windows.Forms.Button();
			this.nudMargin = new System.Windows.Forms.NumericUpDown();
			this.lbMargin = new System.Windows.Forms.Label();
			this.cmsAdresses = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiShowOnlinePagging = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiShowDirectory = new System.Windows.Forms.ToolStripMenuItem();
			this.tssAddressSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiDeleteAddress = new System.Windows.Forms.ToolStripMenuItem();
			this.tWallpaperLapsus = new System.Windows.Forms.Timer(this.components);
			this.tLapsusRevision = new System.Windows.Forms.Timer(this.components);
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.niDesktopWallpaper = new System.Windows.Forms.NotifyIcon(this.components);
			this.cbSwitchWallpaper = new System.Windows.Forms.CheckBox();
			this.tErrorSaving = new System.Windows.Forms.Timer(this.components);
			this.cmsSources.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scPrincipal)).BeginInit();
			this.scPrincipal.Panel1.SuspendLayout();
			this.scPrincipal.Panel2.SuspendLayout();
			this.scPrincipal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picWallpaper)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
			this.ssPrincipal.SuspendLayout();
			this.gbTools.SuspendLayout();
			this.gbWallpaperLapsus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRatio)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWallpaperLapsus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudPaging)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMargin)).BeginInit();
			this.cmsAdresses.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// btSourceSelect
			// 
			this.btSourceSelect.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSourceSelect.ForeColor = System.Drawing.Color.ForestGreen;
			this.btSourceSelect.Location = new System.Drawing.Point(67, 12);
			this.btSourceSelect.Name = "btSourceSelect";
			this.btSourceSelect.Size = new System.Drawing.Size(36, 30);
			this.btSourceSelect.TabIndex = 1;
			this.btSourceSelect.Text = "▼";
			this.btSourceSelect.UseVisualStyleBackColor = true;
			this.btSourceSelect.Click += new System.EventHandler(this.btSourceSelect_Click);
			// 
			// cmsSources
			// 
			this.cmsSources.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExplore,
            this.tssSourceSeparator,
            this.tsmiWallhaven});
			this.cmsSources.Name = "cmsSources";
			this.cmsSources.Size = new System.Drawing.Size(130, 54);
			this.cmsSources.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsSources_ItemClicked);
			// 
			// tsmiExplore
			// 
			this.tsmiExplore.Name = "tsmiExplore";
			this.tsmiExplore.Size = new System.Drawing.Size(129, 22);
			this.tsmiExplore.Text = "Explore...";
			this.tsmiExplore.Click += new System.EventHandler(this.tsmiExplore_Click);
			// 
			// tssSourceSeparator
			// 
			this.tssSourceSeparator.Name = "tssSourceSeparator";
			this.tssSourceSeparator.Size = new System.Drawing.Size(126, 6);
			// 
			// tsmiWallhaven
			// 
			this.tsmiWallhaven.Name = "tsmiWallhaven";
			this.tsmiWallhaven.Size = new System.Drawing.Size(129, 22);
			this.tsmiWallhaven.Text = "Wallhaven";
			this.tsmiWallhaven.Click += new System.EventHandler(this.tsmiWallhaven_Click);
			// 
			// flpPictures
			// 
			this.flpPictures.AutoScroll = true;
			this.flpPictures.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flpPictures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.flpPictures.Location = new System.Drawing.Point(382, 1);
			this.flpPictures.Margin = new System.Windows.Forms.Padding(0);
			this.flpPictures.Name = "flpPictures";
			this.flpPictures.Size = new System.Drawing.Size(411, 185);
			this.flpPictures.TabIndex = 5;
			this.flpPictures.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flpPictures_Scroll);
			this.flpPictures.Resize += new System.EventHandler(this.flpPictures_Resize);
			// 
			// scPrincipal
			// 
			this.scPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scPrincipal.Location = new System.Drawing.Point(4, 76);
			this.scPrincipal.Name = "scPrincipal";
			// 
			// scPrincipal.Panel1
			// 
			this.scPrincipal.Panel1.Controls.Add(this.clbAddresses);
			// 
			// scPrincipal.Panel2
			// 
			this.scPrincipal.Panel2.Controls.Add(this.picWallpaper);
			this.scPrincipal.Panel2.Controls.Add(this.flpPictures);
			this.scPrincipal.Size = new System.Drawing.Size(913, 188);
			this.scPrincipal.SplitterDistance = 115;
			this.scPrincipal.TabIndex = 6;
			// 
			// clbAddresses
			// 
			this.clbAddresses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clbAddresses.FormattingEnabled = true;
			this.clbAddresses.Location = new System.Drawing.Point(0, 0);
			this.clbAddresses.Name = "clbAddresses";
			this.clbAddresses.Size = new System.Drawing.Size(115, 188);
			this.clbAddresses.TabIndex = 21;
			this.clbAddresses.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbAddresses_ItemCheck);
			this.clbAddresses.Click += new System.EventHandler(this.clbAddresses_Click);
			this.clbAddresses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbAddresses_MouseClick);
			this.clbAddresses.SelectedIndexChanged += new System.EventHandler(this.clbAddresses_SelectedIndexChanged);
			this.clbAddresses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clbAddresses_MouseDown);
			this.clbAddresses.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clbAddresses_MouseUp);
			// 
			// picWallpaper
			// 
			this.picWallpaper.Location = new System.Drawing.Point(7, 4);
			this.picWallpaper.Name = "picWallpaper";
			this.picWallpaper.Size = new System.Drawing.Size(337, 181);
			this.picWallpaper.TabIndex = 6;
			this.picWallpaper.TabStop = false;
			// 
			// cbAllDirectories
			// 
			this.cbAllDirectories.AutoSize = true;
			this.cbAllDirectories.Location = new System.Drawing.Point(8, 56);
			this.cbAllDirectories.Name = "cbAllDirectories";
			this.cbAllDirectories.Size = new System.Drawing.Size(172, 17);
			this.cbAllDirectories.TabIndex = 7;
			this.cbAllDirectories.Text = "Seeking into directory structure";
			this.cbAllDirectories.UseVisualStyleBackColor = true;
			// 
			// lbColumn
			// 
			this.lbColumn.AutoSize = true;
			this.lbColumn.Location = new System.Drawing.Point(5, 12);
			this.lbColumn.Name = "lbColumn";
			this.lbColumn.Size = new System.Drawing.Size(47, 13);
			this.lbColumn.TabIndex = 8;
			this.lbColumn.Text = "Columns";
			// 
			// nudColumns
			// 
			this.nudColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudColumns.Location = new System.Drawing.Point(55, 11);
			this.nudColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudColumns.Name = "nudColumns";
			this.nudColumns.Size = new System.Drawing.Size(42, 18);
			this.nudColumns.TabIndex = 9;
			this.nudColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudColumns.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
			this.nudColumns.ValueChanged += new System.EventHandler(this.nudColumns_ValueChanged);
			// 
			// cbNSFW
			// 
			this.cbNSFW.AutoSize = true;
			this.cbNSFW.Location = new System.Drawing.Point(230, 11);
			this.cbNSFW.Name = "cbNSFW";
			this.cbNSFW.Size = new System.Drawing.Size(148, 17);
			this.cbNSFW.TabIndex = 10;
			this.cbNSFW.Text = "Not safe for work (NSFW)";
			this.cbNSFW.UseVisualStyleBackColor = true;
			this.cbNSFW.CheckedChanged += new System.EventHandler(this.cbNSFW_CheckedChanged);
			// 
			// cbSketchy
			// 
			this.cbSketchy.AutoSize = true;
			this.cbSketchy.Location = new System.Drawing.Point(230, 26);
			this.cbSketchy.Name = "cbSketchy";
			this.cbSketchy.Size = new System.Drawing.Size(140, 17);
			this.cbSketchy.TabIndex = 11;
			this.cbSketchy.Text = "Sketchy wallpapers only";
			this.cbSketchy.UseVisualStyleBackColor = true;
			this.cbSketchy.CheckedChanged += new System.EventHandler(this.cbSketchy_CheckedChanged);
			// 
			// lbPages
			// 
			this.lbPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbPages.AutoSize = true;
			this.lbPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbPages.Location = new System.Drawing.Point(773, 27);
			this.lbPages.Name = "lbPages";
			this.lbPages.Size = new System.Drawing.Size(32, 22);
			this.lbPages.TabIndex = 12;
			this.lbPages.Text = "00";
			this.lbPages.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ddSorting
			// 
			this.ddSorting.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ddSorting.FormattingEnabled = true;
			this.ddSorting.Location = new System.Drawing.Point(146, 9);
			this.ddSorting.Name = "ddSorting";
			this.ddSorting.Size = new System.Drawing.Size(77, 20);
			this.ddSorting.TabIndex = 13;
			this.ddSorting.SelectedIndexChanged += new System.EventHandler(this.ddSorting_SelectedIndexChanged);
			// 
			// lbSorting
			// 
			this.lbSorting.AutoSize = true;
			this.lbSorting.Location = new System.Drawing.Point(104, 12);
			this.lbSorting.Name = "lbSorting";
			this.lbSorting.Size = new System.Drawing.Size(40, 13);
			this.lbSorting.TabIndex = 14;
			this.lbSorting.Text = "Sorting";
			// 
			// ssPrincipal
			// 
			this.ssPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMessage,
            this.tsslErrors,
            this.tspbProgress,
            this.tsslTimming});
			this.ssPrincipal.Location = new System.Drawing.Point(0, 268);
			this.ssPrincipal.Name = "ssPrincipal";
			this.ssPrincipal.Size = new System.Drawing.Size(921, 22);
			this.ssPrincipal.TabIndex = 15;
			this.ssPrincipal.Text = "statusStrip1";
			// 
			// tsslMessage
			// 
			this.tsslMessage.Name = "tsslMessage";
			this.tsslMessage.Size = new System.Drawing.Size(0, 17);
			// 
			// tsslErrors
			// 
			this.tsslErrors.Name = "tsslErrors";
			this.tsslErrors.Size = new System.Drawing.Size(0, 17);
			// 
			// tspbProgress
			// 
			this.tspbProgress.Name = "tspbProgress";
			this.tspbProgress.Size = new System.Drawing.Size(100, 16);
			this.tspbProgress.Step = 1;
			// 
			// tsslTimming
			// 
			this.tsslTimming.Name = "tsslTimming";
			this.tsslTimming.Size = new System.Drawing.Size(79, 17);
			this.tsslTimming.Text = "Resting Time:";
			// 
			// cbFilterNotFound
			// 
			this.cbFilterNotFound.AutoSize = true;
			this.cbFilterNotFound.Location = new System.Drawing.Point(230, 41);
			this.cbFilterNotFound.Name = "cbFilterNotFound";
			this.cbFilterNotFound.Size = new System.Drawing.Size(96, 17);
			this.cbFilterNotFound.TabIndex = 17;
			this.cbFilterNotFound.Text = "Filter not found";
			this.cbFilterNotFound.UseVisualStyleBackColor = true;
			this.cbFilterNotFound.CheckedChanged += new System.EventHandler(this.cbFilterNotFound_CheckedChanged);
			// 
			// gbTools
			// 
			this.gbTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbTools.Controls.Add(this.btWarning);
			this.gbTools.Controls.Add(this.gbWallpaperLapsus);
			this.gbTools.Controls.Add(this.cbShowDirectory);
			this.gbTools.Controls.Add(this.nudPaging);
			this.gbTools.Controls.Add(this.lbPager);
			this.gbTools.Controls.Add(this.btCancelSeeking);
			this.gbTools.Controls.Add(this.cbAllDirectories);
			this.gbTools.Controls.Add(this.cbFilterNotFound);
			this.gbTools.Controls.Add(this.lbPageTitle);
			this.gbTools.Controls.Add(this.btNextPage);
			this.gbTools.Controls.Add(this.nudMargin);
			this.gbTools.Controls.Add(this.cbSketchy);
			this.gbTools.Controls.Add(this.lbMargin);
			this.gbTools.Controls.Add(this.lbColumn);
			this.gbTools.Controls.Add(this.ddSorting);
			this.gbTools.Controls.Add(this.nudColumns);
			this.gbTools.Controls.Add(this.cbNSFW);
			this.gbTools.Controls.Add(this.lbPages);
			this.gbTools.Controls.Add(this.lbSorting);
			this.gbTools.Location = new System.Drawing.Point(109, -3);
			this.gbTools.Name = "gbTools";
			this.gbTools.Size = new System.Drawing.Size(808, 77);
			this.gbTools.TabIndex = 18;
			this.gbTools.TabStop = false;
			// 
			// btWarning
			// 
			this.btWarning.BackgroundImage = global::AM.Desktop.Win.Properties.Resources._500px_Italian_traffic_signs___;
			this.btWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btWarning.Location = new System.Drawing.Point(634, 15);
			this.btWarning.Name = "btWarning";
			this.btWarning.Size = new System.Drawing.Size(67, 58);
			this.btWarning.TabIndex = 32;
			this.btWarning.UseVisualStyleBackColor = true;
			this.btWarning.Click += new System.EventHandler(this.btWarning_Click);
			// 
			// gbWallpaperLapsus
			// 
			this.gbWallpaperLapsus.Controls.Add(this.lbRatio);
			this.gbWallpaperLapsus.Controls.Add(this.nudRatio);
			this.gbWallpaperLapsus.Controls.Add(this.btDeleteWallpaper);
			this.gbWallpaperLapsus.Controls.Add(this.btNextWallpaper);
			this.gbWallpaperLapsus.Controls.Add(this.lbStyleDesktop);
			this.gbWallpaperLapsus.Controls.Add(this.ddStyleDesktop);
			this.gbWallpaperLapsus.Controls.Add(this.lbLapsusRest);
			this.gbWallpaperLapsus.Controls.Add(this.ddLapsus);
			this.gbWallpaperLapsus.Controls.Add(this.nudWallpaperLapsus);
			this.gbWallpaperLapsus.Controls.Add(this.lbLapsus);
			this.gbWallpaperLapsus.Controls.Add(this.btWallpaperLapsus);
			this.gbWallpaperLapsus.Location = new System.Drawing.Point(376, 9);
			this.gbWallpaperLapsus.Name = "gbWallpaperLapsus";
			this.gbWallpaperLapsus.Size = new System.Drawing.Size(255, 64);
			this.gbWallpaperLapsus.TabIndex = 31;
			this.gbWallpaperLapsus.TabStop = false;
			this.gbWallpaperLapsus.Text = "Change Wallpaper";
			// 
			// lbRatio
			// 
			this.lbRatio.AutoSize = true;
			this.lbRatio.Location = new System.Drawing.Point(116, 18);
			this.lbRatio.Name = "lbRatio";
			this.lbRatio.Size = new System.Drawing.Size(32, 13);
			this.lbRatio.TabIndex = 38;
			this.lbRatio.Text = "Ratio";
			// 
			// nudRatio
			// 
			this.nudRatio.DecimalPlaces = 2;
			this.nudRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudRatio.Location = new System.Drawing.Point(146, 16);
			this.nudRatio.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudRatio.Name = "nudRatio";
			this.nudRatio.Size = new System.Drawing.Size(43, 18);
			this.nudRatio.TabIndex = 37;
			this.nudRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// btDeleteWallpaper
			// 
			this.btDeleteWallpaper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btDeleteWallpaper.ForeColor = System.Drawing.Color.Red;
			this.btDeleteWallpaper.Location = new System.Drawing.Point(71, 37);
			this.btDeleteWallpaper.Name = "btDeleteWallpaper";
			this.btDeleteWallpaper.Size = new System.Drawing.Size(32, 23);
			this.btDeleteWallpaper.TabIndex = 36;
			this.btDeleteWallpaper.Text = "Ø";
			this.btDeleteWallpaper.UseVisualStyleBackColor = true;
			this.btDeleteWallpaper.Click += new System.EventHandler(this.btDeleteWallpaper_Click);
			// 
			// btNextWallpaper
			// 
			this.btNextWallpaper.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btNextWallpaper.ForeColor = System.Drawing.Color.Green;
			this.btNextWallpaper.Location = new System.Drawing.Point(37, 37);
			this.btNextWallpaper.Name = "btNextWallpaper";
			this.btNextWallpaper.Size = new System.Drawing.Size(32, 23);
			this.btNextWallpaper.TabIndex = 35;
			this.btNextWallpaper.Text = "►";
			this.btNextWallpaper.UseVisualStyleBackColor = true;
			this.btNextWallpaper.Click += new System.EventHandler(this.btNextWallpaper_Click);
			// 
			// lbStyleDesktop
			// 
			this.lbStyleDesktop.AutoSize = true;
			this.lbStyleDesktop.Location = new System.Drawing.Point(5, 18);
			this.lbStyleDesktop.Name = "lbStyleDesktop";
			this.lbStyleDesktop.Size = new System.Drawing.Size(30, 13);
			this.lbStyleDesktop.TabIndex = 34;
			this.lbStyleDesktop.Text = "Style";
			// 
			// ddStyleDesktop
			// 
			this.ddStyleDesktop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddStyleDesktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ddStyleDesktop.FormattingEnabled = true;
			this.ddStyleDesktop.Location = new System.Drawing.Point(42, 15);
			this.ddStyleDesktop.Name = "ddStyleDesktop";
			this.ddStyleDesktop.Size = new System.Drawing.Size(62, 20);
			this.ddStyleDesktop.TabIndex = 33;
			// 
			// lbLapsusRest
			// 
			this.lbLapsusRest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbLapsusRest.Font = new System.Drawing.Font("Old English Text MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbLapsusRest.Location = new System.Drawing.Point(177, 15);
			this.lbLapsusRest.Name = "lbLapsusRest";
			this.lbLapsusRest.Size = new System.Drawing.Size(76, 18);
			this.lbLapsusRest.TabIndex = 32;
			this.lbLapsusRest.Text = "00:00:00";
			this.lbLapsusRest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbLapsusRest.Visible = false;
			// 
			// ddLapsus
			// 
			this.ddLapsus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddLapsus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ddLapsus.FormattingEnabled = true;
			this.ddLapsus.Location = new System.Drawing.Point(191, 38);
			this.ddLapsus.Name = "ddLapsus";
			this.ddLapsus.Size = new System.Drawing.Size(57, 20);
			this.ddLapsus.TabIndex = 29;
			this.ddLapsus.SelectedIndexChanged += new System.EventHandler(this.ddLapsus_SelectedIndexChanged);
			// 
			// nudWallpaperLapsus
			// 
			this.nudWallpaperLapsus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudWallpaperLapsus.Location = new System.Drawing.Point(146, 39);
			this.nudWallpaperLapsus.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudWallpaperLapsus.Name = "nudWallpaperLapsus";
			this.nudWallpaperLapsus.Size = new System.Drawing.Size(43, 18);
			this.nudWallpaperLapsus.TabIndex = 27;
			this.nudWallpaperLapsus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudWallpaperLapsus.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudWallpaperLapsus.ValueChanged += new System.EventHandler(this.nudWallpaperLapsus_ValueChanged);
			// 
			// lbLapsus
			// 
			this.lbLapsus.AutoSize = true;
			this.lbLapsus.Location = new System.Drawing.Point(116, 42);
			this.lbLapsus.Name = "lbLapsus";
			this.lbLapsus.Size = new System.Drawing.Size(32, 13);
			this.lbLapsus.TabIndex = 31;
			this.lbLapsus.Text = "Each";
			// 
			// btWallpaperLapsus
			// 
			this.btWallpaperLapsus.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btWallpaperLapsus.ForeColor = System.Drawing.Color.Indigo;
			this.btWallpaperLapsus.Location = new System.Drawing.Point(4, 37);
			this.btWallpaperLapsus.Name = "btWallpaperLapsus";
			this.btWallpaperLapsus.Size = new System.Drawing.Size(32, 23);
			this.btWallpaperLapsus.TabIndex = 30;
			this.btWallpaperLapsus.Text = "►";
			this.btWallpaperLapsus.UseVisualStyleBackColor = true;
			this.btWallpaperLapsus.Click += new System.EventHandler(this.btWallpaperLapsus_Click);
			// 
			// cbShowDirectory
			// 
			this.cbShowDirectory.AutoSize = true;
			this.cbShowDirectory.Location = new System.Drawing.Point(230, 56);
			this.cbShowDirectory.Name = "cbShowDirectory";
			this.cbShowDirectory.Size = new System.Drawing.Size(140, 17);
			this.cbShowDirectory.TabIndex = 21;
			this.cbShowDirectory.Text = "Forced showing backup";
			this.cbShowDirectory.UseVisualStyleBackColor = true;
			this.cbShowDirectory.CheckedChanged += new System.EventHandler(this.cbShowDirectory_CheckedChanged);
			// 
			// nudPaging
			// 
			this.nudPaging.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudPaging.Location = new System.Drawing.Point(146, 30);
			this.nudPaging.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudPaging.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudPaging.Name = "nudPaging";
			this.nudPaging.Size = new System.Drawing.Size(39, 18);
			this.nudPaging.TabIndex = 26;
			this.nudPaging.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudPaging.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lbPager
			// 
			this.lbPager.AutoSize = true;
			this.lbPager.Location = new System.Drawing.Point(104, 31);
			this.lbPager.Name = "lbPager";
			this.lbPager.Size = new System.Drawing.Size(40, 13);
			this.lbPager.TabIndex = 25;
			this.lbPager.Text = "Paging";
			// 
			// btCancelSeeking
			// 
			this.btCancelSeeking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancelSeeking.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelSeeking.ForeColor = System.Drawing.Color.Crimson;
			this.btCancelSeeking.Location = new System.Drawing.Point(721, 49);
			this.btCancelSeeking.Name = "btCancelSeeking";
			this.btCancelSeeking.Size = new System.Drawing.Size(40, 24);
			this.btCancelSeeking.TabIndex = 24;
			this.btCancelSeeking.Text = "■";
			this.btCancelSeeking.UseVisualStyleBackColor = true;
			this.btCancelSeeking.Visible = false;
			this.btCancelSeeking.Click += new System.EventHandler(this.btCancelSeeking_Click);
			// 
			// lbPageTitle
			// 
			this.lbPageTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbPageTitle.AutoSize = true;
			this.lbPageTitle.Location = new System.Drawing.Point(735, 32);
			this.lbPageTitle.Name = "lbPageTitle";
			this.lbPageTitle.Size = new System.Drawing.Size(35, 13);
			this.lbPageTitle.TabIndex = 23;
			this.lbPageTitle.Text = "Page:";
			// 
			// btNextPage
			// 
			this.btNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btNextPage.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btNextPage.ForeColor = System.Drawing.Color.ForestGreen;
			this.btNextPage.Location = new System.Drawing.Point(763, 49);
			this.btNextPage.Margin = new System.Windows.Forms.Padding(0);
			this.btNextPage.Name = "btNextPage";
			this.btNextPage.Size = new System.Drawing.Size(40, 24);
			this.btNextPage.TabIndex = 22;
			this.btNextPage.Text = "►";
			this.btNextPage.UseVisualStyleBackColor = true;
			this.btNextPage.Click += new System.EventHandler(this.btNextPage_Click);
			// 
			// nudMargin
			// 
			this.nudMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudMargin.Location = new System.Drawing.Point(55, 30);
			this.nudMargin.Name = "nudMargin";
			this.nudMargin.Size = new System.Drawing.Size(42, 18);
			this.nudMargin.TabIndex = 20;
			this.nudMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudMargin.ValueChanged += new System.EventHandler(this.nudMargin_ValueChanged);
			// 
			// lbMargin
			// 
			this.lbMargin.AutoSize = true;
			this.lbMargin.Location = new System.Drawing.Point(5, 31);
			this.lbMargin.Name = "lbMargin";
			this.lbMargin.Size = new System.Drawing.Size(39, 13);
			this.lbMargin.TabIndex = 19;
			this.lbMargin.Text = "Margin";
			// 
			// cmsAdresses
			// 
			this.cmsAdresses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowOnlinePagging,
            this.tsmiShowDirectory,
            this.tssAddressSeparator,
            this.tsmiDeleteAddress});
			this.cmsAdresses.Name = "cmsAdresses";
			this.cmsAdresses.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.cmsAdresses.Size = new System.Drawing.Size(196, 76);
			// 
			// tsmiShowOnlinePagging
			// 
			this.tsmiShowOnlinePagging.Name = "tsmiShowOnlinePagging";
			this.tsmiShowOnlinePagging.Size = new System.Drawing.Size(195, 22);
			this.tsmiShowOnlinePagging.Text = "Show online pagging...";
			this.tsmiShowOnlinePagging.Click += new System.EventHandler(this.tsmiShowOnlinePagging_Click);
			// 
			// tsmiShowDirectory
			// 
			this.tsmiShowDirectory.Name = "tsmiShowDirectory";
			this.tsmiShowDirectory.Size = new System.Drawing.Size(195, 22);
			this.tsmiShowDirectory.Text = "Show directory";
			this.tsmiShowDirectory.Click += new System.EventHandler(this.tsmiShowDirectory_Click);
			// 
			// tssAddressSeparator
			// 
			this.tssAddressSeparator.Name = "tssAddressSeparator";
			this.tssAddressSeparator.Size = new System.Drawing.Size(192, 6);
			// 
			// tsmiDeleteAddress
			// 
			this.tsmiDeleteAddress.Name = "tsmiDeleteAddress";
			this.tsmiDeleteAddress.Size = new System.Drawing.Size(195, 22);
			this.tsmiDeleteAddress.Text = "Delete";
			this.tsmiDeleteAddress.Click += new System.EventHandler(this.tsmiDeleteAddress_Click);
			// 
			// tWallpaperLapsus
			// 
			this.tWallpaperLapsus.Tick += new System.EventHandler(this.tWallpaperLapsus_Tick);
			// 
			// tLapsusRevision
			// 
			this.tLapsusRevision.Interval = 250;
			this.tLapsusRevision.Tick += new System.EventHandler(this.tLapsusRevision_Tick);
			// 
			// picLogo
			// 
			this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
			this.picLogo.Location = new System.Drawing.Point(4, 4);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(57, 46);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picLogo.TabIndex = 19;
			this.picLogo.TabStop = false;
			// 
			// niDesktopWallpaper
			// 
			this.niDesktopWallpaper.Icon = ((System.Drawing.Icon)(resources.GetObject("niDesktopWallpaper.Icon")));
			this.niDesktopWallpaper.Text = "Desktop Wallpaper";
			this.niDesktopWallpaper.Visible = true;
			this.niDesktopWallpaper.DoubleClick += new System.EventHandler(this.niDesktopWallpaper_DoubleClick);
			// 
			// cbSwitchWallpaper
			// 
			this.cbSwitchWallpaper.AutoSize = true;
			this.cbSwitchWallpaper.Location = new System.Drawing.Point(6, 53);
			this.cbSwitchWallpaper.Name = "cbSwitchWallpaper";
			this.cbSwitchWallpaper.Size = new System.Drawing.Size(100, 17);
			this.cbSwitchWallpaper.TabIndex = 20;
			this.cbSwitchWallpaper.Text = "Wallpaper View";
			this.cbSwitchWallpaper.UseVisualStyleBackColor = true;
			this.cbSwitchWallpaper.CheckedChanged += new System.EventHandler(this.cbSwitchWallpaper_CheckedChanged);
			// 
			// tErrorSaving
			// 
			this.tErrorSaving.Enabled = true;
			this.tErrorSaving.Interval = 30000;
			this.tErrorSaving.Tick += new System.EventHandler(this.tErrorSaving_Tick);
			// 
			// frmDesktop
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(921, 290);
			this.Controls.Add(this.cbSwitchWallpaper);
			this.Controls.Add(this.gbTools);
			this.Controls.Add(this.ssPrincipal);
			this.Controls.Add(this.scPrincipal);
			this.Controls.Add(this.btSourceSelect);
			this.Controls.Add(this.picLogo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDesktop";
			this.Text = "Wallpaper Desktop";
			this.cmsSources.ResumeLayout(false);
			this.scPrincipal.Panel1.ResumeLayout(false);
			this.scPrincipal.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scPrincipal)).EndInit();
			this.scPrincipal.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picWallpaper)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
			this.ssPrincipal.ResumeLayout(false);
			this.ssPrincipal.PerformLayout();
			this.gbTools.ResumeLayout(false);
			this.gbTools.PerformLayout();
			this.gbWallpaperLapsus.ResumeLayout(false);
			this.gbWallpaperLapsus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRatio)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWallpaperLapsus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudPaging)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMargin)).EndInit();
			this.cmsAdresses.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btSourceSelect;
		private System.Windows.Forms.ContextMenuStrip cmsSources;
		private System.Windows.Forms.ToolStripMenuItem tsmiExplore;
		private System.Windows.Forms.ToolStripMenuItem tsmiWallhaven;
		private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
		private System.Windows.Forms.FlowLayoutPanel flpPictures;
		private System.Windows.Forms.SplitContainer scPrincipal;
		private System.Windows.Forms.CheckBox cbAllDirectories;
		private System.Windows.Forms.Label lbColumn;
		private System.Windows.Forms.NumericUpDown nudColumns;
		private System.Windows.Forms.CheckBox cbNSFW;
		private System.Windows.Forms.CheckBox cbSketchy;
		private System.Windows.Forms.Label lbPages;
		private System.Windows.Forms.ComboBox ddSorting;
		private System.Windows.Forms.Label lbSorting;
		private System.Windows.Forms.StatusStrip ssPrincipal;
		private System.Windows.Forms.ToolStripStatusLabel tsslMessage;
		private System.Windows.Forms.ToolStripStatusLabel tsslErrors;
		private System.Windows.Forms.CheckBox cbFilterNotFound;
		private System.Windows.Forms.GroupBox gbTools;
		private System.Windows.Forms.Label lbMargin;
		private System.Windows.Forms.NumericUpDown nudMargin;
		private System.Windows.Forms.ToolStripProgressBar tspbProgress;
		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.CheckBox cbShowDirectory;
		private System.Windows.Forms.Button btNextPage;
		private System.Windows.Forms.ContextMenuStrip cmsAdresses;
		private System.Windows.Forms.ToolStripMenuItem tsmiShowDirectory;
		private System.Windows.Forms.ToolStripStatusLabel tsslTimming;
		private System.Windows.Forms.Label lbPageTitle;
		private System.Windows.Forms.ToolStripMenuItem tsmiDeleteAddress;
		private System.Windows.Forms.ToolStripSeparator tssAddressSeparator;
		private System.Windows.Forms.ToolStripSeparator tssSourceSeparator;
		private System.Windows.Forms.Button btCancelSeeking;
		private System.Windows.Forms.NumericUpDown nudPaging;
		private System.Windows.Forms.Label lbPager;
		private System.Windows.Forms.CheckedListBox clbAddresses;
		private System.Windows.Forms.ComboBox ddLapsus;
		private System.Windows.Forms.NumericUpDown nudWallpaperLapsus;
		private System.Windows.Forms.Button btWallpaperLapsus;
		private System.Windows.Forms.ToolStripMenuItem tsmiShowOnlinePagging;
		private System.Windows.Forms.Timer tWallpaperLapsus;
		private System.Windows.Forms.GroupBox gbWallpaperLapsus;
		private System.Windows.Forms.Label lbLapsus;
		private System.Windows.Forms.Label lbLapsusRest;
		private System.Windows.Forms.Timer tLapsusRevision;
		private System.Windows.Forms.ComboBox ddStyleDesktop;
		private System.Windows.Forms.Label lbStyleDesktop;
		private System.Windows.Forms.Button btWarning;
		private System.Windows.Forms.NotifyIcon niDesktopWallpaper;
		private System.Windows.Forms.Button btNextWallpaper;
		private System.Windows.Forms.CheckBox cbSwitchWallpaper;
		private System.Windows.Forms.PictureBox picWallpaper;
		private System.Windows.Forms.Button btDeleteWallpaper;
		private System.Windows.Forms.Label lbRatio;
		private System.Windows.Forms.NumericUpDown nudRatio;
		private System.Windows.Forms.Timer tErrorSaving;
	}
}