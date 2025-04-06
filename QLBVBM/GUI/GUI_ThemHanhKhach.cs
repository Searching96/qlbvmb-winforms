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
using Org.BouncyCastle.Math.Field;

namespace QLBVBM.GUI
{
    public partial class GUI_ThemHanhKhach : Form
    {
        private BUS_HanhKhach busHanhKhach = new BUS_HanhKhach();
        private ErrorProvider errorProvider = new ErrorProvider();

        public GUI_ThemHanhKhach()
        {
            InitializeComponent();
            PhatSinhMaHanhKhach();
            SetResponsive();
        }

        public void SetResponsive()
        {
            foreach (Control control in this.Controls)
            {
                control.Anchor = AnchorStyles.None;
            }
        }

        public void PhatSinhMaHanhKhach()
        {
            txtMaHanhKhach.Text = busHanhKhach.PhatSinhMaHanhKhach();
        }

        private void txtTenHanhKhach_TextChanged(object sender, EventArgs e)
        {
            if (!busHanhKhach.ValidateHoTen(txtTenHanhKhach.Text))
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
            if (!busHanhKhach.ValidateSDT(txtSDT.Text))
            {
                errorProvider.SetError(txtSDT, "Số điện thoại không hợp lệ");
            }
            else
            {
                errorProvider.SetError(txtSDT, string.Empty);
            }
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            if (!busHanhKhach.ValidateCMND(txtCMND.Text))
            {
                errorProvider.SetError(txtCMND, "CMND không hợp lệ");
            }
            else
            {
                errorProvider.SetError(txtCMND, string.Empty);
            }
        }

        private bool HasErrors()
        {
            // Check for errors in form controls
            foreach (Control control in this.Controls)
                if (errorProvider.GetError(control) != string.Empty)
                    return true;

            if (string.IsNullOrWhiteSpace(txtTenHanhKhach.Text) ||
                string.IsNullOrWhiteSpace(txtCMND.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                return true;
            }
            return false;
        }

        private void btnThemHanhKhach_Click(object sender, EventArgs e)
        {
            if (HasErrors())
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin nhập vào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_HanhKhach newHanhKhach = new DTO_HanhKhach
            {
                MaHanhKhach = txtMaHanhKhach.Text,
                HoTen = txtTenHanhKhach.Text,
                SoDT = txtSDT.Text,
                SoCMND = txtCMND.Text
            };

            if (busHanhKhach.ThemHanhKhach(newHanhKhach))
            {
                MessageBox.Show("Thêm hành khách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm hành khách thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
