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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblTrack = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pbtnPrevious = new System.Windows.Forms.PictureBox();
            this.pbtnPause = new System.Windows.Forms.PictureBox();
            this.pbtnSkip = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblArtist = new System.Windows.Forms.Label();
            this.pBoxPlayBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSkip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPlayBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = true;
            this.lblTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrack.ForeColor = System.Drawing.Color.White;
            this.lblTrack.Location = new System.Drawing.Point(96, 145);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(53, 20);
            this.lblTrack.TabIndex = 1;
            this.lblTrack.Text = "Track";
            this.lblTrack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(418, 206);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pbtnPrevious
            // 
            this.pbtnPrevious.Image = global::Smallify.Properties.Resources.previous_default;
            this.pbtnPrevious.Location = new System.Drawing.Point(521, 161);
            this.pbtnPrevious.Name = "pbtnPrevious";
            this.pbtnPrevious.Size = new System.Drawing.Size(32, 32);
            this.pbtnPrevious.TabIndex = 3;
            this.pbtnPrevious.TabStop = false;
            this.pbtnPrevious.Click += new System.EventHandler(this.pbtnPrevious_Click);
            this.pbtnPrevious.MouseEnter += new System.EventHandler(this.pbtnPrevious_MouseHover);
            this.pbtnPrevious.MouseLeave += new System.EventHandler(this.pbtnPrevious_MouseLeave);
            // 
            // pbtnPause
            // 
            this.pbtnPause.Image = global::Smallify.Properties.Resources.pause_default;
            this.pbtnPause.Location = new System.Drawing.Point(559, 145);
            this.pbtnPause.Name = "pbtnPause";
            this.pbtnPause.Size = new System.Drawing.Size(48, 48);
            this.pbtnPause.TabIndex = 3;
            this.pbtnPause.TabStop = false;
            this.pbtnPause.Click += new System.EventHandler(this.pbtnPause_Click);
            this.pbtnPause.MouseEnter += new System.EventHandler(this.pbtnPause_MouseHover);
            this.pbtnPause.MouseLeave += new System.EventHandler(this.pbtnPause_MouseLeave);
            // 
            // pbtnSkip
            // 
            this.pbtnSkip.Image = global::Smallify.Properties.Resources.skip_default;
            this.pbtnSkip.Location = new System.Drawing.Point(613, 161);
            this.pbtnSkip.Name = "pbtnSkip";
            this.pbtnSkip.Size = new System.Drawing.Size(32, 32);
            this.pbtnSkip.TabIndex = 3;
            this.pbtnSkip.TabStop = false;
            this.pbtnSkip.Click += new System.EventHandler(this.pbtnSkip_Click);
            this.pbtnSkip.MouseEnter += new System.EventHandler(this.pbtnSkip_MouseHover);
            this.pbtnSkip.MouseLeave += new System.EventHandler(this.pbtnSkip_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Smallify.Properties.Resources.icon_smallify;
            this.pictureBox1.Location = new System.Drawing.Point(26, 145);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblArtist.Location = new System.Drawing.Point(96, 173);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(46, 20);
            this.lblArtist.TabIndex = 1;
            this.lblArtist.Text = "Artist";
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBoxPlayBar
            // 
            this.pBoxPlayBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.pBoxPlayBar.Location = new System.Drawing.Point(270, 12);
            this.pBoxPlayBar.Name = "pBoxPlayBar";
            this.pBoxPlayBar.Size = new System.Drawing.Size(632, 20);
            this.pBoxPlayBar.TabIndex = 6;
            this.pBoxPlayBar.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(949, 261);
            this.Controls.Add(this.pBoxPlayBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbtnPrevious);
            this.Controls.Add(this.pbtnPause);
            this.Controls.Add(this.pbtnSkip);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblTrack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Smallify";
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSkip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPlayBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox pbtnSkip;
        private System.Windows.Forms.PictureBox pbtnPrevious;
        private System.Windows.Forms.PictureBox pbtnPause;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.PictureBox pBoxPlayBar;
    }
}

