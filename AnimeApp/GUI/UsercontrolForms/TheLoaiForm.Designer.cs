namespace AnimeApp.GUI.Forms
{
    partial class TheLoaiForm
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
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.txtTrang = new System.Windows.Forms.TextBox();
            this.btnTien = new System.Windows.Forms.Button();
            this.btnLui = new System.Windows.Forms.Button();
            this.btnDuyetPhim = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNamPhatHanh = new System.Windows.Forms.ComboBox();
            this.lblMua = new System.Windows.Forms.Label();
            this.cbMua = new System.Windows.Forms.ComboBox();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.cbTheLoai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.containerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Đang phát sóng",
            "Hoàn Thành ",
            "Sắp phát sóng"});
            this.cmbTrangThai.Location = new System.Drawing.Point(30, 43);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(120, 24);
            this.cmbTrangThai.TabIndex = 0;
            // 
            // containerPanel
            // 
            this.containerPanel.AutoScroll = true;
            this.containerPanel.Controls.Add(this.txtTrang);
            this.containerPanel.Controls.Add(this.btnTien);
            this.containerPanel.Controls.Add(this.btnLui);
            this.containerPanel.Controls.Add(this.btnDuyetPhim);
            this.containerPanel.Controls.Add(this.label3);
            this.containerPanel.Controls.Add(this.cbNamPhatHanh);
            this.containerPanel.Controls.Add(this.lblMua);
            this.containerPanel.Controls.Add(this.cbMua);
            this.containerPanel.Controls.Add(this.lblTheLoai);
            this.containerPanel.Controls.Add(this.cbTheLoai);
            this.containerPanel.Controls.Add(this.label1);
            this.containerPanel.Controls.Add(this.label2);
            this.containerPanel.Controls.Add(this.lblTrangThai);
            this.containerPanel.Controls.Add(this.cmbTrangThai);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(711, 718);
            this.containerPanel.TabIndex = 1;
            // 
            // txtTrang
            // 
            this.txtTrang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTrang.Location = new System.Drawing.Point(115, 121);
            this.txtTrang.Multiline = true;
            this.txtTrang.Name = "txtTrang";
            this.txtTrang.Size = new System.Drawing.Size(45, 30);
            this.txtTrang.TabIndex = 4;
            this.txtTrang.Text = "1";
            this.txtTrang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTien
            // 
            this.btnTien.Location = new System.Drawing.Point(166, 121);
            this.btnTien.Name = "btnTien";
            this.btnTien.Size = new System.Drawing.Size(30, 30);
            this.btnTien.TabIndex = 3;
            this.btnTien.Text = ">";
            this.btnTien.UseVisualStyleBackColor = true;
            this.btnTien.Click += new System.EventHandler(this.btnTien_Click);
            // 
            // btnLui
            // 
            this.btnLui.Location = new System.Drawing.Point(79, 121);
            this.btnLui.Name = "btnLui";
            this.btnLui.Size = new System.Drawing.Size(30, 30);
            this.btnLui.TabIndex = 3;
            this.btnLui.Text = "<";
            this.btnLui.UseVisualStyleBackColor = true;
            this.btnLui.Click += new System.EventHandler(this.btnLui_Click);
            // 
            // btnDuyetPhim
            // 
            this.btnDuyetPhim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDuyetPhim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDuyetPhim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDuyetPhim.FlatAppearance.BorderSize = 0;
            this.btnDuyetPhim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDuyetPhim.ForeColor = System.Drawing.Color.White;
            this.btnDuyetPhim.Location = new System.Drawing.Point(581, 34);
            this.btnDuyetPhim.Name = "btnDuyetPhim";
            this.btnDuyetPhim.Size = new System.Drawing.Size(90, 39);
            this.btnDuyetPhim.TabIndex = 2;
            this.btnDuyetPhim.Text = "Duyệt Phim";
            this.btnDuyetPhim.UseVisualStyleBackColor = false;
            this.btnDuyetPhim.Click += new System.EventHandler(this.btnDuyetPhim_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(455, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Năm Phát Hành";
            // 
            // cbNamPhatHanh
            // 
            this.cbNamPhatHanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNamPhatHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbNamPhatHanh.FormattingEnabled = true;
            this.cbNamPhatHanh.Location = new System.Drawing.Point(455, 43);
            this.cbNamPhatHanh.Name = "cbNamPhatHanh";
            this.cbNamPhatHanh.Size = new System.Drawing.Size(120, 24);
            this.cbNamPhatHanh.TabIndex = 0;
            // 
            // lblMua
            // 
            this.lblMua.AutoSize = true;
            this.lblMua.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMua.ForeColor = System.Drawing.Color.White;
            this.lblMua.Location = new System.Drawing.Point(316, 12);
            this.lblMua.Name = "lblMua";
            this.lblMua.Size = new System.Drawing.Size(70, 17);
            this.lblMua.TabIndex = 1;
            this.lblMua.Text = "Theo Mùa";
            // 
            // cbMua
            // 
            this.cbMua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbMua.FormattingEnabled = true;
            this.cbMua.Items.AddRange(new object[] {
            "Tất cả",
            "Xuân ",
            "Hạ",
            "Thu",
            "Đông"});
            this.cbMua.Location = new System.Drawing.Point(316, 43);
            this.cbMua.Name = "cbMua";
            this.cbMua.Size = new System.Drawing.Size(120, 24);
            this.cbMua.TabIndex = 0;
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheLoai.ForeColor = System.Drawing.Color.White;
            this.lblTheLoai.Location = new System.Drawing.Point(173, 12);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(61, 17);
            this.lblTheLoai.TabIndex = 1;
            this.lblTheLoai.Text = "Thể Loại";
            // 
            // cbTheLoai
            // 
            this.cbTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbTheLoai.FormattingEnabled = true;
            this.cbTheLoai.Location = new System.Drawing.Point(173, 43);
            this.cbTheLoai.Name = "cbTheLoai";
            this.cbTheLoai.Size = new System.Drawing.Size(120, 24);
            this.cbTheLoai.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh Sách Anime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trang";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.White;
            this.lblTrangThai.Location = new System.Drawing.Point(30, 12);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(74, 17);
            this.lblTrangThai.TabIndex = 1;
            this.lblTrangThai.Text = "Trạng Thái";
            // 
            // TheLoaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(711, 718);
            this.Controls.Add(this.containerPanel);
            this.Name = "TheLoaiForm";
            this.Text = "TheLoaiForm";
            this.Load += new System.EventHandler(this.TheLoaiForm_Load);
            this.containerPanel.ResumeLayout(false);
            this.containerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNamPhatHanh;
        private System.Windows.Forms.Label lblMua;
        private System.Windows.Forms.ComboBox cbMua;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.ComboBox cbTheLoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDuyetPhim;
        private System.Windows.Forms.Button btnLui;
        private System.Windows.Forms.Button btnTien;
        private System.Windows.Forms.TextBox txtTrang;
        private System.Windows.Forms.Label label2;
    }
}