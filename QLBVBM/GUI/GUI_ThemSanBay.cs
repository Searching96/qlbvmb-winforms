using QLBVBM.BUS;
using QLBVBM.DTO;
using System;

namespace QLBVBM.GUI
{
    public partial class GUI_ThemSanBay : Form
    {
        private BUS_SanBay BUS_SanBay = new BUS_SanBay();

        private ErrorProvider errorProvider = new ErrorProvider();

        public GUI_ThemSanBay()
        {
            InitializeComponent();
            PhatSinhMaSanBay();
        }

        private void LoadDanhSachSanBay()
        {
            var dsSanBay = BUS_SanBay.LayDanhSachSanBay();

            dgvDSSanBay.Columns.Clear();

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

        private void PhatSinhMaSanBay()
        {
            txtMaSanBay.Text = BUS_SanBay.PhatSinhMaSanBay();
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
            if (string.IsNullOrWhiteSpace(txtTenSanBay.Text))
                errorProvider.SetError(txtTenSanBay, "Tên sân bay không được để trống");

            if (HasError())
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_SanBay newSanBay = new DTO_SanBay
            {
                MaSanBay = txtMaSanBay.Text,
                TenSanBay = txtTenSanBay.Text
            };

            if (BUS_SanBay.ThemSanBay(newSanBay))
            {
                MessageBox.Show("Thêm sân bay thành công");
                LoadDanhSachSanBay();
                PhatSinhMaSanBay();
            }
            else
            {
                MessageBox.Show("Thêm sân bay thất bại");
            }
        }

        private void txtTenSanBay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTenSanBay.Text))
                errorProvider.SetError(txtTenSanBay, string.Empty);
        }
    }
}
