using AnimeApp.BLL;
using AnimeApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeApp.GUI.Forms
{
    public partial class AnimeManagementForm : Form
    {
        private readonly AnimeService _animeService;

        public AnimeManagementForm()
        {
            InitializeComponent();
            _animeService = new AnimeService();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Anime newAnime = new Anime
                {
                    MyAnimeListID = int.Parse(txtMyAnimeListID.Text),
                    TenAnime = txtTenAnime.Text,
                    TenAnimeJapanese = txtTenAnimeJapanese.Text,
                    MoTa = txtMoTa.Text,
                    HinhAnh = txtHinhAnh.Text,
                    Kieu = cbKieu.Text,
                    DanhGia = float.Parse(txtDanhGia.Text),
                    NgayPhatHanh = dtpNgayPhatHanh.Value,
                    TrangThai = cbTrangThai.Text
                };

                if (_animeService.ThemAnime(newAnime))
                {
                    MessageBox.Show("Anime đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAnimeFromDatabase();
                }
                else
                {
                    MessageBox.Show("Không thêm được anime.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAnime.SelectedRows.Count > 0)
                {
                    int animeID = int.Parse(dgvAnime.SelectedRows[0].Cells["AnimeID"].Value.ToString());

                    Anime updatedAnime = new Anime
                    {
                        AnimeID = animeID,
                        MyAnimeListID = int.Parse(txtMyAnimeListID.Text),
                        TenAnime = txtTenAnime.Text,
                        TenAnimeJapanese = txtTenAnimeJapanese.Text,
                        MoTa = txtMoTa.Text,
                        HinhAnh = txtHinhAnh.Text,
                        Kieu =cbKieu.Text,
                        TapPhim = int.Parse(txtTapPhim.Text),
                        DanhGia = float.Parse(txtDanhGia.Text),
                        NgayPhatHanh = dtpNgayPhatHanh.Value,
                        TrangThai = cbTrangThai.Text
                    };

                    if (_animeService.CapNhatAnime(updatedAnime))
                    {
                        MessageBox.Show("Anime Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAnimeFromDatabase();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an anime to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAnime.SelectedRows.Count > 0)
                {
                    int animeID = int.Parse(txtAnimeID.Text);
                    Console.WriteLine($"Attempting to delete AnimeID: {animeID}"); // Debug log

                    if (MessageBox.Show("Xóa Anime?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_animeService.XoaAnime(animeID))
                        {
                            MessageBox.Show("Xóa Anime Thành Công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAnimeFromDatabase();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete anime.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an anime to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnimeManagementForm_Load(object sender, EventArgs e)
        {
            LoadAnimeFromDatabase();

        }
        private void LoadAnimeFromDatabase()
        {
            try
            {
               
                List<Anime> animeList = _animeService.GetAllAnimes();

                
                dgvAnime.DataSource = animeList.Select(anime => new
                {
                    anime.AnimeID,
                    anime.MyAnimeListID,
                    anime.TenAnime,
                    anime.TenAnimeJapanese,
                    anime.MoTa,
                    anime.HinhAnh,
                    anime.Kieu,
                    anime.TapPhim,
                    anime.DanhGia,
                    anime.NgayPhatHanh,
                    anime.TrangThai
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading anime: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.txtAnimeID.Clear();
            this.txtMyAnimeListID.Clear();
            this.txtTenAnime.Clear();
            this.txtTenAnimeJapanese.Clear();
            this.txtMoTa.Clear();
            this.txtHinhAnh.Clear();
            this.txtTapPhim.Clear();
            this.txtDanhGia.Clear();
            this.cbKieu.Text = "";
            this.cbTrangThai.Text = "";
            this.txtSearch.Clear();
        }

        private void dgvAnime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgvAnime.Rows[e.RowIndex];
            txtAnimeID.Text = selectedRow.Cells["AnimeID"].Value.ToString();
            txtMyAnimeListID.Text = selectedRow.Cells["MyAnimeListID"].Value.ToString();
            txtTenAnime.Text = selectedRow.Cells["TenAnime"].Value.ToString();
            txtTenAnimeJapanese.Text = selectedRow.Cells["TenAnimeJapanese"].Value.ToString();
            txtMoTa.Text = selectedRow.Cells["MoTa"].Value.ToString();
            txtHinhAnh.Text = selectedRow.Cells["HinhAnh"].Value.ToString();
            cbKieu.Text = selectedRow.Cells["Kieu"].Value.ToString();
            txtTapPhim.Text = selectedRow.Cells["TapPhim"].Value.ToString();
            txtDanhGia.Text = selectedRow.Cells["DanhGia"].Value.ToString();
            cbTrangThai.Text = selectedRow.Cells["TrangThai"].Value.ToString();
            dtpNgayPhatHanh.Value = DateTime.Parse(selectedRow.Cells["NgayPhatHanh"].Value.ToString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(keyword))
                {
                    List<Anime> searchResults = _animeService.SearchAnime(keyword);

                    dgvAnime.DataSource = searchResults.Select(anime => new
                    {
                        anime.AnimeID,
                        anime.MyAnimeListID,
                        anime.TenAnime,
                        anime.TenAnimeJapanese,
                        anime.MoTa,
                        anime.HinhAnh,
                        anime.Kieu,
                        anime.TapPhim,
                        anime.DanhGia,
                        anime.NgayPhatHanh,
                        anime.TrangThai
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Please enter a keyword to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
