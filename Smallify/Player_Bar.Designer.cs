namespace Smallify
{
    partial class Player_Bar
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
            this.Timer_Update = new System.Windows.Forms.Timer(this.components);
            this.TLP_TrackBar = new System.Windows.Forms.TableLayoutPanel();
            this.PB_AlbumArt = new System.Windows.Forms.PictureBox();
            this.Btn_Previous = new System.Windows.Forms.PictureBox();
            this.Btn_PlayPause = new System.Windows.Forms.PictureBox();
            this.Btn_Next = new System.Windows.Forms.PictureBox();
            this.FLP_MediaControls = new System.Windows.Forms.FlowLayoutPanel();
            this.FLP_TrackInformation = new System.Windows.Forms.FlowLayoutPanel();
            this.Label_Track = new System.Windows.Forms.Label();
            this.Label_Artist = new System.Windows.Forms.Label();
            this.Btn_Exit = new System.Windows.Forms.PictureBox();
            this.TLP_TrackBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_AlbumArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Previous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_PlayPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Next)).BeginInit();
            this.FLP_MediaControls.SuspendLayout();
            this.FLP_TrackInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer_Update
            // 
            this.Timer_Update.Tick += new System.EventHandler(this.Timer_Update_Tick);
            // 
            // TLP_TrackBar
            // 
            this.TLP_TrackBar.AutoSize = true;
            this.TLP_TrackBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLP_TrackBar.ColumnCount = 4;
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP_TrackBar.Controls.Add(this.Btn_Exit, 3, 0);
            this.TLP_TrackBar.Controls.Add(this.FLP_TrackInformation, 1, 0);
            this.TLP_TrackBar.Controls.Add(this.PB_AlbumArt, 0, 0);
            this.TLP_TrackBar.Controls.Add(this.FLP_MediaControls, 2, 0);
            this.TLP_TrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLP_TrackBar.Location = new System.Drawing.Point(0, 0);
            this.TLP_TrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_TrackBar.Name = "TLP_TrackBar";
            this.TLP_TrackBar.RowCount = 1;
            this.TLP_TrackBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_TrackBar.Size = new System.Drawing.Size(885, 100);
            this.TLP_TrackBar.TabIndex = 0;
            this.TLP_TrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            // 
            // PB_AlbumArt
            // 
            this.PB_AlbumArt.Image = global::Smallify.Properties.Resources.icon_smallify;
            this.PB_AlbumArt.Location = new System.Drawing.Point(0, 0);
            this.PB_AlbumArt.Margin = new System.Windows.Forms.Padding(0);
            this.PB_AlbumArt.Name = "PB_AlbumArt";
            this.PB_AlbumArt.Size = new System.Drawing.Size(100, 100);
            this.PB_AlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_AlbumArt.TabIndex = 1;
            this.PB_AlbumArt.TabStop = false;
            this.PB_AlbumArt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            // 
            // Btn_Previous
            // 
            this.Btn_Previous.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_Previous.Image = global::Smallify.Properties.Resources.previous_default;
            this.Btn_Previous.Location = new System.Drawing.Point(0, 8);
            this.Btn_Previous.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Btn_Previous.Name = "Btn_Previous";
            this.Btn_Previous.Size = new System.Drawing.Size(32, 32);
            this.Btn_Previous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Btn_Previous.TabIndex = 4;
            this.Btn_Previous.TabStop = false;
            this.Btn_Previous.Click += new System.EventHandler(this.Btn_Previous_Click);
            this.Btn_Previous.MouseEnter += new System.EventHandler(this.Btn_Previous_MouseEnter);
            this.Btn_Previous.MouseLeave += new System.EventHandler(this.Btn_Previous_MouseLeave);
            // 
            // Btn_PlayPause
            // 
            this.Btn_PlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_PlayPause.Image = global::Smallify.Properties.Resources.pause_default;
            this.Btn_PlayPause.Location = new System.Drawing.Point(42, 0);
            this.Btn_PlayPause.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_PlayPause.Name = "Btn_PlayPause";
            this.Btn_PlayPause.Size = new System.Drawing.Size(48, 48);
            this.Btn_PlayPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Btn_PlayPause.TabIndex = 5;
            this.Btn_PlayPause.TabStop = false;
            this.Btn_PlayPause.Click += new System.EventHandler(this.Btn_PlayPause_Click);
            this.Btn_PlayPause.MouseEnter += new System.EventHandler(this.Btn_PlayPause_MouseEnter);
            this.Btn_PlayPause.MouseLeave += new System.EventHandler(this.Btn_PlayPause_MouseLeave);
            // 
            // Btn_Next
            // 
            this.Btn_Next.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Btn_Next.Image = global::Smallify.Properties.Resources.skip_default;
            this.Btn_Next.Location = new System.Drawing.Point(100, 8);
            this.Btn_Next.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(32, 32);
            this.Btn_Next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Btn_Next.TabIndex = 6;
            this.Btn_Next.TabStop = false;
            this.Btn_Next.Click += new System.EventHandler(this.Btn_Next_Click);
            this.Btn_Next.MouseEnter += new System.EventHandler(this.Btn_Next_MouseEnter);
            this.Btn_Next.MouseLeave += new System.EventHandler(this.Btn_Next_MouseLeave);
            // 
            // FLP_MediaControls
            // 
            this.FLP_MediaControls.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FLP_MediaControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_MediaControls.Controls.Add(this.Btn_Previous);
            this.FLP_MediaControls.Controls.Add(this.Btn_PlayPause);
            this.FLP_MediaControls.Controls.Add(this.Btn_Next);
            this.FLP_MediaControls.Location = new System.Drawing.Point(731, 26);
            this.FLP_MediaControls.Name = "FLP_MediaControls";
            this.FLP_MediaControls.Size = new System.Drawing.Size(132, 48);
            this.FLP_MediaControls.TabIndex = 7;
            // 
            // FLP_TrackInformation
            // 
            this.FLP_TrackInformation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FLP_TrackInformation.AutoSize = true;
            this.FLP_TrackInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_TrackInformation.Controls.Add(this.Label_Track);
            this.FLP_TrackInformation.Controls.Add(this.Label_Artist);
            this.FLP_TrackInformation.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP_TrackInformation.Location = new System.Drawing.Point(100, 30);
            this.FLP_TrackInformation.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_TrackInformation.Name = "FLP_TrackInformation";
            this.FLP_TrackInformation.Size = new System.Drawing.Size(59, 40);
            this.FLP_TrackInformation.TabIndex = 8;
            // 
            // Label_Track
            // 
            this.Label_Track.AutoSize = true;
            this.Label_Track.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Track.ForeColor = System.Drawing.Color.White;
            this.Label_Track.Location = new System.Drawing.Point(3, 0);
            this.Label_Track.Name = "Label_Track";
            this.Label_Track.Size = new System.Drawing.Size(53, 20);
            this.Label_Track.TabIndex = 1;
            this.Label_Track.Text = "Track";
            this.Label_Track.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Artist
            // 
            this.Label_Artist.AutoSize = true;
            this.Label_Artist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Artist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.Label_Artist.Location = new System.Drawing.Point(3, 20);
            this.Label_Artist.Name = "Label_Artist";
            this.Label_Artist.Size = new System.Drawing.Size(46, 20);
            this.Label_Artist.TabIndex = 1;
            this.Label_Artist.Text = "Artist";
            this.Label_Artist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Exit.Image = global::Smallify.Properties.Resources.close_default;
            this.Btn_Exit.Location = new System.Drawing.Point(866, 3);
            this.Btn_Exit.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(16, 16);
            this.Btn_Exit.TabIndex = 11;
            this.Btn_Exit.TabStop = false;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            this.Btn_Exit.MouseEnter += new System.EventHandler(this.Btn_Exit_MouseEnter);
            this.Btn_Exit.MouseLeave += new System.EventHandler(this.Btn_Exit_MouseLeave);
            // 
            // Player_Bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(885, 375);
            this.Controls.Add(this.TLP_TrackBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Player_Bar";
            this.Text = "Smallify";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            this.TLP_TrackBar.ResumeLayout(false);
            this.TLP_TrackBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_AlbumArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Previous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_PlayPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Next)).EndInit();
            this.FLP_MediaControls.ResumeLayout(false);
            this.FLP_TrackInformation.ResumeLayout(false);
            this.FLP_TrackInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Timer_Update;
        private System.Windows.Forms.TableLayoutPanel TLP_TrackBar;
        private System.Windows.Forms.PictureBox PB_AlbumArt;
        private System.Windows.Forms.PictureBox Btn_Previous;
        private System.Windows.Forms.PictureBox Btn_PlayPause;
        private System.Windows.Forms.PictureBox Btn_Next;
        private System.Windows.Forms.FlowLayoutPanel FLP_MediaControls;
        private System.Windows.Forms.FlowLayoutPanel FLP_TrackInformation;
        private System.Windows.Forms.Label Label_Track;
        private System.Windows.Forms.Label Label_Artist;
        private System.Windows.Forms.PictureBox Btn_Exit;
    }
}