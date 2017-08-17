namespace Smallify
{
    partial class Player_Album
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
            this.FLP_ProgressBar = new System.Windows.Forms.FlowLayoutPanel();
            this.PB_ProgressBar = new System.Windows.Forms.PictureBox();
            this.Timer_Update = new System.Windows.Forms.Timer(this.components);
            this.Context_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.albumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FLP_MediaControls = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Previous = new System.Windows.Forms.PictureBox();
            this.Btn_PlayPause = new System.Windows.Forms.PictureBox();
            this.Btn_Skip = new System.Windows.Forms.PictureBox();
            this.TLP_MediaControls = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FLP_ProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ProgressBar)).BeginInit();
            this.Context_Menu.SuspendLayout();
            this.FLP_MediaControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Previous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_PlayPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Skip)).BeginInit();
            this.TLP_MediaControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLP_ProgressBar
            // 
            this.FLP_ProgressBar.AutoSize = true;
            this.FLP_ProgressBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FLP_ProgressBar.Controls.Add(this.PB_ProgressBar);
            this.FLP_ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FLP_ProgressBar.Location = new System.Drawing.Point(0, 195);
            this.FLP_ProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_ProgressBar.Name = "FLP_ProgressBar";
            this.FLP_ProgressBar.Size = new System.Drawing.Size(200, 5);
            this.FLP_ProgressBar.TabIndex = 11;
            this.FLP_ProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
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
            this.PB_ProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            // 
            // Timer_Update
            // 
            this.Timer_Update.Interval = 1000;
            this.Timer_Update.Tick += new System.EventHandler(this.Timer_Update_Tick);
            // 
            // Context_Menu
            // 
            this.Context_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aotToolStripMenuItem,
            this.playerToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.Context_Menu.Name = "cMenuMain";
            this.Context_Menu.Size = new System.Drawing.Size(153, 98);
            // 
            // aotToolStripMenuItem
            // 
            this.aotToolStripMenuItem.Checked = true;
            this.aotToolStripMenuItem.CheckOnClick = true;
            this.aotToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aotToolStripMenuItem.Name = "aotToolStripMenuItem";
            this.aotToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aotToolStripMenuItem.Text = "Always on top";
            this.aotToolStripMenuItem.Click += new System.EventHandler(this.aotToolStripMenuItem_Click);
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barToolStripMenuItem,
            this.albumToolStripMenuItem});
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.playerToolStripMenuItem.Text = "Player";
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.barToolStripMenuItem.Text = "Bar";
            this.barToolStripMenuItem.Click += new System.EventHandler(this.barToolStripMenuItem_Click);
            // 
            // albumToolStripMenuItem
            // 
            this.albumToolStripMenuItem.Checked = true;
            this.albumToolStripMenuItem.CheckOnClick = true;
            this.albumToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.albumToolStripMenuItem.Enabled = false;
            this.albumToolStripMenuItem.Name = "albumToolStripMenuItem";
            this.albumToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.albumToolStripMenuItem.Text = "Album";
            // 
            // FLP_MediaControls
            // 
            this.FLP_MediaControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FLP_MediaControls.BackColor = System.Drawing.Color.Transparent;
            this.FLP_MediaControls.Controls.Add(this.Btn_Previous);
            this.FLP_MediaControls.Controls.Add(this.Btn_PlayPause);
            this.FLP_MediaControls.Controls.Add(this.Btn_Skip);
            this.FLP_MediaControls.Location = new System.Drawing.Point(33, 0);
            this.FLP_MediaControls.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_MediaControls.Name = "FLP_MediaControls";
            this.FLP_MediaControls.Size = new System.Drawing.Size(134, 47);
            this.FLP_MediaControls.TabIndex = 12;
            this.FLP_MediaControls.MouseEnter += new System.EventHandler(this.Player_Album_MouseEnter);
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
            this.Btn_Previous.Visible = false;
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
            this.Btn_PlayPause.Visible = false;
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
            this.Btn_Skip.Visible = false;
            this.Btn_Skip.Click += new System.EventHandler(this.Btn_Skip_Click);
            this.Btn_Skip.MouseEnter += new System.EventHandler(this.Btn_Skip_MouseEnter);
            this.Btn_Skip.MouseLeave += new System.EventHandler(this.Btn_Skip_MouseLeave);
            // 
            // TLP_MediaControls
            // 
            this.TLP_MediaControls.AutoSize = true;
            this.TLP_MediaControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLP_MediaControls.BackColor = System.Drawing.Color.Transparent;
            this.TLP_MediaControls.ColumnCount = 3;
            this.TLP_MediaControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_MediaControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP_MediaControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_MediaControls.Controls.Add(this.FLP_MediaControls, 1, 0);
            this.TLP_MediaControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TLP_MediaControls.Location = new System.Drawing.Point(0, 148);
            this.TLP_MediaControls.Name = "TLP_MediaControls";
            this.TLP_MediaControls.RowCount = 1;
            this.TLP_MediaControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_MediaControls.Size = new System.Drawing.Size(200, 47);
            this.TLP_MediaControls.TabIndex = 13;
            this.TLP_MediaControls.MouseEnter += new System.EventHandler(this.Player_Album_MouseEnter);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Player_Album
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImage = global::Smallify.Properties.Resources.icon_smallify;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.ContextMenuStrip = this.Context_Menu;
            this.Controls.Add(this.TLP_MediaControls);
            this.Controls.Add(this.FLP_ProgressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(140, 140);
            this.Name = "Player_Album";
            this.Text = "Player_Album";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Player_Album_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Player_Album_MouseEnter);
            this.Resize += new System.EventHandler(this.Player_Album_Resize);
            this.FLP_ProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_ProgressBar)).EndInit();
            this.Context_Menu.ResumeLayout(false);
            this.FLP_MediaControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Previous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_PlayPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Skip)).EndInit();
            this.TLP_MediaControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FLP_ProgressBar;
        private System.Windows.Forms.PictureBox PB_ProgressBar;
        private System.Windows.Forms.Timer Timer_Update;
        private System.Windows.Forms.ContextMenuStrip Context_Menu;
        private System.Windows.Forms.ToolStripMenuItem aotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem albumToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel FLP_MediaControls;
        private System.Windows.Forms.PictureBox Btn_Previous;
        private System.Windows.Forms.PictureBox Btn_PlayPause;
        private System.Windows.Forms.PictureBox Btn_Skip;
        private System.Windows.Forms.TableLayoutPanel TLP_MediaControls;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}