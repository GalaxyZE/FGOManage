namespace FateGrandOrder_Data_Helper
{
    partial class FormCommandCard
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
            this.pic_CommandBuster = new System.Windows.Forms.PictureBox();
            this.pic_CommandArts = new System.Windows.Forms.PictureBox();
            this.pic_CommandQuick = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CommandBuster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CommandArts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CommandQuick)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_CommandBuster
            // 
            this.pic_CommandBuster.Location = new System.Drawing.Point(10, 12);
            this.pic_CommandBuster.Name = "pic_CommandBuster";
            this.pic_CommandBuster.Size = new System.Drawing.Size(70, 70);
            this.pic_CommandBuster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_CommandBuster.TabIndex = 0;
            this.pic_CommandBuster.TabStop = false;
            this.pic_CommandBuster.Click += new System.EventHandler(this.pic_CommandBuster_Click);
            // 
            // pic_CommandArts
            // 
            this.pic_CommandArts.Location = new System.Drawing.Point(110, 12);
            this.pic_CommandArts.Name = "pic_CommandArts";
            this.pic_CommandArts.Size = new System.Drawing.Size(70, 70);
            this.pic_CommandArts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_CommandArts.TabIndex = 1;
            this.pic_CommandArts.TabStop = false;
            this.pic_CommandArts.Click += new System.EventHandler(this.pic_CommandArts_Click);
            // 
            // pic_CommandQuick
            // 
            this.pic_CommandQuick.Location = new System.Drawing.Point(210, 12);
            this.pic_CommandQuick.Name = "pic_CommandQuick";
            this.pic_CommandQuick.Size = new System.Drawing.Size(70, 70);
            this.pic_CommandQuick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_CommandQuick.TabIndex = 2;
            this.pic_CommandQuick.TabStop = false;
            this.pic_CommandQuick.Click += new System.EventHandler(this.pic_CommandQuick_Click);
            // 
            // FormCommandCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 97);
            this.Controls.Add(this.pic_CommandQuick);
            this.Controls.Add(this.pic_CommandArts);
            this.Controls.Add(this.pic_CommandBuster);
            this.Name = "FormCommandCard";
            this.Text = "FormCommandCard";
            this.Load += new System.EventHandler(this.FormCommandCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_CommandBuster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CommandArts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CommandQuick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_CommandBuster;
        private System.Windows.Forms.PictureBox pic_CommandArts;
        private System.Windows.Forms.PictureBox pic_CommandQuick;
    }
}