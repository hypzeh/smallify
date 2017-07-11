namespace Smallify
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pbtnSkip = new System.Windows.Forms.PictureBox();
            this.pbtnPrevious = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSkip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrevious)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
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
            // pbtnSkip
            // 
            this.pbtnSkip.Image = global::Smallify.Properties.Resources.skip_default;
            this.pbtnSkip.Location = new System.Drawing.Point(648, 82);
            this.pbtnSkip.Name = "pbtnSkip";
            this.pbtnSkip.Size = new System.Drawing.Size(32, 32);
            this.pbtnSkip.TabIndex = 3;
            this.pbtnSkip.TabStop = false;
            this.pbtnSkip.Click += new System.EventHandler(this.pbtnSkip_Click);
            this.pbtnSkip.MouseLeave += new System.EventHandler(this.pbtnSkip_MouseLeave);
            this.pbtnSkip.MouseHover += new System.EventHandler(this.pbtnSkip_MouseHover);
            // 
            // pbtnPrevious
            // 
            this.pbtnPrevious.Image = global::Smallify.Properties.Resources.previous_default;
            this.pbtnPrevious.Location = new System.Drawing.Point(512, 82);
            this.pbtnPrevious.Name = "pbtnPrevious";
            this.pbtnPrevious.Size = new System.Drawing.Size(32, 32);
            this.pbtnPrevious.TabIndex = 3;
            this.pbtnPrevious.TabStop = false;
            this.pbtnPrevious.Click += new System.EventHandler(this.pbtnPrevious_Click);
            this.pbtnPrevious.MouseLeave += new System.EventHandler(this.pbtnPrevious_MouseLeave);
            this.pbtnPrevious.MouseHover += new System.EventHandler(this.pbtnPrevious_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(949, 261);
            this.Controls.Add(this.pbtnPrevious);
            this.Controls.Add(this.pbtnSkip);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSkip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrevious)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox pbtnSkip;
        private System.Windows.Forms.PictureBox pbtnPrevious;
    }
}

