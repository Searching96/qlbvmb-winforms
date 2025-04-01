using QLBVBM.BUS;
using QLBVBM.DAL;
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
    public partial class GUI_TiepNhanLichChuyenBay : Form
    {
        private BUS_SanBay BUS_SanBay = new BUS_SanBay();
        private BUS_ChuyenBay BUS_ChuyenBay = new BUS_ChuyenBay();
        private BUS_ThamSo BUS_ThamSo = new BUS_ThamSo();

        private ErrorProvider errorProvider = new ErrorProvider();

        public GUI_TiepNhanLichChuyenBay()
        {
            InitializeComponent();
            SetupDgvColumns(dgvDSSanBayTG, BUS_ThamSo.LaySoLuongSanBayToiDa(), BUS_SanBay.LayDanhSachSanBay());
            PhatSinhMaChuyenBay();
            LoadSanBayToComboBox(cbbSanBayDi);
            LoadSanBayToComboBox(cbbSanBayDen);
        }

        private void LoadSanBayToComboBox(ComboBox cbb)
        {
            List<DTO_SanBay> dsSanBay = BUS_SanBay.LayDanhSachSanBay();
            if (dsSanBay != null && dsSanBay.Count > 0)
            {
                cbb.DataSource = dsSanBay;
                cbb.DisplayMember = "TenSanBay";
                cbb.ValueMember = "MaSanBay";
            }
        }

        private void PhatSinhMaChuyenBay()
        {
            txtMaChuyenBay.Text = BUS_ChuyenBay.PhatSinhMaChuyenBay();
        }

        private void SetupDgvColumns(Guna.UI2.WinForms.Guna2DataGridView dgv, int rowCount, List<DTO_SanBay> dsSanBay)
        {
            dgv.Columns.Clear();
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;

            // Set the theme to grey color
            dgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgv.ThemeStyle.BackColor = Color.White;
            dgv.ThemeStyle.GridColor = Color.LightGray;
            dgv.ThemeStyle.HeaderStyle.BackColor = Color.White;
            dgv.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            dgv.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.LightGray;
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;

            // Define the font for the header cells
            Font headerFont = new Font("Arial", 11, FontStyle.Regular);

            // Set the header row color to grey
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgv.EnableHeadersVisualStyles = false;

            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn
            {
                Name = "STT",
                HeaderText = "STT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 50,
                ReadOnly = true
            };
            colSTT.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSTT.HeaderCell.Style.Font = headerFont;
            dgv.Columns.Add(colSTT);

            DataGridViewComboBoxColumn colTenSanBay = new DataGridViewComboBoxColumn
            {
                Name = "TenSanBay",
                HeaderText = "Tên sân bay",
                DataSource = dsSanBay,
                DisplayMember = "TenSanBay",
                ValueMember = "MaSanBay",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FlatStyle = FlatStyle.Flat
            };
            colTenSanBay.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTenSanBay.HeaderCell.Style.Font = headerFont;
            dgv.Columns.Add(colTenSanBay);

            DataGridViewTextBoxColumn colThoiGianDung = new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianDung",
                HeaderText = "Thời gian dừng (phút)"
            };
            colThoiGianDung.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colThoiGianDung.HeaderCell.Style.Font = headerFont;
            dgv.Columns.Add(colThoiGianDung);

            DataGridViewTextBoxColumn colGhiChu = new DataGridViewTextBoxColumn
            {
                Name = "GhiChu",
                HeaderText = "Ghi chú"
            };
            colGhiChu.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colGhiChu.HeaderCell.Style.Font = headerFont;
            dgv.Columns.Add(colGhiChu);

            dgv.Rows.Clear();
            for (int i = 0; i < rowCount; i++)
            {
                dgv.Rows.Add(i + 1, "", "", "");
            }
        }

        private bool HasErrors()
        {
            // Check for errors in form controls
            foreach (Control control in this.Controls)
            {
                if (errorProvider.GetError(control) != string.Empty)
                {
                    return true;
                }
            }

            // Check for errors in DataGridView cells
            foreach (DataGridViewRow row in dgvDSSanBayTG.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!string.IsNullOrEmpty(cell.ErrorText))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasIncompleteSanBayTGRowInput()
        {
            foreach (DataGridViewRow row in dgvDSSanBayTG.Rows)
            {
                if (row.IsNewRow)
                    continue;

                bool anyFieldFilled = false;
                bool anyFieldEmpty = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string colName = dgvDSSanBayTG.Columns[cell.ColumnIndex].Name;

                    // Skip non-required columns (for example, "GhiChu" and "STT")
                    if (colName == "GhiChu" || colName == "STT")
                        continue;

                    // For required fields, consider a cell "empty" if its Value is null or whitespace.
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        anyFieldEmpty = true;
                    }
                    else
                    {
                        anyFieldFilled = true;
                    }
                }

                // If at least one required cell is filled but at least one is empty,
                // then the row has incomplete input.
                if (anyFieldFilled && anyFieldEmpty)
                    return true;
            }

            return false;
        }

        private void btnTiepNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtThoiGianBay.Text))
                errorProvider.SetError(txtThoiGianBay, "Thời gian bay không được để trống");
            if (string.IsNullOrEmpty(txtSoLuongGheHang1.Text))
                errorProvider.SetError(txtSoLuongGheHang1, "Số lượng ghế hạng 1 không được để trống");
            if (string.IsNullOrEmpty(txtSoLuongGheHang2.Text))
                errorProvider.SetError(txtSoLuongGheHang2, "Số lượng ghế hạng 2 không được để trống");
            if (cbbSanBayDi.SelectedIndex == 0)
                errorProvider.SetError(cbbSanBayDi, "Sân bay đi không được để trống");
            if (cbbSanBayDen.SelectedIndex == 0)
                errorProvider.SetError(cbbSanBayDen, "Sân bay đến không được để trống");

            if (HasErrors())
            {
                MessageBox.Show("Vui lòng sửa các lỗi trước khi tiếp tục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckDuplicateAirports())
            {
                MessageBox.Show("Có sân bay xuất hiện nhiều hơn một lần.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (HasIncompleteSanBayTGRowInput())
            {
                MessageBox.Show("Có hàng trong danh sách sân bay trung gian chưa được nhập đầy đủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_ChuyenBay chuyenBayMoi = new DTO_ChuyenBay
            {
                MaChuyenBay = txtMaChuyenBay.Text,
                MaSanBayDi = cbbSanBayDi.SelectedValue.ToString(),
                MaSanBayDen = cbbSanBayDen.SelectedValue.ToString(),
                NgayGioBay = dtpNgayGioBay.Value,
                ThoiGianBay = int.Parse(txtThoiGianBay.Text)
            };

            List<DTO_CTChuyenBay> dsCTChuyenBay = new List<DTO_CTChuyenBay>();
            foreach (DataGridViewRow row in dgvDSSanBayTG.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var maSanBay = row.Cells["TenSanBay"].Value?.ToString();
                var textThoiGianDung = row.Cells["ThoiGianDung"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(maSanBay) && string.IsNullOrWhiteSpace(textThoiGianDung))
                    continue;

                if (!int.TryParse(textThoiGianDung, out int thoiGianDung))
                    continue;

                var ghiChu = row.Cells["GhiChu"].Value?.ToString();

                DTO_CTChuyenBay ctChuyenBay = new DTO_CTChuyenBay
                {
                    MaChuyenBay = chuyenBayMoi.MaChuyenBay,
                    MaSanBayTG = maSanBay,
                    ThoiGianDung = thoiGianDung,
                    GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? string.Empty : ghiChu
                };

                dsCTChuyenBay.Add(ctChuyenBay);
            }

            List<DTO_HangVeCB> dsHangVeCB = new List<DTO_HangVeCB>
            {
                new DTO_HangVeCB
                {
                    MaChuyenBay = chuyenBayMoi.MaChuyenBay,
                    MaHangGhe = "HG00001",
                    SoLuongGhe = int.Parse(txtSoLuongGheHang1.Text)
                },
                new DTO_HangVeCB
                {
                    MaChuyenBay = chuyenBayMoi.MaChuyenBay,
                    MaHangGhe = "HG00002",
                    SoLuongGhe = int.Parse(txtSoLuongGheHang2.Text)
                }
            };

            if (BUS_ChuyenBay.ThemChuyenBayVaChiTiet(chuyenBayMoi, dsCTChuyenBay, dsHangVeCB))
            {
                MessageBox.Show("Tiếp nhận lịch chuyến bay thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PhatSinhMaChuyenBay();
            }
            else
            {
                MessageBox.Show("Tiếp nhận lịch chuyến bay thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtThoiGianBay_TextChanged(object sender, EventArgs e)
        {
            int thoiGianBayToiThieu = BUS_ThamSo.LayThoiGianBayToiThieu();
            if (!BUS_ChuyenBay.ValidateThoiGianBay(txtThoiGianBay.Text))
            {
                errorProvider.SetError(txtThoiGianBay, $"Thời gian bay phải là số nguyên lớn hơn hay bằng {thoiGianBayToiThieu}");
            }
            else
            {
                errorProvider.SetError(txtThoiGianBay, string.Empty);
            }
        }

        private void txtSoLuongGheHang1_TextChanged(object sender, EventArgs e)
        {
            if (!BUS_ChuyenBay.ValidateSoLuongGhe(txtSoLuongGheHang1.Text))
            {
                errorProvider.SetError(txtSoLuongGheHang1, "Số lượng ghế phải là số nguyên không âm");
            }
            else
            {
                errorProvider.SetError(txtSoLuongGheHang1, string.Empty);
            }
        }

        private void txtSoLuongGheHang2_TextChanged(object sender, EventArgs e)
        {
            if (!BUS_ChuyenBay.ValidateSoLuongGhe(txtSoLuongGheHang2.Text))
            {
                errorProvider.SetError(txtSoLuongGheHang2, "Số lượng ghế phải là số nguyên không âm");
            }
            else
            {
                errorProvider.SetError(txtSoLuongGheHang2, string.Empty);
            }
        }

        private void DgvDSSanBayTG_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDSSanBayTG.Columns[e.ColumnIndex].Name == "ThoiGianDung")
            {
                int thoiGianDungToiThieu = BUS_ThamSo.LayThoiGianDungToiThieu();
                int thoiGianDungToiDa = BUS_ThamSo.LayThoiGianDungToiDa();

                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    dgvDSSanBayTG.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                    return;
                }

                if (!BUS_ChuyenBay.ValidateThoiGianDung(e.FormattedValue.ToString()))
                {
                    dgvDSSanBayTG.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText =
                        $"Thời gian dừng phải là số nguyên từ {thoiGianDungToiThieu} đến {thoiGianDungToiDa}";
                }
                else
                {
                    dgvDSSanBayTG.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                }
            }
        }

        private bool CheckDuplicateAirports()
        {
            List<string> selectedAirports = new List<string>();
            string sanBayDi = cbbSanBayDi.SelectedValue?.ToString();
            string sanBayDen = cbbSanBayDen.SelectedValue?.ToString();

            if (!string.IsNullOrWhiteSpace(sanBayDi))
                selectedAirports.Add(sanBayDi);

            if (!string.IsNullOrWhiteSpace(sanBayDen))
                selectedAirports.Add(sanBayDen);

            foreach (DataGridViewRow row in dgvDSSanBayTG.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var cellValue = row.Cells["TenSanBay"].Value;
                if (cellValue == null)
                    continue;

                string sanBayTG = cellValue.ToString();
                if (string.IsNullOrWhiteSpace(sanBayTG))
                    continue;

                selectedAirports.Add(sanBayTG);
            }

            return BUS_ChuyenBay.CheckDuplicateAirports(selectedAirports);
        }

        private void btnThemSanBay_Click(object sender, EventArgs e)
        {
            GUI_ThemSanBay frmThemSanBay = new GUI_ThemSanBay();
            frmThemSanBay.ShowDialog();
            LoadSanBayToComboBox(cbbSanBayDi);
            LoadSanBayToComboBox(cbbSanBayDen);
            ReloadSanBayComboBoxInDgv();
        }

        private void ReloadSanBayComboBoxInDgv()
        {
            List<DTO_SanBay> dsSanBay = BUS_SanBay.LayDanhSachSanBay();
            if (dsSanBay != null && dsSanBay.Count > 0)
            {
                DataGridViewComboBoxColumn colTenSanBay = (DataGridViewComboBoxColumn)dgvDSSanBayTG.Columns["TenSanBay"];
                colTenSanBay.DataSource = dsSanBay;
                colTenSanBay.DisplayMember = "TenSanBay";
                colTenSanBay.ValueMember = "MaSanBay";
            }
        }

        private void btnThemHangGhe_Click(object sender, EventArgs e)
        {
            GUI_ThemHangGhe frmThemHangGhe = new GUI_ThemHangGhe();
            frmThemHangGhe.ShowDialog();
        }

        private void cbbSanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSanBayDi.SelectedIndex != 0)
                errorProvider.SetError(cbbSanBayDi, string.Empty);
        }

        private void cbbSanBayDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSanBayDen.SelectedIndex != 0)
                errorProvider.SetError(cbbSanBayDen, string.Empty);
        }

        private void dtpNgayGioBay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayGioBay.Value <= DateTime.Now)
            {
                errorProvider.SetError(dtpNgayGioBay, "Ngày giờ bay phải sau thời điểm hiện tại");
            }
            else
            {
                errorProvider.SetError(dtpNgayGioBay, string.Empty);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
