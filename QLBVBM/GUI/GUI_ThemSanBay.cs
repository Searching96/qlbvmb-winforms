using QLBVBM.BUS;
using QLBVBM.DTO;
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
    public partial class GUI_ThemSanBay : Form
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();

        public GUI_ThemSanBay()
        {
            InitializeComponent();
        }

        private void LoadDanhSachSanBay()
        {
            var dsSanBay = busSanBay.LayDanhSachSanBay();

            dgvDSSanBay.Columns.Clear();
            dgvDSSanBay.RowHeadersVisible = false;

            // Define the font for the header cells
            Font headerFont = new Font("Arial", 11, FontStyle.Regular);

            // Set the header row color to grey
            dgvDSSanBay.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvDSSanBay.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDSSanBay.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgvDSSanBay.EnableHeadersVisualStyles = false;

            // Add MaSanBay column
            DataGridViewTextBoxColumn colMaSanBay = new DataGridViewTextBoxColumn
            {
                Name = "MaSanBay",
                HeaderText = "Mã sân bay",
                DataPropertyName = "MaSanBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colMaSanBay.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaSanBay.HeaderCell.Style.Font = headerFont;
            dgvDSSanBay.Columns.Add(colMaSanBay);

            // Add TenSanBay column
            DataGridViewTextBoxColumn colTenSanBay = new DataGridViewTextBoxColumn
            {
                Name = "TenSanBay",
                HeaderText = "Tên sân bay",
                DataPropertyName = "TenSanBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colTenSanBay.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTenSanBay.HeaderCell.Style.Font = headerFont;
            dgvDSSanBay.Columns.Add(colTenSanBay);

            dgvDSSanBay.DataSource = dsSanBay;
        }

        private void GUI_ThemSanBay_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanBay();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_SanBay newSanBay = new DTO_SanBay
            {
                MaSanBay = txtMaSanBay.Text,
                TenSanBay = txtTenSanBay.Text
            };

            if (busSanBay.ThemSanBay(newSanBay))
            {
                MessageBox.Show("Thêm sân bay thành công");
                LoadDanhSachSanBay();
            }
            else
            {
                MessageBox.Show("Thêm sân bay thất bại");
            }
        }
    }
}
