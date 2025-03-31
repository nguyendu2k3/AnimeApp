using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnimeApp.GUI.Forms; // Thêm namespace này

namespace AnimeApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Tạo và hiển thị form đăng nhập
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);

        }
    }
}
