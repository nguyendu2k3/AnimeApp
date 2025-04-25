namespace AnimeApp.GUI.Forms
{
    partial class AnimeDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimeDetailForm));
            this.animeDetailsPanel = new System.Windows.Forms.Panel();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThemVaoDanhSach = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DanhGia = new System.Windows.Forms.Label();
            this.TrangThai = new System.Windows.Forms.Label();
            this.Studio = new System.Windows.Forms.Label();
            this.SoTap = new System.Windows.Forms.Label();
            this.NgayPhatHanh = new System.Windows.Forms.Label();
            this.TheLoai = new System.Windows.Forms.Label();
            this.lblTenAnimeJapanDeltail = new System.Windows.Forms.Label();
            this.TenAnimeDetail = new System.Windows.Forms.Label();
            this.picAnimeDetail = new System.Windows.Forms.PictureBox();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.animeDetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimeDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // animeDetailsPanel
            // 
            this.animeDetailsPanel.AutoScroll = true;
            this.animeDetailsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.animeDetailsPanel.Controls.Add(this.txtMoTa);
            this.animeDetailsPanel.Controls.Add(this.btnThemVaoDanhSach);
            this.animeDetailsPanel.Controls.Add(this.btnQuayLai);
            this.animeDetailsPanel.Controls.Add(this.btnXem);
            this.animeDetailsPanel.Controls.Add(this.label16);
            this.animeDetailsPanel.Controls.Add(this.label15);
            this.animeDetailsPanel.Controls.Add(this.label14);
            this.animeDetailsPanel.Controls.Add(this.label13);
            this.animeDetailsPanel.Controls.Add(this.label12);
            this.animeDetailsPanel.Controls.Add(this.label8);
            this.animeDetailsPanel.Controls.Add(this.label7);
            this.animeDetailsPanel.Controls.Add(this.label6);
            this.animeDetailsPanel.Controls.Add(this.label9);
            this.animeDetailsPanel.Controls.Add(this.DanhGia);
            this.animeDetailsPanel.Controls.Add(this.TrangThai);
            this.animeDetailsPanel.Controls.Add(this.Studio);
            this.animeDetailsPanel.Controls.Add(this.SoTap);
            this.animeDetailsPanel.Controls.Add(this.NgayPhatHanh);
            this.animeDetailsPanel.Controls.Add(this.TheLoai);
            this.animeDetailsPanel.Controls.Add(this.lblTenAnimeJapanDeltail);
            this.animeDetailsPanel.Controls.Add(this.TenAnimeDetail);
            this.animeDetailsPanel.Controls.Add(this.picAnimeDetail);
            this.animeDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animeDetailsPanel.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.animeDetailsPanel.Location = new System.Drawing.Point(0, 0);
            this.animeDetailsPanel.Name = "animeDetailsPanel";
            this.animeDetailsPanel.Size = new System.Drawing.Size(701, 599);
            this.animeDetailsPanel.TabIndex = 3;
            // 
            // txtMoTa
            // 
            this.txtMoTa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(44)))));
            this.txtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMoTa.ForeColor = System.Drawing.Color.White;
            this.txtMoTa.Location = new System.Drawing.Point(273, 352);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(400, 205);
            this.txtMoTa.TabIndex = 26;
            // 
            // btnThemVaoDanhSach
            // 
            this.btnThemVaoDanhSach.BackColor = System.Drawing.Color.SeaGreen;
            this.btnThemVaoDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemVaoDanhSach.ForeColor = System.Drawing.Color.White;
            this.btnThemVaoDanhSach.Location = new System.Drawing.Point(41, 413);
            this.btnThemVaoDanhSach.Name = "btnThemVaoDanhSach";
            this.btnThemVaoDanhSach.Size = new System.Drawing.Size(160, 30);
            this.btnThemVaoDanhSach.TabIndex = 25;
            this.btnThemVaoDanhSach.Text = "Thêm vào danh sách";
            this.btnThemVaoDanhSach.UseVisualStyleBackColor = false;
            this.btnThemVaoDanhSach.Click += new System.EventHandler(this.btnThemVaoDanhSach_Click);
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(41, 352);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(160, 40);
            this.btnXem.TabIndex = 24;
            this.btnXem.Text = "Xem Anime";
            this.btnXem.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(269, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 21);
            this.label16.TabIndex = 22;
            this.label16.Text = "Mô tả:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(269, 290);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 21);
            this.label15.TabIndex = 21;
            this.label15.Text = "Đánh Giá";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(269, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 21);
            this.label14.TabIndex = 20;
            this.label14.Text = "Studio";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(269, 230);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 21);
            this.label13.TabIndex = 19;
            this.label13.Text = "Ngày phát hành";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(269, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 21);
            this.label12.TabIndex = 18;
            this.label12.Text = "Trạng thái";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(269, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 21);
            this.label8.TabIndex = 17;
            this.label8.Text = "Trạng thái";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(269, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "Số tập";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(269, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Thể loại";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(269, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 21);
            this.label9.TabIndex = 15;
            this.label9.Text = "Tên tiếng Nhật";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DanhGia
            // 
            this.DanhGia.AutoSize = true;
            this.DanhGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DanhGia.ForeColor = System.Drawing.Color.White;
            this.DanhGia.Location = new System.Drawing.Point(414, 290);
            this.DanhGia.Name = "DanhGia";
            this.DanhGia.Size = new System.Drawing.Size(74, 21);
            this.DanhGia.TabIndex = 14;
            this.DanhGia.Text = "Đánh Giá";
            this.DanhGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrangThai
            // 
            this.TrangThai.AutoSize = true;
            this.TrangThai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TrangThai.ForeColor = System.Drawing.Color.White;
            this.TrangThai.Location = new System.Drawing.Point(414, 200);
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Size = new System.Drawing.Size(79, 21);
            this.TrangThai.TabIndex = 13;
            this.TrangThai.Text = "Trạng thái";
            this.TrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Studio
            // 
            this.Studio.AutoSize = true;
            this.Studio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Studio.ForeColor = System.Drawing.Color.White;
            this.Studio.Location = new System.Drawing.Point(414, 258);
            this.Studio.Name = "Studio";
            this.Studio.Size = new System.Drawing.Size(54, 21);
            this.Studio.TabIndex = 12;
            this.Studio.Text = "Studio";
            this.Studio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SoTap
            // 
            this.SoTap.AutoSize = true;
            this.SoTap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.SoTap.ForeColor = System.Drawing.Color.White;
            this.SoTap.Location = new System.Drawing.Point(414, 170);
            this.SoTap.Name = "SoTap";
            this.SoTap.Size = new System.Drawing.Size(54, 21);
            this.SoTap.TabIndex = 11;
            this.SoTap.Text = "Số tập";
            this.SoTap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NgayPhatHanh
            // 
            this.NgayPhatHanh.AutoSize = true;
            this.NgayPhatHanh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NgayPhatHanh.ForeColor = System.Drawing.Color.White;
            this.NgayPhatHanh.Location = new System.Drawing.Point(414, 230);
            this.NgayPhatHanh.Name = "NgayPhatHanh";
            this.NgayPhatHanh.Size = new System.Drawing.Size(121, 21);
            this.NgayPhatHanh.TabIndex = 10;
            this.NgayPhatHanh.Text = "Ngày phát hành";
            this.NgayPhatHanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TheLoai
            // 
            this.TheLoai.AutoSize = true;
            this.TheLoai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TheLoai.ForeColor = System.Drawing.Color.White;
            this.TheLoai.Location = new System.Drawing.Point(414, 138);
            this.TheLoai.Name = "TheLoai";
            this.TheLoai.Size = new System.Drawing.Size(64, 21);
            this.TheLoai.TabIndex = 9;
            this.TheLoai.Text = "Thể loại";
            this.TheLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenAnimeJapanDeltail
            // 
            this.lblTenAnimeJapanDeltail.AutoSize = true;
            this.lblTenAnimeJapanDeltail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenAnimeJapanDeltail.ForeColor = System.Drawing.Color.White;
            this.lblTenAnimeJapanDeltail.Location = new System.Drawing.Point(414, 110);
            this.lblTenAnimeJapanDeltail.Name = "lblTenAnimeJapanDeltail";
            this.lblTenAnimeJapanDeltail.Size = new System.Drawing.Size(113, 21);
            this.lblTenAnimeJapanDeltail.TabIndex = 8;
            this.lblTenAnimeJapanDeltail.Text = "Tên tiếng Nhật:";
            this.lblTenAnimeJapanDeltail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TenAnimeDetail
            // 
            this.TenAnimeDetail.AutoSize = true;
            this.TenAnimeDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TenAnimeDetail.ForeColor = System.Drawing.Color.White;
            this.TenAnimeDetail.Location = new System.Drawing.Point(22, 55);
            this.TenAnimeDetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TenAnimeDetail.Name = "TenAnimeDetail";
            this.TenAnimeDetail.Size = new System.Drawing.Size(91, 21);
            this.TenAnimeDetail.TabIndex = 7;
            this.TenAnimeDetail.Text = "Ten Anime";
            // 
            // picAnimeDetail
            // 
            this.picAnimeDetail.Location = new System.Drawing.Point(41, 96);
            this.picAnimeDetail.Name = "picAnimeDetail";
            this.picAnimeDetail.Size = new System.Drawing.Size(160, 245);
            this.picAnimeDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnimeDetail.TabIndex = 6;
            this.picAnimeDetail.TabStop = false;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(12, 12);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(91, 28);
            this.btnQuayLai.TabIndex = 24;
            this.btnQuayLai.Text = "< Quay lại";
            this.btnQuayLai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // AnimeDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 599);
            this.Controls.Add(this.animeDetailsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnimeDetailForm";
            this.Text = "AnimeDetailsForm";
            this.animeDetailsPanel.ResumeLayout(false);
            this.animeDetailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimeDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel animeDetailsPanel;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThemVaoDanhSach;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label DanhGia;
        private System.Windows.Forms.Label TrangThai;
        private System.Windows.Forms.Label Studio;
        private System.Windows.Forms.Label SoTap;
        private System.Windows.Forms.Label NgayPhatHanh;
        private System.Windows.Forms.Label TheLoai;
        private System.Windows.Forms.Label lblTenAnimeJapanDeltail;
        private System.Windows.Forms.Label TenAnimeDetail;
        private System.Windows.Forms.PictureBox picAnimeDetail;
        private System.Windows.Forms.Button btnQuayLai;
    }
}