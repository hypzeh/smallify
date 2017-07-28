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
            this.Btn_Exit = new System.Windows.Forms.PictureBox();
            this.FLP_TrackInformation = new System.Windows.Forms.FlowLayoutPanel();
            this.Label_Track = new System.Windows.Forms.Label();
            this.Label_Artist = new System.Windows.Forms.Label();
            this.PB_AlbumArt = new System.Windows.Forms.PictureBox();
            this.FLP_MediaControls = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Previous = new System.Windows.Forms.PictureBox();
            this.Btn_PlayPause = new System.Windows.Forms.PictureBox();
            this.Btn_Skip = new System.Windows.Forms.PictureBox();
            this.FLP_ProgressBar = new System.Windows.Forms.FlowLayoutPanel();
            this.PB_ProgressBar = new System.Windows.Forms.PictureBox();
            this.Context_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMenu_Item1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TLP_TrackBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Exit)).BeginInit();
            this.FLP_TrackInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_AlbumArt)).BeginInit();
            this.FLP_MediaControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Previous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_PlayPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Skip)).BeginInit();
            this.FLP_ProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ProgressBar)).BeginInit();
            this.Context_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer_Update
            // 
            this.Timer_Update.Interval = 1000;
            this.Timer_Update.Tick += new System.EventHandler(this.Timer_Update_Tick);
            // 
            // TLP_TrackBar
            // 
            this.TLP_TrackBar.AutoSize = true;
            this.TLP_TrackBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLP_TrackBar.ColumnCount = 5;
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.TLP_TrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_TrackBar.Controls.Add(this.Btn_Exit, 4, 0);
            this.TLP_TrackBar.Controls.Add(this.FLP_TrackInformation, 1, 0);
            this.TLP_TrackBar.Controls.Add(this.PB_AlbumArt, 0, 0);
            this.TLP_TrackBar.Controls.Add(this.FLP_MediaControls, 3, 0);
            this.TLP_TrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_TrackBar.Location = new System.Drawing.Point(0, 0);
            this.TLP_TrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_TrackBar.Name = "TLP_TrackBar";
            this.TLP_TrackBar.RowCount = 1;
            this.TLP_TrackBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_TrackBar.Size = new System.Drawing.Size(520, 53);
            this.TLP_TrackBar.TabIndex = 0;
            this.TLP_TrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Exit.Image = global::Smallify.Properties.Resources.close_default;
            this.Btn_Exit.Location = new System.Drawing.Point(500, 3);
            this.Btn_Exit.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(17, 16);
            this.Btn_Exit.TabIndex = 11;
            this.Btn_Exit.TabStop = false;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            this.Btn_Exit.MouseEnter += new System.EventHandler(this.Btn_Exit_MouseEnter);
            this.Btn_Exit.MouseLeave += new System.EventHandler(this.Btn_Exit_MouseLeave);
            // 
            // FLP_TrackInformation
            // 
            this.FLP_TrackInformation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FLP_TrackInformation.AutoSize = true;
            this.FLP_TrackInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_TrackInformation.Controls.Add(this.Label_Track);
            this.FLP_TrackInformation.Controls.Add(this.Label_Artist);
            this.FLP_TrackInformation.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP_TrackInformation.Location = new System.Drawing.Point(63, 6);
            this.FLP_TrackInformation.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_TrackInformation.Name = "FLP_TrackInformation";
            this.FLP_TrackInformation.Size = new System.Drawing.Size(59, 40);
            this.FLP_TrackInformation.TabIndex = 8;
            this.FLP_TrackInformation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
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
            this.Label_Track.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
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
            this.Label_Artist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            // 
            // PB_AlbumArt
            // 
            this.PB_AlbumArt.Dock = System.Windows.Forms.DockStyle.Left;
            this.PB_AlbumArt.Image = global::Smallify.Properties.Resources.icon_smallify;
            this.PB_AlbumArt.InitialImage = global::Smallify.Properties.Resources.icon_smallify;
            this.PB_AlbumArt.Location = new System.Drawing.Point(0, 0);
            this.PB_AlbumArt.Margin = new System.Windows.Forms.Padding(0);
            this.PB_AlbumArt.Name = "PB_AlbumArt";
            this.PB_AlbumArt.Size = new System.Drawing.Size(63, 53);
            this.PB_AlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_AlbumArt.TabIndex = 1;
            this.PB_AlbumArt.TabStop = false;
            this.PB_AlbumArt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            // 
            // FLP_MediaControls
            // 
            this.FLP_MediaControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FLP_MediaControls.AutoSize = true;
            this.FLP_MediaControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_MediaControls.Controls.Add(this.Btn_Previous);
            this.FLP_MediaControls.Controls.Add(this.Btn_PlayPause);
            this.FLP_MediaControls.Controls.Add(this.Btn_Skip);
            this.FLP_MediaControls.Location = new System.Drawing.Point(363, 3);
            this.FLP_MediaControls.Name = "FLP_MediaControls";
            this.FLP_MediaControls.Size = new System.Drawing.Size(134, 47);
            this.FLP_MediaControls.TabIndex = 7;
            // 
            // Btn_Previous
            // 
            this.Btn_Previous.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Previous.Image = global::Smallify.Properties.Resources.previous_default;
            this.Btn_Previous.Location = new System.Drawing.Point(0, 0);
            this.Btn_Previous.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Btn_Previous.Name = "Btn_Previous";
            this.Btn_Previous.Size = new System.Drawing.Size(32, 48);
            this.Btn_Previous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Previous.TabIndex = 4;
            this.Btn_Previous.TabStop = false;
            this.Btn_Previous.Click += new System.EventHandler(this.Btn_Previous_Click);
            this.Btn_Previous.MouseEnter += new System.EventHandler(this.Btn_Previous_MouseEnter);
            this.Btn_Previous.MouseLeave += new System.EventHandler(this.Btn_Previous_MouseLeave);
            // 
            // Btn_PlayPause
            // 
            this.Btn_PlayPause.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_PlayPause.Image = global::Smallify.Properties.Resources.pause_default;
            this.Btn_PlayPause.Location = new System.Drawing.Point(42, 0);
            this.Btn_PlayPause.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_PlayPause.Name = "Btn_PlayPause";
            this.Btn_PlayPause.Size = new System.Drawing.Size(48, 48);
            this.Btn_PlayPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_PlayPause.TabIndex = 5;
            this.Btn_PlayPause.TabStop = false;
            this.Btn_PlayPause.Click += new System.EventHandler(this.Btn_PlayPause_Click);
            this.Btn_PlayPause.MouseEnter += new System.EventHandler(this.Btn_PlayPause_MouseEnter);
            this.Btn_PlayPause.MouseLeave += new System.EventHandler(this.Btn_PlayPause_MouseLeave);
            // 
            // Btn_Skip
            // 
            this.Btn_Skip.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Skip.Image = global::Smallify.Properties.Resources.skip_default;
            this.Btn_Skip.Location = new System.Drawing.Point(100, 0);
            this.Btn_Skip.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Btn_Skip.Name = "Btn_Skip";
            this.Btn_Skip.Size = new System.Drawing.Size(32, 48);
            this.Btn_Skip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Skip.TabIndex = 6;
            this.Btn_Skip.TabStop = false;
            this.Btn_Skip.Click += new System.EventHandler(this.Btn_Skip_Click);
            this.Btn_Skip.MouseEnter += new System.EventHandler(this.Btn_Skip_MouseEnter);
            this.Btn_Skip.MouseLeave += new System.EventHandler(this.Btn_Skip_MouseLeave);
            // 
            // FLP_ProgressBar
            // 
            this.FLP_ProgressBar.AutoSize = true;
            this.FLP_ProgressBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_ProgressBar.Controls.Add(this.PB_ProgressBar);
            this.FLP_ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FLP_ProgressBar.Location = new System.Drawing.Point(0, 53);
            this.FLP_ProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_ProgressBar.Name = "FLP_ProgressBar";
            this.FLP_ProgressBar.Size = new System.Drawing.Size(520, 5);
            this.FLP_ProgressBar.TabIndex = 10;
            // 
            // PB_ProgressBar
            // 
            this.PB_ProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.PB_ProgressBar.Location = new System.Drawing.Point(0, 0);
            this.PB_ProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.PB_ProgressBar.Name = "PB_ProgressBar";
            this.PB_ProgressBar.Size = new System.Drawing.Size(10, 5);
            this.PB_ProgressBar.TabIndex = 6;
            this.PB_ProgressBar.TabStop = false;
            // 
            // Context_Menu
            // 
            this.Context_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMenu_Item1});
            this.Context_Menu.Name = "cMenuMain";
            this.Context_Menu.Size = new System.Drawing.Size(150, 26);
            // 
            // CMenu_Item1
            // 
            this.CMenu_Item1.Checked = true;
            this.CMenu_Item1.CheckOnClick = true;
            this.CMenu_Item1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CMenu_Item1.Name = "CMenu_Item1";
            this.CMenu_Item1.Size = new System.Drawing.Size(149, 22);
            this.CMenu_Item1.Text = "Always on top";
            this.CMenu_Item1.Click += new System.EventHandler(this.CMenu_Item1_Click);
            // 
            // Player_Bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(520, 58);
            this.ContextMenuStrip = this.Context_Menu;
            this.Controls.Add(this.TLP_TrackBar);
            this.Controls.Add(this.FLP_ProgressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(3000, 100);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 58);
            this.Name = "Player_Bar";
            this.Text = "Smallify";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Player_Bar_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            this.Resize += new System.EventHandler(this.Player_Bar_Resize);
            this.TLP_TrackBar.ResumeLayout(false);
            this.TLP_TrackBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Exit)).EndInit();
            this.FLP_TrackInformation.ResumeLayout(false);
            this.FLP_TrackInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_AlbumArt)).EndInit();
            this.FLP_MediaControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Previous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_PlayPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Skip)).EndInit();
            this.FLP_ProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_ProgressBar)).EndInit();
            this.Context_Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Timer_Update;
        private System.Windows.Forms.TableLayoutPanel TLP_TrackBar;
        private System.Windows.Forms.PictureBox PB_AlbumArt;
        private System.Windows.Forms.PictureBox Btn_Previous;
        private System.Windows.Forms.PictureBox Btn_PlayPause;
        private System.Windows.Forms.PictureBox Btn_Skip;
        private System.Windows.Forms.FlowLayoutPanel FLP_MediaControls;
        private System.Windows.Forms.FlowLayoutPanel FLP_TrackInformation;
        private System.Windows.Forms.Label Label_Track;
        private System.Windows.Forms.Label Label_Artist;
        private System.Windows.Forms.PictureBox Btn_Exit;
        private System.Windows.Forms.FlowLayoutPanel FLP_ProgressBar;
        private System.Windows.Forms.PictureBox PB_ProgressBar;
        private System.Windows.Forms.ContextMenuStrip Context_Menu;
        private System.Windows.Forms.ToolStripMenuItem CMenu_Item1;
    }
}