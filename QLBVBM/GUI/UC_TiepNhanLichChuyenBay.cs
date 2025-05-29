using Guna.UI2.WinForms;
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
    public partial class UC_TiepNhanLichChuyenBay : UserControl
    {
        private BUS_SanBay BUS_SanBay = new BUS_SanBay();
        private BUS_ChuyenBay BUS_ChuyenBay = new BUS_ChuyenBay();
        private BUS_ThamSo BUS_ThamSo = new BUS_ThamSo();
        private BUS_HangGhe BUS_HangGhe = new BUS_HangGhe();

        private ErrorProvider errorProvider = new ErrorProvider();

        public UC_TiepNhanLichChuyenBay()
        {
            InitializeComponent();

            SetupDgvDSSBTGColumns(BUS_ThamSo.LaySoLuongSanBayToiDa(), LayDanhSachSanBay());
            SetupDgvDSHGColumns(LayDanhSachHangGhe());
            PhatSinhMaChuyenBay();
            LoadSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
            LoadSanBayToComboBox(cbbSanBayDen, LayDanhSachSanBay());
        }

        private List<DTO_SanBay> LayDanhSachSanBay()
        {
            var dsSanBay = BUS_SanBay.LayDanhSachSanBay();
            dsSanBay.Insert(0, new DTO_SanBay { MaSanBay = "", TenSanBay = "" });
            return dsSanBay;
        }

        private List<DTO_HangGhe> LayDanhSachHangGhe()
        {
            var dsHangGhe = BUS_HangGhe.LayDanhSachHangGhe();
            dsHangGhe.Insert(0, new DTO_HangGhe { MaHangGhe = "", TenHangGhe = "" });
            return dsHangGhe;
        }

        private void LoadSanBayToComboBox(ComboBox cbb, List<DTO_SanBay> dsSanBay)
        {
            if (dsSanBay != null && dsSanBay.Count > 1) // since we add an empty item at index 0
            {
                cbb.DataSource = dsSanBay;
                cbb.DisplayMember = "TenSanBay";
                cbb.ValueMember = "MaSanBay";

                // Add tooltip to display MaSanBay
                ToolTip toolTip = new ToolTip();
                cbb.SelectedIndexChanged += (s, e) =>
                {
                    if (cbb.SelectedItem is DTO_SanBay selectedSanBay)
                    {
                        toolTip.SetToolTip(cbb, selectedSanBay.MaSanBay);
                    }
                };
            }
        }

        private void PhatSinhMaChuyenBay()
        {
            txtMaChuyenBay.Text = BUS_ChuyenBay.PhatSinhMaChuyenBay();
        }

        private void SetupDgvDSHGColumns(List<DTO_HangGhe> dsHangGhe)
        {
            dgvDSHangGhe.Columns.Clear();
            dgvDSHangGhe.RowHeadersVisible = false;
            dgvDSHangGhe.AllowUserToAddRows = false;

            // Set the theme to grey color
            dgvDSHangGhe.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvDSHangGhe.ThemeStyle.BackColor = Color.White;
            dgvDSHangGhe.ThemeStyle.GridColor = Color.LightGray;
            dgvDSHangGhe.ThemeStyle.HeaderStyle.BackColor = Color.White;
            dgvDSHangGhe.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            dgvDSHangGhe.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvDSHangGhe.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvDSHangGhe.ThemeStyle.RowsStyle.SelectionBackColor = Color.LightGray;
            dgvDSHangGhe.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;

            // Define the font for the header cells
            Font headerFont = new Font("Arial", 11, FontStyle.Regular);

            // Set the header row color to grey
            dgvDSHangGhe.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvDSHangGhe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDSHangGhe.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgvDSHangGhe.EnableHeadersVisualStyles = false;

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
            dgvDSHangGhe.Columns.Add(colSTT);

            DataGridViewComboBoxColumn colTenHangGhe = new DataGridViewComboBoxColumn
            {
                Name = "TenHangGhe",
                HeaderText = "Tên hạng ghế",
                DataSource = dsHangGhe,
                DisplayMember = "TenHangGhe",
                ValueMember = "MaHangGhe",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FlatStyle = FlatStyle.Flat
            };
            colTenHangGhe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTenHangGhe.HeaderCell.Style.Font = headerFont;
            dgvDSHangGhe.Columns.Add(colTenHangGhe);

            DataGridViewTextBoxColumn colSoLuongGhe = new DataGridViewTextBoxColumn
            {
                Name = "SoLuongGhe",
                HeaderText = "Số lượng ghế"
            };
            colSoLuongGhe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoLuongGhe.HeaderCell.Style.Font = headerFont;
            dgvDSHangGhe.Columns.Add(colSoLuongGhe);

            dgvDSHangGhe.Rows.Clear();
            for (int i = 0; i < 2; i++)
            {
                dgvDSHangGhe.Rows.Add(i + 1, "", "", "");
            }

            // Display MaHangGhe in TenHangGhe ComboBoxCell as tooltip
            dgvDSHangGhe.CellToolTipTextNeeded += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && dgvDSSanBayTG.Columns[e.ColumnIndex].Name == "TenHangGhe" && e.RowIndex >= 0)
                {
                    var cell = dgvDSHangGhe.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    if (cell?.Value != null)
                    {
                        e.ToolTipText = cell.Value.ToString();
                    }
                }
            };
        }

        private void SetupDgvDSSBTGColumns(int rowCount, List<DTO_SanBay> dsSanBay)
        {
            dgvDSSanBayTG.Columns.Clear();
            dgvDSSanBayTG.RowHeadersVisible = false;
            dgvDSSanBayTG.AllowUserToAddRows = false;

            // Set the theme to grey color
            dgvDSSanBayTG.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvDSSanBayTG.ThemeStyle.BackColor = Color.White;
            dgvDSSanBayTG.ThemeStyle.GridColor = Color.LightGray;
            dgvDSSanBayTG.ThemeStyle.HeaderStyle.BackColor = Color.White;
            dgvDSSanBayTG.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            dgvDSSanBayTG.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvDSSanBayTG.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvDSSanBayTG.ThemeStyle.RowsStyle.SelectionBackColor = Color.LightGray;
            dgvDSSanBayTG.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;

            // Define the font for the header cells
            Font headerFont = new Font("Arial", 11, FontStyle.Regular);

            // Set the header row color to grey
            dgvDSSanBayTG.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvDSSanBayTG.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDSSanBayTG.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgvDSSanBayTG.EnableHeadersVisualStyles = false;

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
            dgvDSSanBayTG.Columns.Add(colSTT);

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
            dgvDSSanBayTG.Columns.Add(colTenSanBay);

            DataGridViewTextBoxColumn colThoiGianDung = new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianDung",
                HeaderText = "Thời gian dừng (phút)"
            };
            colThoiGianDung.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colThoiGianDung.HeaderCell.Style.Font = headerFont;
            dgvDSSanBayTG.Columns.Add(colThoiGianDung);

            DataGridViewTextBoxColumn colGhiChu = new DataGridViewTextBoxColumn
            {
                Name = "GhiChu",
                HeaderText = "Ghi chú"
            };
            colGhiChu.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colGhiChu.HeaderCell.Style.Font = headerFont;
            dgvDSSanBayTG.Columns.Add(colGhiChu);

            dgvDSSanBayTG.Rows.Clear();
            for (int i = 0; i < rowCount; i++)
            {
                dgvDSSanBayTG.Rows.Add(i + 1, "", "", "");
            }

            // Display MaSanBay in TenSanBay ComboBoxCell as tooltip
            dgvDSSanBayTG.CellToolTipTextNeeded += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && dgvDSSanBayTG.Columns[e.ColumnIndex].Name == "TenSanBay" && e.RowIndex >= 0)
                {
                    var cell = dgvDSSanBayTG.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    if (cell?.Value != null)
                    {
                        e.ToolTipText = cell.Value.ToString();
                    }
                }
            };
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

        private bool HasIncompleteHangGheRowInput()
        {
            foreach (DataGridViewRow row in dgvDSHangGhe.Rows)
            {
                if (row.IsNewRow)
                    continue;

                bool anyFieldFilled = false;
                bool anyFieldEmpty = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string colName = dgvDSHangGhe.Columns[cell.ColumnIndex].Name;

                    // Skip non-required columns (for example, "STT")
                    if (colName == "STT")
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

            if (CheckDuplicateSeatClasses())
            {
                MessageBox.Show("Có hạng ghế xuất hiện nhiều hơn một lần.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (HasIncompleteSanBayTGRowInput())
            {
                MessageBox.Show("Có hàng trong danh sách sân bay trung gian chưa được nhập đầy đủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (HasIncompleteHangGheRowInput())
            {
                MessageBox.Show("Có hàng trong danh sách hạng ghế chưa được nhập đầy đủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_ChuyenBay chuyenBayMoi = new DTO_ChuyenBay
            {
                MaChuyenBay = txtMaChuyenBay.Text,
                MaSanBayDi = cbbSanBayDi.SelectedValue.ToString(),
                MaSanBayDen = cbbSanBayDen.SelectedValue.ToString(),
                NgayBay = dtpNgayBay.Value,
                GioBay = dtpGioBay.Value,
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

            List<DTO_HangVeCB> dsHangVeCB = new List<DTO_HangVeCB>();
            foreach (DataGridViewRow row in dgvDSHangGhe.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var maHangGhe = row.Cells["TenHangGhe"].Value?.ToString();
                var textSoLuongGhe = row.Cells["SoLuongGhe"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(maHangGhe)
                    && string.IsNullOrWhiteSpace(textSoLuongGhe))
                    continue;

                if (!int.TryParse(textSoLuongGhe, out int soLuongGhe))
                    continue;

                DTO_HangVeCB hangVeCB = new DTO_HangVeCB
                {
                    MaChuyenBay = chuyenBayMoi.MaChuyenBay,
                    MaHangGhe = maHangGhe,
                    SoLuongGhe = soLuongGhe,
                    SoLuongGheConLai = soLuongGhe
                };

                dsHangVeCB.Add(hangVeCB);
            }

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
            List<string> selectedAirportIds = new List<string>();
            string maSanBayDi = cbbSanBayDi.SelectedValue?.ToString();
            string maSanBayDen = cbbSanBayDen.SelectedValue?.ToString();

            if (!string.IsNullOrWhiteSpace(maSanBayDi))
                selectedAirportIds.Add(maSanBayDi);

            if (!string.IsNullOrWhiteSpace(maSanBayDen))
                selectedAirportIds.Add(maSanBayDen);

            foreach (DataGridViewRow row in dgvDSSanBayTG.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var cellValue = row.Cells["TenSanBay"].Value;
                if (cellValue == null)
                    continue;

                string maSanBayTG = cellValue.ToString();
                if (string.IsNullOrWhiteSpace(maSanBayTG))
                    continue;

                selectedAirportIds.Add(maSanBayTG);
            }

            return BUS_ChuyenBay.CheckDuplicateAirports(selectedAirportIds);
        }

        private void btnThemSanBay_Click(object sender, EventArgs e)
        {
            GUI_ThemSanBay frmThemSanBay = new GUI_ThemSanBay();
            frmThemSanBay.ShowDialog();
            LoadSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
            LoadSanBayToComboBox(cbbSanBayDen, LayDanhSachSanBay());
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
            if (dtpNgayBay.Value <= DateTime.Now)
            {
                errorProvider.SetError(dtpNgayBay, "Ngày giờ bay phải sau thời điểm hiện tại");
            }
            else
            {
                errorProvider.SetError(dtpNgayBay, string.Empty);
            }
        }

        private void dgvDSHangGhe_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDSHangGhe.Columns[e.ColumnIndex].Name == "SoLuongGhe")
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    dgvDSHangGhe.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                    return;
                }

                if (!int.TryParse(e.FormattedValue.ToString(), out int soLuongGhe) || soLuongGhe <= 0)
                {
                    dgvDSSanBayTG.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText =
                        $"Số lượng ghế phải là số nguyên dương";
                }
                else
                {
                    dgvDSSanBayTG.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                }
            }
        }

        private bool CheckDuplicateSeatClasses()
        {
            List<string> selectedSeatClassIds = new List<string>();

            foreach (DataGridViewRow row in dgvDSHangGhe.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var cellValue = row.Cells["TenHangGhe"].Value;
                if (cellValue == null)
                    continue;

                string maHangGhe = cellValue.ToString();
                if (string.IsNullOrWhiteSpace(maHangGhe))
                    continue;

                selectedSeatClassIds.Add(maHangGhe);
            }

            return BUS_ChuyenBay.CheckDuplicateSeatClasses(selectedSeatClassIds);
        }
    }
}