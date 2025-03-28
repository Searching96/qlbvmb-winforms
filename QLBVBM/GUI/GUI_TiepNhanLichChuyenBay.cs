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
        private BUS_CTChuyenBay BUS_CTChuyenBay = new BUS_CTChuyenBay();
        private BUS_HangVeCB BUS_HangVeCB = new BUS_HangVeCB();
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

        private void SetupDgvColumns(DataGridView dgv, int rowCount, List<DTO_SanBay> dsSanBay)
        {
            dgv.Columns.Clear();
            dgv.RowHeadersVisible = false;

            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn
            {
                Name = "STT",
                HeaderText = "STT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 50,
                ReadOnly = true
            };
            dgv.Columns.Add(colSTT);

            DataGridViewComboBoxColumn colTenSanBay = new DataGridViewComboBoxColumn
            {
                Name = "TenSanBay",
                HeaderText = "Tên sân bay",
                DataSource = dsSanBay,
                DisplayMember = "TenSanBay",
                ValueMember = "MaSanBay"
            };
            dgv.Columns.Add(colTenSanBay);

            DataGridViewTextBoxColumn colThoiGianDung = new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianDung",
                HeaderText = "Thời gian dừng (phút)",
            };
            dgv.Columns.Add(colThoiGianDung);

            DataGridViewTextBoxColumn colGhiChu = new DataGridViewTextBoxColumn
            {
                Name = "GhiChu",
                HeaderText = "Ghi chú"
            };
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
            {
                errorProvider.SetError(txtThoiGianBay, "Thời gian bay không được để trống");
            }
            if (string.IsNullOrEmpty(txtSoLuongGheHang1.Text))
            {
                errorProvider.SetError(txtSoLuongGheHang1, "Số lượng ghế hạng 1 không được để trống");
            }
            if (string.IsNullOrEmpty(txtSoLuongGheHang2.Text))
            {
                errorProvider.SetError(txtSoLuongGheHang2, "Số lượng ghế hạng 2 không được để trống");
            }

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

            if (BUS_ChuyenBay.ThemChuyenBay(chuyenBayMoi))
            {
                LuuCTChuyenBay(chuyenBayMoi.MaChuyenBay);
                LuuHangVeCB(chuyenBayMoi.MaChuyenBay);
                MessageBox.Show("Tiếp nhận lịch chuyến bay thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PhatSinhMaChuyenBay();
            }
            else
            {
                MessageBox.Show("Tiếp nhận lịch chuyến bay thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // it might be bool here, but I will change it later on
        private void LuuCTChuyenBay(string maChuyenBay)
        {
            foreach (DataGridViewRow row in dgvDSSanBayTG.Rows)
            {
                if (row.IsNewRow)
                    continue;

                // Retrieve values from required cells.
                var tenSanBay = row.Cells["TenSanBay"].Value?.ToString();
                var thoiGianDungText = row.Cells["ThoiGianDung"].Value?.ToString();

                // If both required fields are empty, skip this row.
                if (string.IsNullOrWhiteSpace(tenSanBay) && string.IsNullOrWhiteSpace(thoiGianDungText))
                    continue;

                // Optionally, if ThoiGianDung must be valid, try parsing it.
                if (!int.TryParse(thoiGianDungText, out int thoiGianDung))
                {
                    // Skip row or handle the parsing error as needed.
                    continue;
                }

                var ghiChu = row.Cells["GhiChu"].Value?.ToString();
                DTO_CTChuyenBay ctChuyenBay = new DTO_CTChuyenBay
                {
                    MaChuyenBay = maChuyenBay,
                    MaSanBayTG = tenSanBay,
                    ThoiGianDung = thoiGianDung,
                    GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? string.Empty : ghiChu
                };

                BUS_CTChuyenBay.ThemCTChuyenBay(ctChuyenBay);
            }
        }

        // it might be bool here, but I will change it later on
        private void LuuHangVeCB(string maChuyenBay)
        {
            DTO_HangVeCB hangVeHang1 = new DTO_HangVeCB
            {
                MaChuyenBay = maChuyenBay,
                MaHangGhe = "HG00001", // here I'm hardcoding it, but it should be changed later on
                SoLuongGhe = int.Parse(txtSoLuongGheHang1.Text)
            };

            DTO_HangVeCB hangVeHang2 = new DTO_HangVeCB
            {
                MaChuyenBay = maChuyenBay,
                MaHangGhe = "HG00002", // here I'm hardcoding it, but it should be changed later on
                SoLuongGhe = int.Parse(txtSoLuongGheHang2.Text)
            };

            BUS_HangVeCB.ThemHangVeCB(hangVeHang1);
            BUS_HangVeCB.ThemHangVeCB(hangVeHang2);
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
    }
}
