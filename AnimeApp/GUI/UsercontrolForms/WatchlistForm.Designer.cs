namespace AnimeApp.GUI.Forms
{
    partial class WatchlistForm
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
            this.lblThuVien = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblThuVien
            // 
            this.lblThuVien.AutoSize = true;
            this.lblThuVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThuVien.ForeColor = System.Drawing.Color.White;
            this.lblThuVien.Location = new System.Drawing.Point(13, 9);
            this.lblThuVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThuVien.Name = "lblThuVien";
            this.lblThuVien.Size = new System.Drawing.Size(104, 21);
            this.lblThuVien.TabIndex = 1;
            this.lblThuVien.Text = "Tủ phim của";
            // 
            // WatchlistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(711, 718);
            this.Controls.Add(this.lblThuVien);
            this.Name = "WatchlistForm";
            this.Text = "WatchlistForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThuVien;
    }
}