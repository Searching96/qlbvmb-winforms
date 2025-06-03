using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBVBM.DAL;
using QLBVBM.DTO;
using QLBVBM.BUS;
using Guna.UI2.WinForms;

namespace QLBVBM.GUI
{
    public partial class UC_BanVe : UserControl
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
        private BUS_ValidateThongTinHanhKhach busValidationTTHK = new BUS_ValidateThongTinHanhKhach();
        private BUS_DonGiaHangGhe busDonGiaHangGhe = new BUS_DonGiaHangGhe();
        private BUS_VeChuyenBay busVeChuyenBay = new BUS_VeChuyenBay();
        private ErrorProvider errorProvider = new ErrorProvider();

        public UC_BanVe()
        {
            InitializeComponent();
            var dsChuyenBay = LayDanhSachChuyenBay();
            dsChuyenBay.Sort((a, b) => string.Compare(a.MaChuyenBay, b.MaChuyenBay, StringComparison.Ordinal));
            LoadMaChuyenBayToComboBox(cbbMaChuyenBay, dsChuyenBay);
            cbbMaChuyenBay.DropDownStyle = ComboBoxStyle.DropDownList;
            SetResponsive();
        }

        private List<DTO_ChuyenBay> LayDanhSachChuyenBay()
        {
            List<DTO_ChuyenBay> dsChuyenBay = busChuyenBay.LayTatCaChuyenBayConGheTrong();
            return dsChuyenBay;
        }

        public void LoadMaChuyenBayToComboBox(Guna2ComboBox cbb, List<DTO_ChuyenBay> dsChuyenBay)
        {
            if (dsChuyenBay != null && dsChuyenBay.Count > 0)
            {
                cbb.DataSource = dsChuyenBay;
                cbb.DisplayMember = "MaChuyenBay";
                cbb.ValueMember = "MaChuyenBay";
                cbb.SelectedItem = dsChuyenBay[0];
                // Add tooltip to display MaChuyenBay

                ToolTip toolTip = new ToolTip();
                cbb.SelectedIndexChanged += (s, e) =>
                {
                    if (cbb.SelectedItem is DTO_ChuyenBay selectedChuyenBay)
                    {
                        toolTip.SetToolTip(cbb, selectedChuyenBay.MaChuyenBay);
                    }
                };
            }
        }

        public void SetResponsive()
        {
            foreach (Control control in this.Controls)
            {
                control.Anchor = AnchorStyles.None;
            }
        }

        public void ClearCombobox(Guna2ComboBox cbb) // clear the combobox and set it to disabled
        {
            cbb.DataSource = null;
            cbb.SelectedIndex = -1;
        }

        private void btnTimChuyenBay_Click(object sender, EventArgs e)
        {
            GUI_TimChuyenBay guiTimChuyenBay = new GUI_TimChuyenBay();

            if (guiTimChuyenBay.ShowDialog() == DialogResult.OK)
            {
                DTO_ChuyenBay? chuyenBay = new DTO_ChuyenBay();
                chuyenBay = guiTimChuyenBay.thongTinChuyenBay;
                if (chuyenBay != null)
                {
                    cbbMaChuyenBay.SelectedValue = chuyenBay.MaChuyenBay;
                    txtSanBayDi.Text = busSanBay.LayTenSanBay(chuyenBay.MaSanBayDi);
                    txtSanBayDen.Text = busSanBay.LayTenSanBay(chuyenBay.MaSanBayDen);
                    dtpNgayBay.Value = chuyenBay.NgayBay.Value;
                    txtGioBay.Text = chuyenBay.GioBay?.ToString("HH:mm");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chuyến bay nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearCombobox(cbbHangVe);
                }
            }
        }

