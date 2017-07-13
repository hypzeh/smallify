namespace Smallify
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblTrack = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.tUpdate = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pBoxPlayBar = new System.Windows.Forms.PictureBox();
            this.pBoxAlbumArt = new System.Windows.Forms.PictureBox();
            this.pbtnPrevious = new System.Windows.Forms.PictureBox();
            this.pbtnPause = new System.Windows.Forms.PictureBox();
            this.pbtnSkip = new System.Windows.Forms.PictureBox();
            this.pbtnClose = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPlayBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAlbumArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSkip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = true;
            this.lblTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrack.ForeColor = System.Drawing.Color.White;
            this.lblTrack.Location = new System.Drawing.Point(3, 0);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(53, 20);
            this.lblTrack.TabIndex = 1;
            this.lblTrack.Text = "Track";
            this.lblTrack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblArtist.Location = new System.Drawing.Point(3, 20);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(46, 20);
            this.lblArtist.TabIndex = 1;
            this.lblArtist.Text = "Artist";
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tUpdate
            // 
            this.tUpdate.Tick += new System.EventHandler(this.tUpdate_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.lblTrack);
            this.flowLayoutPanel1.Controls.Add(this.lblArtist);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(64, 12);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(59, 40);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.pBoxAlbumArt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbtnPrevious, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbtnPause, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbtnSkip, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbtnClose, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(949, 64);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.pBoxPlayBar);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 64);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(949, 5);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // pBoxPlayBar
            // 
            this.pBoxPlayBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.pBoxPlayBar.Location = new System.Drawing.Point(0, 0);
            this.pBoxPlayBar.Margin = new System.Windows.Forms.Padding(0);
            this.pBoxPlayBar.Name = "pBoxPlayBar";
            this.pBoxPlayBar.Size = new System.Drawing.Size(10, 5);
            this.pBoxPlayBar.TabIndex = 6;
            this.pBoxPlayBar.TabStop = false;
            // 
            // pBoxAlbumArt
            // 
            this.pBoxAlbumArt.Image = ((System.Drawing.Image)(resources.GetObject("pBoxAlbumArt.Image")));
            this.pBoxAlbumArt.Location = new System.Drawing.Point(0, 0);
            this.pBoxAlbumArt.Margin = new System.Windows.Forms.Padding(0);
            this.pBoxAlbumArt.Name = "pBoxAlbumArt";
            this.pBoxAlbumArt.Size = new System.Drawing.Size(64, 64);
            this.pBoxAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxAlbumArt.TabIndex = 4;
            this.pBoxAlbumArt.TabStop = false;
            // 
            // pbtnPrevious
            // 
            this.pbtnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbtnPrevious.Image = global::Smallify.Properties.Resources.previous_default;
            this.pbtnPrevious.Location = new System.Drawing.Point(788, 16);
            this.pbtnPrevious.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pbtnPrevious.Name = "pbtnPrevious";
            this.pbtnPrevious.Size = new System.Drawing.Size(32, 32);
            this.pbtnPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbtnPrevious.TabIndex = 3;
            this.pbtnPrevious.TabStop = false;
            this.pbtnPrevious.Click += new System.EventHandler(this.pbtnPrevious_Click);
            this.pbtnPrevious.MouseEnter += new System.EventHandler(this.pbtnPrevious_MouseHover);
            this.pbtnPrevious.MouseLeave += new System.EventHandler(this.pbtnPrevious_MouseLeave);
            // 
            // pbtnPause
            // 
            this.pbtnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnPause.Image = global::Smallify.Properties.Resources.pause_default;
            this.pbtnPause.Location = new System.Drawing.Point(830, 8);
            this.pbtnPause.Margin = new System.Windows.Forms.Padding(0);
            this.pbtnPause.Name = "pbtnPause";
            this.pbtnPause.Size = new System.Drawing.Size(48, 48);
            this.pbtnPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbtnPause.TabIndex = 3;
            this.pbtnPause.TabStop = false;
            this.pbtnPause.Click += new System.EventHandler(this.pbtnPause_Click);
            this.pbtnPause.MouseEnter += new System.EventHandler(this.pbtnPause_MouseHover);
            this.pbtnPause.MouseLeave += new System.EventHandler(this.pbtnPause_MouseLeave);
            // 
            // pbtnSkip
            // 
            this.pbtnSkip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbtnSkip.Image = global::Smallify.Properties.Resources.skip_default;
            this.pbtnSkip.Location = new System.Drawing.Point(888, 16);
            this.pbtnSkip.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pbtnSkip.Name = "pbtnSkip";
            this.pbtnSkip.Size = new System.Drawing.Size(32, 32);
            this.pbtnSkip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbtnSkip.TabIndex = 3;
            this.pbtnSkip.TabStop = false;
            this.pbtnSkip.Click += new System.EventHandler(this.pbtnSkip_Click);
            this.pbtnSkip.MouseEnter += new System.EventHandler(this.pbtnSkip_MouseHover);
            this.pbtnSkip.MouseLeave += new System.EventHandler(this.pbtnSkip_MouseLeave);
            // 
            // pbtnClose
            // 
            this.pbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbtnClose.Image = global::Smallify.Properties.Resources.close_default;
            this.pbtnClose.Location = new System.Drawing.Point(930, 3);
            this.pbtnClose.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.pbtnClose.Name = "pbtnClose";
            this.pbtnClose.Size = new System.Drawing.Size(16, 16);
            this.pbtnClose.TabIndex = 10;
            this.pbtnClose.TabStop = false;
            this.pbtnClose.Click += new System.EventHandler(this.pbtnClose_Click);
            this.pbtnClose.MouseEnter += new System.EventHandler(this.pbtnClose_MouseHover);
            this.pbtnClose.MouseLeave += new System.EventHandler(this.pbtnClose_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(949, 68);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Smallify";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPlayBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAlbumArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSkip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.PictureBox pbtnPrevious;
        private System.Windows.Forms.PictureBox pbtnPause;
        private System.Windows.Forms.PictureBox pBoxAlbumArt;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.PictureBox pBoxPlayBar;
        private System.Windows.Forms.Timer tUpdate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbtnSkip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pbtnClose;
    }
}

