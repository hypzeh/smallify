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
            this.FLP_ProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ProgressBar)).BeginInit();
            this.Context_Menu.SuspendLayout();
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
            this.playerToolStripMenuItem});
            this.Context_Menu.Name = "cMenuMain";
            this.Context_Menu.Size = new System.Drawing.Size(153, 70);
            // 
            // aotToolStripMenuItem
            // 
            this.aotToolStripMenuItem.Checked = true;
            this.aotToolStripMenuItem.CheckOnClick = true;
            this.aotToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aotToolStripMenuItem.Name = "aotToolStripMenuItem";
            this.aotToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aotToolStripMenuItem.Text = "Always on top";
            this.aotToolStripMenuItem.Click += new System.EventHandler(this.aotToolStripMenuItem_Click);
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barToolStripMenuItem,
            this.albumToolStripMenuItem});
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playerToolStripMenuItem.Text = "Player";
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.albumToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.albumToolStripMenuItem.Text = "Album";
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
            this.Controls.Add(this.FLP_ProgressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "Player_Album";
            this.Text = "Player_Album";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Player_Album_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForm_MouseDown);
            this.Resize += new System.EventHandler(this.Player_Album_Resize);
            this.FLP_ProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_ProgressBar)).EndInit();
            this.Context_Menu.ResumeLayout(false);
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
    }
}