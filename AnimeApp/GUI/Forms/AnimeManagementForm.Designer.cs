using System.Windows.Forms;

namespace AnimeApp.GUI.Forms
{
    partial class AnimeManagementForm
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
            this.searchPanel = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvAnime = new System.Windows.Forms.DataGridView();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.cbKieu = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtDanhGia = new System.Windows.Forms.TextBox();
            this.txtTenAnimeJapanese = new System.Windows.Forms.TextBox();
            this.txtTenAnime = new System.Windows.Forms.TextBox();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.txtMyAnimeListID = new System.Windows.Forms.TextBox();
            this.animeDBDataSet = new AnimeApp.AnimeDBDataSet();
            this.animeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.animeTableAdapter = new AnimeApp.AnimeDBDataSetTableAdapters.AnimeTableAdapter();
            this.dtpNgayPhatHanh = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTapPhim = new System.Windows.Forms.TextBox();
            this.AnimeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyAnimeListID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenAnime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenAnimeJapanese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TapPhim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayPhatHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.txtAnimeID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnime)).BeginInit();
            this.inputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animeDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Location = new System.Drawing.Point(10, 10);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(899, 50);
            this.searchPanel.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(216, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearch.Location = new System.Drawing.Point(10, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 25);
            this.txtSearch.TabIndex = 0;
            // 
            // dgvAnime
            // 
            this.dgvAnime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnime.BackgroundColor = System.Drawing.Color.White;
            this.dgvAnime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAnime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnimeID,
            this.MyAnimeListID,
            this.TenAnime,
            this.TenAnimeJapanese,
            this.MoTa,
            this.HinhAnh,
            this.Kieu,
            this.TapPhim,
            this.DanhGia,
            this.NgayPhatHanh,
            this.TrangThai});
            this.dgvAnime.Location = new System.Drawing.Point(10, 70);
            this.dgvAnime.Name = "dgvAnime";
            this.dgvAnime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnime.Size = new System.Drawing.Size(899, 300);
            this.dgvAnime.TabIndex = 0;
            this.dgvAnime.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnime_CellContentClick);
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.dtpNgayPhatHanh);
            this.inputPanel.Controls.Add(this.cbTrangThai);
            this.inputPanel.Controls.Add(this.cbKieu);
            this.inputPanel.Controls.Add(this.label8);
            this.inputPanel.Controls.Add(this.label4);
            this.inputPanel.Controls.Add(this.label9);
            this.inputPanel.Controls.Add(this.label7);
            this.inputPanel.Controls.Add(this.label3);
            this.inputPanel.Controls.Add(this.label10);
            this.inputPanel.Controls.Add(this.label6);
            this.inputPanel.Controls.Add(this.label2);
            this.inputPanel.Controls.Add(this.label5);
            this.inputPanel.Controls.Add(this.label11);
            this.inputPanel.Controls.Add(this.label1);
            this.inputPanel.Controls.Add(this.btnXoa);
            this.inputPanel.Controls.Add(this.btnSua);
            this.inputPanel.Controls.Add(this.btnAdd);
            this.inputPanel.Controls.Add(this.txtMoTa);
            this.inputPanel.Controls.Add(this.txtTapPhim);
            this.inputPanel.Controls.Add(this.txtDanhGia);
            this.inputPanel.Controls.Add(this.txtTenAnimeJapanese);
            this.inputPanel.Controls.Add(this.txtTenAnime);
            this.inputPanel.Controls.Add(this.txtHinhAnh);
            this.inputPanel.Controls.Add(this.txtAnimeID);
            this.inputPanel.Controls.Add(this.txtMyAnimeListID);
            this.inputPanel.Location = new System.Drawing.Point(10, 380);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(899, 322);
            this.inputPanel.TabIndex = 1;
            // 
            // cbKieu
            // 
            this.cbKieu.FormattingEnabled = true;
            this.cbKieu.Items.AddRange(new object[] {
            "TV Special",
            "TV",
            "Movie",
            "OVA",
            "ONA",
            "Special",
            "Music"});
            this.cbKieu.Location = new System.Drawing.Point(105, 166);
            this.cbKieu.Name = "cbKieu";
            this.cbKieu.Size = new System.Drawing.Size(542, 21);
            this.cbKieu.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "TrangThai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "MoTa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "DanhGia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "TenAnimeJapanese";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Kieu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TenAnime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "HinhAnh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MyAnimeListID";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(655, 107);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 34);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(655, 73);
            this.btnSua.Margin = new System.Windows.Forms.Padding(0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 34);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(655, 39);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(105, 114);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(542, 20);
            this.txtMoTa.TabIndex = 2;
            // 
            // txtDanhGia
            // 
            this.txtDanhGia.Location = new System.Drawing.Point(105, 222);
            this.txtDanhGia.Name = "txtDanhGia";
            this.txtDanhGia.Size = new System.Drawing.Size(542, 20);
            this.txtDanhGia.TabIndex = 2;
            // 
            // txtTenAnimeJapanese
            // 
            this.txtTenAnimeJapanese.Location = new System.Drawing.Point(105, 88);
            this.txtTenAnimeJapanese.Name = "txtTenAnimeJapanese";
            this.txtTenAnimeJapanese.Size = new System.Drawing.Size(542, 20);
            this.txtTenAnimeJapanese.TabIndex = 2;
            // 
            // txtTenAnime
            // 
            this.txtTenAnime.Location = new System.Drawing.Point(105, 62);
            this.txtTenAnime.Name = "txtTenAnime";
            this.txtTenAnime.Size = new System.Drawing.Size(542, 20);
            this.txtTenAnime.TabIndex = 2;
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Location = new System.Drawing.Point(105, 140);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(542, 20);
            this.txtHinhAnh.TabIndex = 2;
            // 
            // txtMyAnimeListID
            // 
            this.txtMyAnimeListID.Location = new System.Drawing.Point(105, 36);
            this.txtMyAnimeListID.Name = "txtMyAnimeListID";
            this.txtMyAnimeListID.Size = new System.Drawing.Size(542, 20);
            this.txtMyAnimeListID.TabIndex = 2;
            // 
            // animeDBDataSet
            // 
            this.animeDBDataSet.DataSetName = "AnimeDBDataSet";
            this.animeDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // animeBindingSource
            // 
            this.animeBindingSource.DataMember = "Anime";
            this.animeBindingSource.DataSource = this.animeDBDataSet;
            // 
            // animeTableAdapter
            // 
            this.animeTableAdapter.ClearBeforeFill = true;
            // 
            // dtpNgayPhatHanh
            // 
            this.dtpNgayPhatHanh.Location = new System.Drawing.Point(105, 250);
            this.dtpNgayPhatHanh.Name = "dtpNgayPhatHanh";
            this.dtpNgayPhatHanh.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayPhatHanh.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "NgayPhatHanh";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "TapPhim";
            // 
            // txtTapPhim
            // 
            this.txtTapPhim.Location = new System.Drawing.Point(104, 196);
            this.txtTapPhim.Name = "txtTapPhim";
            this.txtTapPhim.Size = new System.Drawing.Size(542, 20);
            this.txtTapPhim.TabIndex = 2;
            // 
            // AnimeID
            // 
            this.AnimeID.DataPropertyName = "AnimeID";
            this.AnimeID.HeaderText = "AnimeID";
            this.AnimeID.Name = "AnimeID";
            // 
            // MyAnimeListID
            // 
            this.MyAnimeListID.DataPropertyName = "MyAnimeListID";
            this.MyAnimeListID.HeaderText = "MyAnimeListID";
            this.MyAnimeListID.Name = "MyAnimeListID";
            // 
            // TenAnime
            // 
            this.TenAnime.DataPropertyName = "TenAnime";
            this.TenAnime.HeaderText = "TenAnime";
            this.TenAnime.Name = "TenAnime";
            // 
            // TenAnimeJapanese
            // 
            this.TenAnimeJapanese.DataPropertyName = "TenAnimeJapanese";
            this.TenAnimeJapanese.HeaderText = "TenAnimeJapanese";
            this.TenAnimeJapanese.Name = "TenAnimeJapanese";
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "MoTa";
            this.MoTa.Name = "MoTa";
            // 
            // HinhAnh
            // 
            this.HinhAnh.DataPropertyName = "HinhAnh";
            this.HinhAnh.HeaderText = "HinhAnh";
            this.HinhAnh.Name = "HinhAnh";
            // 
            // Kieu
            // 
            this.Kieu.DataPropertyName = "Kieu";
            this.Kieu.HeaderText = "Kieu";
            this.Kieu.Name = "Kieu";
            // 
            // TapPhim
            // 
            this.TapPhim.DataPropertyName = "TapPhim";
            this.TapPhim.HeaderText = "TapPhim";
            this.TapPhim.Name = "TapPhim";
            // 
            // DanhGia
            // 
            this.DanhGia.DataPropertyName = "DanhGia";
            this.DanhGia.HeaderText = "DanhGia";
            this.DanhGia.Name = "DanhGia";
            // 
            // NgayPhatHanh
            // 
            this.NgayPhatHanh.DataPropertyName = "NgayPhatHanh";
            this.NgayPhatHanh.HeaderText = "NgayPhatHanh";
            this.NgayPhatHanh.Name = "NgayPhatHanh";
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "TrangThai";
            this.TrangThai.Name = "TrangThai";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Finished Airing",
            "Cyrrently Airing"});
            this.cbTrangThai.Location = new System.Drawing.Point(104, 276);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(542, 21);
            this.cbTrangThai.TabIndex = 5;
            // 
            // txtAnimeID
            // 
            this.txtAnimeID.Location = new System.Drawing.Point(104, 10);
            this.txtAnimeID.Name = "txtAnimeID";
            this.txtAnimeID.Size = new System.Drawing.Size(542, 20);
            this.txtAnimeID.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "AnimeID";
            // 
            // AnimeManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(924, 714);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.dgvAnime);
            this.Controls.Add(this.searchPanel);
            this.Name = "AnimeManagementForm";
            this.Text = "AnimeManagementForm";
            this.Load += new System.EventHandler(this.AnimeManagementForm_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnime)).EndInit();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animeDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvAnime;
        private System.Windows.Forms.Panel inputPanel;
        private Button btnXoa;
        private Button btnSua;
        private Button btnAdd;
        private TextBox txtMyAnimeListID;
        private AnimeDBDataSet animeDBDataSet;
        private BindingSource animeBindingSource;
        private AnimeDBDataSetTableAdapters.AnimeTableAdapter animeTableAdapter;
        private Label label8;
        private Label label4;
        private Label label7;
        private Label label3;
        private Label label6;
        private Label label2;
        private Label label5;
        private Label label1;
        private TextBox txtMoTa;
        private TextBox txtDanhGia;
        private TextBox txtTenAnimeJapanese;
        private TextBox txtTenAnime;
        private TextBox txtHinhAnh;
        private ComboBox cbKieu;
        private DateTimePicker dtpNgayPhatHanh;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label9;
        private Label label10;
        private TextBox txtTapPhim;
        private DataGridViewTextBoxColumn AnimeID;
        private DataGridViewTextBoxColumn MyAnimeListID;
        private DataGridViewTextBoxColumn TenAnime;
        private DataGridViewTextBoxColumn TenAnimeJapanese;
        private DataGridViewTextBoxColumn MoTa;
        private DataGridViewTextBoxColumn HinhAnh;
        private DataGridViewTextBoxColumn Kieu;
        private DataGridViewTextBoxColumn TapPhim;
        private DataGridViewTextBoxColumn DanhGia;
        private DataGridViewTextBoxColumn NgayPhatHanh;
        private DataGridViewTextBoxColumn TrangThai;
        private ComboBox cbTrangThai;
        private Label label11;
        private TextBox txtAnimeID;
    }
}