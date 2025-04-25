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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            ShowForm(new AnimeManagementForm());
        }

        private void btnAnime_Click(object sender, EventArgs e)
        {
            ShowForm(new AnimeManagementForm());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ShowForm(new UserManagementForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            Panel contentPanel = this.Controls.OfType<Panel>().First(p => p.Dock == DockStyle.Fill);
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}
