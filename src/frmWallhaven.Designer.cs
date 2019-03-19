namespace AM.Desktop.Win {
	partial class frmWallhaven {
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
			this.txKeyword = new System.Windows.Forms.TextBox();
			this.btAddSearch = new System.Windows.Forms.Button();
			this.lbKeyword = new System.Windows.Forms.Label();
			this.lbMessage = new System.Windows.Forms.Label();
			this.lbWallhaven = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txKeyword
			// 
			this.txKeyword.Location = new System.Drawing.Point(66, 77);
			this.txKeyword.Name = "txKeyword";
			this.txKeyword.Size = new System.Drawing.Size(178, 20);
			this.txKeyword.TabIndex = 1;
			// 
			// btAddSearch
			// 
			this.btAddSearch.Location = new System.Drawing.Point(250, 75);
			this.btAddSearch.Name = "btAddSearch";
			this.btAddSearch.Size = new System.Drawing.Size(75, 23);
			this.btAddSearch.TabIndex = 2;
			this.btAddSearch.Text = "Add Search";
			this.btAddSearch.UseVisualStyleBackColor = true;
			this.btAddSearch.Click += new System.EventHandler(this.btAddSearch_Click);
			// 
			// lbKeyword
			// 
			this.lbKeyword.AutoSize = true;
			this.lbKeyword.Location = new System.Drawing.Point(12, 80);
			this.lbKeyword.Name = "lbKeyword";
			this.lbKeyword.Size = new System.Drawing.Size(48, 13);
			this.lbKeyword.TabIndex = 3;
			this.lbKeyword.Text = "Keyword";
			// 
			// lbMessage
			// 
			this.lbMessage.AutoSize = true;
			this.lbMessage.Location = new System.Drawing.Point(14, 57);
			this.lbMessage.Name = "lbMessage";
			this.lbMessage.Size = new System.Drawing.Size(232, 13);
			this.lbMessage.TabIndex = 4;
			this.lbMessage.Text = "Add a keyword to search on the Wallhaven API";
			// 
			// lbWallhaven
			// 
			this.lbWallhaven.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbWallhaven.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbWallhaven.Image = global::AM.Desktop.Win.Properties.Resources.wallhaven_logo_sm;
			this.lbWallhaven.Location = new System.Drawing.Point(12, 6);
			this.lbWallhaven.Name = "lbWallhaven";
			this.lbWallhaven.Size = new System.Drawing.Size(310, 43);
			this.lbWallhaven.TabIndex = 0;
			// 
			// frmWallhaven
			// 
			this.AcceptButton = this.btAddSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 106);
			this.Controls.Add(this.lbMessage);
			this.Controls.Add(this.lbKeyword);
			this.Controls.Add(this.btAddSearch);
			this.Controls.Add(this.txKeyword);
			this.Controls.Add(this.lbWallhaven);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmWallhaven";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Wallhaven";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbWallhaven;
		private System.Windows.Forms.TextBox txKeyword;
		private System.Windows.Forms.Button btAddSearch;
		private System.Windows.Forms.Label lbKeyword;
		private System.Windows.Forms.Label lbMessage;
	}
}