using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBVBM.GUI
{
    public partial class GUI_Home: Form
    {
        public GUI_Home()
        {
            InitializeComponent();
            InitializeNavPanel();
        }

        public void InitializeNavPanel()
        {
            Guna.UI2.WinForms.Guna2Panel navPanel = new Guna.UI2.WinForms.Guna2Panel();
            navPanel.Dock = DockStyle.Left;
            navPanel.Width = 200;
            navPanel.FillColor = Color.FromArgb(45, 45, 60); // màu nền tối
            this.Controls.Add(navPanel);

            // Tạo nút menu
            Guna.UI2.WinForms.Guna2Button btnTiepNhanChuyenBay = new Guna.UI2.WinForms.Guna2Button();
            btnTiepNhanChuyenBay.Text = "Tiếp nhận lịch chuyến bay";
            //btnDashboard.Image = Properties.Resources.dashboard_icon; // hoặc null nếu chưa có
            btnTiepNhanChuyenBay.ImageOffset = new Point(10, 0);
            btnTiepNhanChuyenBay.ImageSize = new Size(24, 24);
            btnTiepNhanChuyenBay.TextOffset = new Point(15, 0);
            btnTiepNhanChuyenBay.Dock = DockStyle.Top;
            btnTiepNhanChuyenBay.Height = 50;
            btnTiepNhanChuyenBay.FillColor = Color.FromArgb(60, 60, 80);
            btnTiepNhanChuyenBay.HoverState.FillColor = Color.FromArgb(75, 75, 100);
            btnTiepNhanChuyenBay.Font = new Font("Segoe UI", 10);
            btnTiepNhanChuyenBay.ForeColor = Color.White;
            btnTiepNhanChuyenBay.TextAlign = HorizontalAlignment.Left;
            btnTiepNhanChuyenBay.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnTiepNhanChuyenBay.CheckedState.FillColor = Color.FromArgb(90, 90, 120);

            navPanel.Controls.Add(btnTiepNhanChuyenBay);
        }
    }
}
