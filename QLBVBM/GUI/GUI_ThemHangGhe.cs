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
    public partial class GUI_ThemHangGhe : Form
    {
        private BUS_HangGhe BUS_HangGhe = new BUS_HangGhe();

        private ErrorProvider errorProvider = new ErrorProvider();

        public GUI_ThemHangGhe()
        {
            InitializeComponent();
            PhatSinhMaHangGhe();
        }

        private void LoadDanhSachHangGhe()
        {
            var dsHangGhe = BUS_HangGhe.LayDanhSachHangGhe();

            dgvDSHangGhe.Columns.Clear();

            // Define the font for the header cells
            Font headerFont = new Font("Arial", 11, FontStyle.Regular);

            // Set the header row color to grey
            dgvDSHangGhe.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvDSHangGhe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDSHangGhe.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgvDSHangGhe.EnableHeadersVisualStyles = false;

            // Add MaHangGhe column
            DataGridViewTextBoxColumn colMaHangGhe = new DataGridViewTextBoxColumn
            {
                Name = "MaHangGhe",
                HeaderText = "Mã hạng ghế",
                DataPropertyName = "MaHangGhe",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colMaHangGhe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaHangGhe.HeaderCell.Style.Font = headerFont;
            dgvDSHangGhe.Columns.Add(colMaHangGhe);

            // Add TenSanBay column
            DataGridViewTextBoxColumn colTenHangGhe = new DataGridViewTextBoxColumn
            {
                Name = "TenHangGhe",
                HeaderText = "Tên hạng ghế",
                DataPropertyName = "TenHangGhe",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            colTenHangGhe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTenHangGhe.HeaderCell.Style.Font = headerFont;
            dgvDSHangGhe.Columns.Add(colTenHangGhe);

            dgvDSHangGhe.DataSource = dsHangGhe;
        }

        private void GUI_ThemHangGhe_Load(object sender, EventArgs e)
        {
            LoadDanhSachHangGhe();
        }

        private void PhatSinhMaHangGhe()
        {
            txtMaHangGhe.Text = BUS_HangGhe.PhatSinhMaHangGhe();
        }

        private bool HasError()
        {
            // Check for errors in form controls
            foreach (Control control in this.Controls)
                if (errorProvider.GetError(control) != string.Empty)
                    return true;

            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHangGhe.Text))
                errorProvider.SetError(txtTenHangGhe, "Tên hạng ghế không được để trống");

            if (HasError())
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_HangGhe newHangGhe = new DTO_HangGhe
            {
                MaHangGhe = txtMaHangGhe.Text,
                TenHangGhe = txtTenHangGhe.Text
            };

            if (BUS_HangGhe.ThemHangGhe(newHangGhe))
            {
                MessageBox.Show("Thêm hạng ghế thành công");
                LoadDanhSachHangGhe();
                PhatSinhMaHangGhe();
            }
            else
            {
                MessageBox.Show("Thêm hạng ghế thất bại");
            }
        }

        private void txtTenHangGhe_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTenHangGhe.Text))
                errorProvider.SetError(txtTenHangGhe, string.Empty);
        }
    }
}