        private void cbbMaChuyenBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaChuyenBay.SelectedIndex == -1)
            {
                txtGioBay.Text = string.Empty;
            }
            else
            {
                DTO_ChuyenBay selectedChuyenBay = cbbMaChuyenBay.SelectedItem as DTO_ChuyenBay;

                if (selectedChuyenBay != null)
                {
                    txtSanBayDi.Text = busSanBay.LayTenSanBay(selectedChuyenBay.MaSanBayDi);
                    txtSanBayDen.Text = busSanBay.LayTenSanBay(selectedChuyenBay.MaSanBayDen);
                    dtpNgayBay.Value = selectedChuyenBay.NgayBay.Value;
                    txtGioBay.Text = selectedChuyenBay.GioBay?.ToString("HH:mm");
                    List<DTO_DonGiaHangGhe> dsHangGhe = busDonGiaHangGhe.LayDanhSachTenHangGheChuyenBay(selectedChuyenBay?.MaChuyenBay);
                    LoadDanhSachHangVeCB(dsHangGhe);
                }
                else
                {
                    ClearCombobox(cbbHangVe);
                }
            }
        }

        public void LoadDanhSachHangVeCB(List<DTO_DonGiaHangGhe> dsHangVeCB)
        {
            if (dsHangVeCB != null)
            {
                cbbHangVe.DataSource = dsHangVeCB;
                cbbHangVe.DisplayMember = "TenHangGhe";
                cbbHangVe.ValueMember = "MaHangGhe";
                // Add tooltip to display MaHangGhe
                ToolTip toolTip = new ToolTip();
                cbbHangVe.SelectedIndexChanged += (s, e) =>
                {
                    if (cbbHangVe.SelectedItem is DTO_DonGiaHangGhe selectedHangVe)
                    {
                        toolTip.SetToolTip(cbbHangVe, selectedHangVe.MaHangGhe);
                    }
                };
            }
            else
            {
                ClearCombobox(cbbHangVe);
            }
        }

        private void cbbHangVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbHangVe.SelectedIndex == -1)
            {
                txtGiaTien.Text = "";
            }
            else
            {
                if (cbbHangVe.SelectedItem is DTO_DonGiaHangGhe selectedHangVe)
                {
                    txtGiaTien.Text = selectedHangVe.DonGia.ToString() ?? "";
                }
            }
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            if (!busValidationTTHK.ValidateCMND(txtCMND.Text))
            {
                errorProvider.SetError(txtCMND, "CMND không hợp lệ");
            }
            else
            {
                errorProvider.SetError(txtCMND, string.Empty);
            }
        }

        private void txtTenHanhKhach_TextChanged(object sender, EventArgs e)
        {
            if (!busValidationTTHK.ValidateHoTen(txtTenHanhKhach.Text))
            {
                errorProvider.SetError(txtTenHanhKhach, "Tên hành khách không hợp lệ");
            }
            else
            {
                errorProvider.SetError(txtTenHanhKhach, string.Empty);
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (!busValidationTTHK.ValidateSDT(txtSDT.Text))
            {
                errorProvider.SetError(txtSDT, "Số điện thoại không hợp lệ");
            }
            else
            {
                errorProvider.SetError(txtSDT, string.Empty);
            }
        }

        private bool HasErrors()
        {
            // Check for errors in form controls
            if (cbbMaChuyenBay.SelectedIndex == -1
                || string.IsNullOrWhiteSpace(txtSanBayDi.Text)
                || string.IsNullOrWhiteSpace(txtSanBayDen.Text)
                || string.IsNullOrWhiteSpace(txtGioBay.Text)
                || string.IsNullOrWhiteSpace(txtGiaTien.Text)
                || string.IsNullOrWhiteSpace(txtTenHanhKhach.Text)
                || string.IsNullOrWhiteSpace(txtCMND.Text)
                || string.IsNullOrWhiteSpace(txtSDT.Text)
                || cbbHangVe.SelectedIndex == -1
                || !busValidationTTHK.ValidateSDT(txtSDT.Text)
                || !busValidationTTHK.ValidateCMND(txtCMND.Text)
                || !busValidationTTHK.ValidateHoTen(txtTenHanhKhach.Text))
                return true;

            foreach (Control control in this.Controls)
            {
                if (errorProvider.GetError(control) != string.Empty)
                    return true;
            }

            return false;
        }

        private void btnLuuVe_Click(object sender, EventArgs e)
        {
            if (HasErrors())
            {
                MessageBox.Show("Vui lòng sửa các lỗi trước khi tiếp tục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_VeChuyenBay veChuyenBay = new DTO_VeChuyenBay
            {
                MaVe = busVeChuyenBay.PhatSinhMaVeChuyenBay(),
                MaChuyenBay = cbbMaChuyenBay.SelectedValue.ToString(), // change to txtBox
                MaHangGhe = cbbHangVe.SelectedValue.ToString(),
                TenHanhKhach = txtTenHanhKhach.Text,
                SoCMND = txtCMND.Text,
                SoDT = txtSDT.Text,
                DonGia = int.Parse(txtGiaTien.Text),
                TrangThaiVe = 1
            };

            DTO_HangVeCB hangVeCB = new DTO_HangVeCB
            {
                MaChuyenBay = cbbMaChuyenBay.SelectedValue.ToString(),
                MaHangGhe = cbbHangVe.SelectedValue.ToString()
            };


            bool success = busVeChuyenBay.ThemVeChuyenBayVaHangVe(veChuyenBay, hangVeCB);

            MessageBox.Show(success ? "Thêm vé thành công" : "Lỗi khi thêm vé",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void btnInVe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}