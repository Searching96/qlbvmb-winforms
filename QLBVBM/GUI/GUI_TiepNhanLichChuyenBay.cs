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
    public partial class GUI_TiepNhanLichChuyenBay : Form
    {
        private BUS_SanBay BUS_SanBay = new BUS_SanBay();
        private BUS_ChuyenBay BUS_ChuyenBay = new BUS_ChuyenBay();
        private BUS_ThamSo BUS_ThamSo = new BUS_ThamSo();
        private BUS_HangGhe BUS_HangGhe = new BUS_HangGhe();

        private List<Guna2ComboBox> lstComboBoxHangGhe = new List<Guna2ComboBox>();
        private List<Tuple<DTO_HangGhe, Guna2TextBox, Guna2TextBox>> lstTextBoxSoLuongVaDonGiaGhe = new List<Tuple<DTO_HangGhe, Guna2TextBox, Guna2TextBox>>();

        private ErrorProvider errorProvider = new ErrorProvider();

        private List<DTO_HangGhe> dsHangGhe = new List<DTO_HangGhe>();
        private List<DTO_HangGhe> dsHangGheDaChon = new List<DTO_HangGhe>();

        // variables for dynamic HangGhe_ComboBox creation
        private int currentComboBoxCount = 0;
        private const int maxComboBoxPerRow = 2;
        private const int maxComboBox = 4;
        private const int verticalSpacing = 70;
        private const int horizontalSpacing = 396;

        public GUI_TiepNhanLichChuyenBay()
        {
            InitializeComponent();

            SetupDgvColumns(dgvDSSanBayTG, BUS_ThamSo.LaySoLuongSanBayToiDa(), LayDanhSachSanBay());
            PhatSinhMaChuyenBay();
            LoadSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
            LoadSanBayToComboBox(cbbSanBayDen, LayDanhSachSanBay());
            LayDanhSachHangGhe();
        }

        public void FixScale()
        {
            foreach (Control control in this.Controls)
            {
                
            }
        }

        private List<DTO_SanBay> LayDanhSachSanBay()
        {
            var dsSanBay = BUS_SanBay.LayDanhSachSanBay();
            dsSanBay.Insert(0, new DTO_SanBay { MaSanBay = "", TenSanBay = "" });
            return dsSanBay;
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

        private void LayDanhSachHangGhe()
        {
            dsHangGhe = BUS_HangGhe.LayDanhSachHangGhe();
            dsHangGhe.Insert(0, new DTO_HangGhe { MaHangGhe = "", TenHangGhe = "" });
        }

        private void LoadHangGheToComboBox(ComboBox cbb, List<DTO_HangGhe> dsHangGhe)
        {
            if (dsHangGhe != null && dsHangGhe.Count > 1) // since we add an empty item at index 0
            {
                cbb.DataSource = dsHangGhe;
                cbb.DisplayMember = "TenHangGhe";
                cbb.ValueMember = "MaHangGhe";
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

            // Display MaSanBay in TenSanBay ComboBoxCell as tooltip
            dgv.CellToolTipTextNeeded += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && dgv.Columns[e.ColumnIndex].Name == "TenSanBay" && e.RowIndex >= 0)
                {
                    var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
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

        private void btnTiepNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtThoiGianBay.Text))
                errorProvider.SetError(txtThoiGianBay, "Thời gian bay không được để trống");
            if (cbbSanBayDi.SelectedIndex == 0)
                errorProvider.SetError(cbbSanBayDi, "Sân bay đi không được để trống");
            if (cbbSanBayDen.SelectedIndex == 0)
                errorProvider.SetError(cbbSanBayDen, "Sân bay đến không được để trống");

            foreach (var tuple in lstTextBoxSoLuongVaDonGiaGhe)
            {
                if (string.IsNullOrEmpty(tuple.Item2.Text))
                    errorProvider.SetError(tuple.Item2, "Số lượng ghế không được để trống");
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
            foreach (var tuple in lstTextBoxSoLuongVaDonGiaGhe)
            {
                if (!int.TryParse(tuple.Item2.Text, out int soLuongGhe))
                    continue;
                if (!int.TryParse(tuple.Item3.Text, out int donGia))
                    continue;
                DTO_HangVeCB hangVeCB = new DTO_HangVeCB
                {
                    MaChuyenBay = chuyenBayMoi.MaChuyenBay,
                    MaHangGhe = tuple.Item1.MaHangGhe,
                    SoLuongGhe = soLuongGhe,
                    DonGia = donGia                   
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonHangGhe_Click(object sender, EventArgs e)
        {
            Guna2ComboBox cbbHangGhe = new Guna2ComboBox
            {
                Location = new Point(btnChonHangGhe.Location.X, btnChonHangGhe.Location.Y),
                Width = 320,
                Height = 38,
                Anchor = AnchorStyles.None,
                BorderRadius = 10
            };

            currentComboBoxCount++;
            if (currentComboBoxCount >= maxComboBoxPerRow)
            {
                currentComboBoxCount = 0;
                btnChonHangGhe.Location = new Point(btnChonHangGhe.Location.X - horizontalSpacing, btnChonHangGhe.Location.Y + verticalSpacing);
            }

            bool isInitialized = false;

            cbbHangGhe.SelectedIndexChanged += (s, ev) =>
            {
                if (isInitialized && cbbHangGhe.SelectedIndex != 0)
                {
                    DTO_HangGhe selectedHangGhe = (DTO_HangGhe)cbbHangGhe.SelectedItem;
                    dsHangGheDaChon.Add(selectedHangGhe);
                    UpdateHangGheComboBoxes();

                    string tenHangGhe = selectedHangGhe.TenHangGhe;

                    Label lblHangGhe = new Label
                    {
                        Location = new Point(cbbHangGhe.Location.X, cbbHangGhe.Location.Y - 10), // -10 to align with the top of the ComboBox
                        Text = $"Số lượng ghế {tenHangGhe}",
                        AutoSize = true,
                        Anchor = AnchorStyles.None,
                        Font = new Font("Arial", 11, FontStyle.Regular)
                    };

                    Label lblDonGia = new Label
                    {
                        Location = new Point(lblHangGhe.Location.X + 230, lblHangGhe.Location.Y), // +160 to align with the right of lblHangGhe
                        Text = $"Đơn giá",
                        AutoSize = true,
                        Anchor = AnchorStyles.None,
                        Font = new Font("Arial", 11, FontStyle.Regular)
                    };

                    Guna2TextBox txtSoLuongGhe = new Guna2TextBox
                    {
                        Location = new Point(lblHangGhe.Location.X,
                            lblHangGhe.Location.Y + lblHangGhe.Height + 5 - 6), // -6 to align with the bottom of the Label
                        Width = 210,
                        Height = 38,
                        Anchor = AnchorStyles.None,
                        Font = new Font("Arial", 11, FontStyle.Regular),
                        BorderRadius = 10
                    };

                    txtSoLuongGhe.TextChanged += (s, ev) =>
                    {
                        if (!BUS_ChuyenBay.ValidateSoLuongGhe(txtSoLuongGhe.Text))
                        {
                            errorProvider.SetError(txtSoLuongGhe, "Số lượng ghế phải là số nguyên không âm");
                        }
                        else
                        {
                            errorProvider.SetError(txtSoLuongGhe, string.Empty);
                        }
                    };

                    Guna2TextBox txtDonGia = new Guna2TextBox
                    {
                        Location = new Point(lblDonGia.Location.X,
                            lblDonGia.Location.Y + lblDonGia.Height + 5 - 6), // -6 to align with the bottom of the Label
                        Width = 150,
                        Height = 38,
                        Anchor = AnchorStyles.None,
                        Font = new Font("Arial", 11, FontStyle.Regular),
                        BorderRadius = 10
                    };

                    txtDonGia.TextChanged += (s, ev) =>
                    {
                        if (!BUS_ChuyenBay.ValidateSoLuongGhe(txtDonGia.Text)) // Assuming the same validation for simplicity
                        {
                            errorProvider.SetError(txtDonGia, "Đơn giá phải là số nguyên không âm");
                        }
                        else
                        {
                            errorProvider.SetError(txtDonGia, string.Empty);
                        }
                    };

                    this.Controls.Add(lblHangGhe);
                    this.Controls.Add(txtSoLuongGhe);
                    this.Controls.Add(lblDonGia);
                    this.Controls.Add(txtDonGia);

                    cbbHangGhe.Visible = false;

                    lstTextBoxSoLuongVaDonGiaGhe.Add(new Tuple<DTO_HangGhe, Guna2TextBox, Guna2TextBox>(selectedHangGhe, txtSoLuongGhe, txtDonGia));
                }
            };

            LoadHangGheToComboBox(cbbHangGhe, dsHangGhe.Except(dsHangGheDaChon).ToList());
            isInitialized = true;

            this.Controls.Add(cbbHangGhe);
            lstComboBoxHangGhe.Add(cbbHangGhe);

            if (currentComboBoxCount % 2 == 1)
                btnChonHangGhe.Location = new Point(btnChonHangGhe.Location.X + horizontalSpacing, btnChonHangGhe.Location.Y);

            if (lstComboBoxHangGhe.Count >= maxComboBox)
                btnChonHangGhe.Visible = false;
        }

        private void UpdateHangGheComboBoxes()
        {
            foreach (var comboBox in lstComboBoxHangGhe)
            {
                LoadHangGheToComboBox(comboBox, dsHangGhe.Except(dsHangGheDaChon).ToList());
            }
        }
    }
}
