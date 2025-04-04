using System.Drawing;

namespace AnimeApp.GUI.Forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.btnCaiDat = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.btnThuVien = new System.Windows.Forms.Button();
            this.btnMua = new System.Windows.Forms.Button();
            this.btnTheLoai = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.animeContentPanel = new System.Windows.Forms.Panel();
            this.topAnimePanel = new System.Windows.Forms.Panel();
            this.anime4 = new System.Windows.Forms.Panel();
            this.lblTrangThai4 = new System.Windows.Forms.Label();
            this.lblTenAnime4 = new System.Windows.Forms.Label();
            this.picAnime4 = new System.Windows.Forms.PictureBox();
            this.anime3 = new System.Windows.Forms.Panel();
            this.lblTrangThai3 = new System.Windows.Forms.Label();
            this.lblTenAnime3 = new System.Windows.Forms.Label();
            this.picAnime3 = new System.Windows.Forms.PictureBox();
            this.anime2 = new System.Windows.Forms.Panel();
            this.lblTrangThai2 = new System.Windows.Forms.Label();
            this.lblTenAnime2 = new System.Windows.Forms.Label();
            this.picAnime2 = new System.Windows.Forms.PictureBox();
            this.anime1 = new System.Windows.Forms.Panel();
            this.lblTrangThai1 = new System.Windows.Forms.Label();
            this.lblTenAnime1 = new System.Windows.Forms.Label();
            this.picAnime1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.newAnimePanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTrangThaiNew1 = new System.Windows.Forms.Label();
            this.lblAnimeNew1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.topAnime = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.animeContentPanel.SuspendLayout();
            this.topAnimePanel.SuspendLayout();
            this.anime4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnime4)).BeginInit();
            this.anime3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnime3)).BeginInit();
            this.anime2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnime2)).BeginInit();
            this.anime1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnime1)).BeginInit();
            this.newAnimePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTimKiem.Location = new System.Drawing.Point(732, 12);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(20, 20);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "🔍";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.textBox1.Location = new System.Drawing.Point(350, 12);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(402, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Tìm kiếm anime...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "AnimeApp";
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.sidebarPanel.Controls.Add(this.btnCaiDat);
            this.sidebarPanel.Controls.Add(this.btnTaiKhoan);
            this.sidebarPanel.Controls.Add(this.btnLichSu);
            this.sidebarPanel.Controls.Add(this.btnThuVien);
            this.sidebarPanel.Controls.Add(this.btnMua);
            this.sidebarPanel.Controls.Add(this.btnTheLoai);
            this.sidebarPanel.Controls.Add(this.btnTrangChu);
            this.sidebarPanel.Controls.Add(this.label3);
            this.sidebarPanel.Controls.Add(this.label2);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 50);
            this.sidebarPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(198, 711);
            this.sidebarPanel.TabIndex = 1;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.btnCaiDat.FlatAppearance.BorderSize = 0;
            this.btnCaiDat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnCaiDat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnCaiDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCaiDat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCaiDat.Location = new System.Drawing.Point(14, 337);
            this.btnCaiDat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(175, 35);
            this.btnCaiDat.TabIndex = 3;
            this.btnCaiDat.Text = "Cài Đặt";
            this.btnCaiDat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaiDat.UseVisualStyleBackColor = false;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnTaiKhoan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnTaiKhoan.Location = new System.Drawing.Point(14, 296);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(175, 35);
            this.btnTaiKhoan.TabIndex = 3;
            this.btnTaiKhoan.Text = "Tài Khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            // 
            // btnLichSu
            // 
            this.btnLichSu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.btnLichSu.FlatAppearance.BorderSize = 0;
            this.btnLichSu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnLichSu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnLichSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichSu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLichSu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnLichSu.Location = new System.Drawing.Point(14, 204);
            this.btnLichSu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(175, 35);
            this.btnLichSu.TabIndex = 3;
            this.btnLichSu.Text = "Lịch sử";
            this.btnLichSu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichSu.UseVisualStyleBackColor = false;
            // 
            // btnThuVien
            // 
            this.btnThuVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.btnThuVien.FlatAppearance.BorderSize = 0;
            this.btnThuVien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnThuVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnThuVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThuVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnThuVien.Location = new System.Drawing.Point(14, 163);
            this.btnThuVien.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnThuVien.Name = "btnThuVien";
            this.btnThuVien.Size = new System.Drawing.Size(175, 35);
            this.btnThuVien.TabIndex = 3;
            this.btnThuVien.Text = "Thư viện";
            this.btnThuVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThuVien.UseVisualStyleBackColor = false;
            // 
            // btnMua
            // 
            this.btnMua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.btnMua.FlatAppearance.BorderSize = 0;
            this.btnMua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnMua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnMua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnMua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnMua.Location = new System.Drawing.Point(14, 122);
            this.btnMua.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnMua.Name = "btnMua";
            this.btnMua.Size = new System.Drawing.Size(175, 35);
            this.btnMua.TabIndex = 3;
            this.btnMua.Text = "Anime Theo Mùa";
            this.btnMua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMua.UseVisualStyleBackColor = false;
            // 
            // btnTheLoai
            // 
            this.btnTheLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.btnTheLoai.FlatAppearance.BorderSize = 0;
            this.btnTheLoai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnTheLoai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTheLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnTheLoai.Location = new System.Drawing.Point(14, 81);
            this.btnTheLoai.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTheLoai.Name = "btnTheLoai";
            this.btnTheLoai.Size = new System.Drawing.Size(175, 35);
            this.btnTheLoai.TabIndex = 3;
            this.btnTheLoai.Text = "Thể Loại";
            this.btnTheLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTheLoai.UseVisualStyleBackColor = false;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnTrangChu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTrangChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnTrangChu.Location = new System.Drawing.Point(14, 40);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(175, 35);
            this.btnTrangChu.TabIndex = 3;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(14, 262);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thiết lập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Menu";
            // 
            // animeContentPanel
            // 
            this.animeContentPanel.AutoScroll = true;
            this.animeContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(45)))));
            this.animeContentPanel.Controls.Add(this.topAnimePanel);
            this.animeContentPanel.Controls.Add(this.newAnimePanel);
            this.animeContentPanel.Controls.Add(this.topAnime);
            this.animeContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animeContentPanel.Location = new System.Drawing.Point(198, 50);
            this.animeContentPanel.Name = "animeContentPanel";
            this.animeContentPanel.Size = new System.Drawing.Size(716, 711);
            this.animeContentPanel.TabIndex = 2;
            // 
            // topAnimePanel
            // 
            this.topAnimePanel.Controls.Add(this.anime4);
            this.topAnimePanel.Controls.Add(this.anime3);
            this.topAnimePanel.Controls.Add(this.anime2);
            this.topAnimePanel.Controls.Add(this.anime1);
            this.topAnimePanel.Controls.Add(this.label4);
            this.topAnimePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topAnimePanel.Location = new System.Drawing.Point(0, 0);
            this.topAnimePanel.Name = "topAnimePanel";
            this.topAnimePanel.Size = new System.Drawing.Size(716, 359);
            this.topAnimePanel.TabIndex = 2;
            // 
            // anime4
            // 
            this.anime4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anime4.Controls.Add(this.lblTrangThai4);
            this.anime4.Controls.Add(this.lblTenAnime4);
            this.anime4.Controls.Add(this.picAnime4);
            this.anime4.Location = new System.Drawing.Point(534, 40);
            this.anime4.Name = "anime4";
            this.anime4.Size = new System.Drawing.Size(166, 306);
            this.anime4.TabIndex = 1;
            // 
            // lblTrangThai4
            // 
            this.lblTrangThai4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTrangThai4.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai4.Location = new System.Drawing.Point(1, 282);
            this.lblTrangThai4.Name = "lblTrangThai4";
            this.lblTrangThai4.Size = new System.Drawing.Size(160, 19);
            this.lblTrangThai4.TabIndex = 1;
            this.lblTrangThai4.Text = "Trạng Thái";
            this.lblTrangThai4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenAnime4
            // 
            this.lblTenAnime4.AutoEllipsis = true;
            this.lblTenAnime4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenAnime4.ForeColor = System.Drawing.Color.White;
            this.lblTenAnime4.Location = new System.Drawing.Point(3, 252);
            this.lblTenAnime4.Name = "lblTenAnime4";
            this.lblTenAnime4.Size = new System.Drawing.Size(160, 20);
            this.lblTenAnime4.TabIndex = 1;
            this.lblTenAnime4.Text = "anime";
            this.lblTenAnime4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAnime4
            // 
            this.picAnime4.Location = new System.Drawing.Point(-1, -1);
            this.picAnime4.Name = "picAnime4";
            this.picAnime4.Size = new System.Drawing.Size(166, 250);
            this.picAnime4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnime4.TabIndex = 0;
            this.picAnime4.TabStop = false;
            // 
            // anime3
            // 
            this.anime3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anime3.Controls.Add(this.lblTrangThai3);
            this.anime3.Controls.Add(this.lblTenAnime3);
            this.anime3.Controls.Add(this.picAnime3);
            this.anime3.Location = new System.Drawing.Point(356, 40);
            this.anime3.Name = "anime3";
            this.anime3.Size = new System.Drawing.Size(166, 306);
            this.anime3.TabIndex = 1;
            // 
            // lblTrangThai3
            // 
            this.lblTrangThai3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTrangThai3.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai3.Location = new System.Drawing.Point(1, 282);
            this.lblTrangThai3.Name = "lblTrangThai3";
            this.lblTrangThai3.Size = new System.Drawing.Size(160, 19);
            this.lblTrangThai3.TabIndex = 1;
            this.lblTrangThai3.Text = "Trạng Thái";
            this.lblTrangThai3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenAnime3
            // 
            this.lblTenAnime3.AutoEllipsis = true;
            this.lblTenAnime3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenAnime3.ForeColor = System.Drawing.Color.White;
            this.lblTenAnime3.Location = new System.Drawing.Point(3, 252);
            this.lblTenAnime3.Name = "lblTenAnime3";
            this.lblTenAnime3.Size = new System.Drawing.Size(160, 20);
            this.lblTenAnime3.TabIndex = 1;
            this.lblTenAnime3.Text = "anime";
            this.lblTenAnime3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAnime3
            // 
            this.picAnime3.Location = new System.Drawing.Point(-1, -1);
            this.picAnime3.Name = "picAnime3";
            this.picAnime3.Size = new System.Drawing.Size(166, 250);
            this.picAnime3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnime3.TabIndex = 0;
            this.picAnime3.TabStop = false;
            // 
            // anime2
            // 
            this.anime2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anime2.Controls.Add(this.lblTrangThai2);
            this.anime2.Controls.Add(this.lblTenAnime2);
            this.anime2.Controls.Add(this.picAnime2);
            this.anime2.Location = new System.Drawing.Point(184, 40);
            this.anime2.Name = "anime2";
            this.anime2.Size = new System.Drawing.Size(166, 306);
            this.anime2.TabIndex = 1;
            // 
            // lblTrangThai2
            // 
            this.lblTrangThai2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTrangThai2.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai2.Location = new System.Drawing.Point(1, 282);
            this.lblTrangThai2.Name = "lblTrangThai2";
            this.lblTrangThai2.Size = new System.Drawing.Size(160, 19);
            this.lblTrangThai2.TabIndex = 1;
            this.lblTrangThai2.Text = "Trạng Thái";
            this.lblTrangThai2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenAnime2
            // 
            this.lblTenAnime2.AutoEllipsis = true;
            this.lblTenAnime2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenAnime2.ForeColor = System.Drawing.Color.White;
            this.lblTenAnime2.Location = new System.Drawing.Point(3, 252);
            this.lblTenAnime2.Name = "lblTenAnime2";
            this.lblTenAnime2.Size = new System.Drawing.Size(160, 20);
            this.lblTenAnime2.TabIndex = 1;
            this.lblTenAnime2.Text = "anime";
            this.lblTenAnime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAnime2
            // 
            this.picAnime2.Location = new System.Drawing.Point(-1, -1);
            this.picAnime2.Name = "picAnime2";
            this.picAnime2.Size = new System.Drawing.Size(166, 250);
            this.picAnime2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnime2.TabIndex = 0;
            this.picAnime2.TabStop = false;
            // 
            // anime1
            // 
            this.anime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anime1.Controls.Add(this.lblTrangThai1);
            this.anime1.Controls.Add(this.lblTenAnime1);
            this.anime1.Controls.Add(this.picAnime1);
            this.anime1.Location = new System.Drawing.Point(12, 40);
            this.anime1.Name = "anime1";
            this.anime1.Size = new System.Drawing.Size(166, 306);
            this.anime1.TabIndex = 1;
            // 
            // lblTrangThai1
            // 
            this.lblTrangThai1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTrangThai1.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai1.Location = new System.Drawing.Point(1, 282);
            this.lblTrangThai1.Name = "lblTrangThai1";
            this.lblTrangThai1.Size = new System.Drawing.Size(160, 19);
            this.lblTrangThai1.TabIndex = 1;
            this.lblTrangThai1.Text = "Trạng Thái";
            this.lblTrangThai1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenAnime1
            // 
            this.lblTenAnime1.AutoEllipsis = true;
            this.lblTenAnime1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenAnime1.ForeColor = System.Drawing.Color.White;
            this.lblTenAnime1.Location = new System.Drawing.Point(3, 252);
            this.lblTenAnime1.Name = "lblTenAnime1";
            this.lblTenAnime1.Size = new System.Drawing.Size(160, 20);
            this.lblTenAnime1.TabIndex = 1;
            this.lblTenAnime1.Text = "anime";
            this.lblTenAnime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAnime1
            // 
            this.picAnime1.Location = new System.Drawing.Point(-1, -1);
            this.picAnime1.Name = "picAnime1";
            this.picAnime1.Size = new System.Drawing.Size(166, 250);
            this.picAnime1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnime1.TabIndex = 0;
            this.picAnime1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Phổ biến nhất";
            // 
            // newAnimePanel
            // 
            this.newAnimePanel.AutoScroll = true;
            this.newAnimePanel.Controls.Add(this.label5);
            this.newAnimePanel.Controls.Add(this.panel2);
            this.newAnimePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newAnimePanel.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.newAnimePanel.Location = new System.Drawing.Point(0, 359);
            this.newAnimePanel.Name = "newAnimePanel";
            this.newAnimePanel.Size = new System.Drawing.Size(716, 352);
            this.newAnimePanel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mới cập nhật";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTrangThaiNew1);
            this.panel2.Controls.Add(this.lblAnimeNew1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(12, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 306);
            this.panel2.TabIndex = 1;
            // 
            // lblTrangThaiNew1
            // 
            this.lblTrangThaiNew1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTrangThaiNew1.ForeColor = System.Drawing.Color.White;
            this.lblTrangThaiNew1.Location = new System.Drawing.Point(1, 282);
            this.lblTrangThaiNew1.Name = "lblTrangThaiNew1";
            this.lblTrangThaiNew1.Size = new System.Drawing.Size(160, 19);
            this.lblTrangThaiNew1.TabIndex = 1;
            this.lblTrangThaiNew1.Text = "Trạng Thái";
            this.lblTrangThaiNew1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnimeNew1
            // 
            this.lblAnimeNew1.AutoEllipsis = true;
            this.lblAnimeNew1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblAnimeNew1.ForeColor = System.Drawing.Color.White;
            this.lblAnimeNew1.Location = new System.Drawing.Point(3, 252);
            this.lblAnimeNew1.Name = "lblAnimeNew1";
            this.lblAnimeNew1.Size = new System.Drawing.Size(160, 20);
            this.lblAnimeNew1.TabIndex = 1;
            this.lblAnimeNew1.Text = "anime new";
            this.lblAnimeNew1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // topAnime
            // 
            this.topAnime.AutoSize = true;
            this.topAnime.Dock = System.Windows.Forms.DockStyle.Top;
            this.topAnime.Location = new System.Drawing.Point(0, 0);
            this.topAnime.Name = "topAnime";
            this.topAnime.Size = new System.Drawing.Size(716, 0);
            this.topAnime.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(914, 761);
            this.Controls.Add(this.animeContentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnimeVerse";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            this.animeContentPanel.ResumeLayout(false);
            this.animeContentPanel.PerformLayout();
            this.topAnimePanel.ResumeLayout(false);
            this.topAnimePanel.PerformLayout();
            this.anime4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnime4)).EndInit();
            this.anime3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnime3)).EndInit();
            this.anime2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnime2)).EndInit();
            this.anime1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnime1)).EndInit();
            this.newAnimePanel.ResumeLayout(false);
            this.newAnimePanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnLichSu;
        private System.Windows.Forms.Button btnThuVien;
        private System.Windows.Forms.Button btnMua;
        private System.Windows.Forms.Button btnTheLoai;
        private System.Windows.Forms.Button btnCaiDat;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel animeContentPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel topAnime;
        private System.Windows.Forms.Panel newAnimePanel;
        private System.Windows.Forms.Panel topAnimePanel;
        private System.Windows.Forms.Panel anime1;
        private System.Windows.Forms.PictureBox picAnime1;
        private System.Windows.Forms.Label lblTenAnime1;
        private System.Windows.Forms.Label lblTrangThai1;
        private System.Windows.Forms.Panel anime4;
        private System.Windows.Forms.Label lblTrangThai4;
        private System.Windows.Forms.Label lblTenAnime4;
        private System.Windows.Forms.PictureBox picAnime4;
        private System.Windows.Forms.Panel anime3;
        private System.Windows.Forms.Label lblTrangThai3;
        private System.Windows.Forms.Label lblTenAnime3;
        private System.Windows.Forms.PictureBox picAnime3;
        private System.Windows.Forms.Panel anime2;
        private System.Windows.Forms.Label lblTrangThai2;
        private System.Windows.Forms.Label lblTenAnime2;
        private System.Windows.Forms.PictureBox picAnime2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTrangThaiNew1;
        private System.Windows.Forms.Label lblAnimeNew1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}