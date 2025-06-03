using Guna.UI2.WinForms;
using QLBVBM.BUS;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBVBM.GUI
{
    public partial class GUI_TimChuyenBay : Form
    {
        private BUS_SanBay busSanBay = new BUS_SanBay();
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
        public DTO_ChuyenBay? thongTinChuyenBay { get; private set; }

        public GUI_TimChuyenBay()
        {
            InitializeComponent();
            SetResponsive();
            LoadDanhSachSanBayToComboBox(cbbSanBayDi, LayDanhSachSanBay());
            LoadDanhSachSanBayToComboBox(cbbSanBayDen, LayDanhSachSanBay());
            dtpNgayBay.Value = DateTime.Today.AddDays(1);
            dtpNgayBay.MinDate = DateTime.Today.AddDays(1); // Set the minimum date to today
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
            //cbb.Items.Clear();
            //cbb.Enabled = false;
            //cbb.Text = "";
            cbb.SelectedIndex = -1;
        }

        public List<DTO_SanBay> LayDanhSachSanBay()
        {
            List<DTO_SanBay> dsSanBay = busSanBay.LayDanhSachSanBay();
            dsSanBay.Insert(0, new DTO_SanBay { MaSanBay = "", TenSanBay = "" });
            return dsSanBay;
        }

        public void LoadDanhSachSanBayToComboBox(Guna2ComboBox cbb, List<DTO_SanBay> dsSanBay)
        {
            if (dsSanBay != null && dsSanBay.Count > 1) // since we add an empty item at index 0
            {
                cbb.DataSource = dsSanBay;
                cbb.DisplayMember = "TenSanBay";
                cbb.ValueMember = "MaSanBay";
                cbb.SelectedIndex = 0;

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

        private void FlightProps_Changed(object sender, EventArgs e)
        {
            string maSanBayDi = cbbSanBayDi.SelectedValue?.ToString() ?? string.Empty;
            string maSanBayDen = cbbSanBayDen.SelectedValue?.ToString() ?? string.Empty;
            DateTime ngayBay = new DateTime();

            bool isValidDate = dtpNgayBay.Value.Date > DateTime.Today.Date;

            if (isValidDate)
            {
                ngayBay = dtpNgayBay.Value.Date;
            }
            else
            {
                ngayBay = DateTime.MinValue;
            }

            List<DTO_ChuyenBay>? dsChuyenBayDuaVaoSanBayDi = string.IsNullOrWhiteSpace(maSanBayDi)
                ? null
                : busChuyenBay.LayTatCaChuyenBayConTrongDuaVaoSanBayDi(maSanBayDi);

            List<DTO_ChuyenBay>? dsChuyenBayDuaVaoSanBayDen = string.IsNullOrWhiteSpace(maSanBayDen)
                ? null
                : busChuyenBay.LayTatCaChuyenBayConTrongDuaVaoSanBayDen(maSanBayDen);

            List<DTO_ChuyenBay>? dsChuyenBayDuaVaoNgayBay = ngayBay == DateTime.MinValue
                ? null
                : busChuyenBay.LayTatCaChuyenBayConTrongDuaVaoNgayBay(ngayBay);

            List<DTO_ChuyenBay> result;

            // Combine not-null lists into a list
            var lists = new List<List<DTO_ChuyenBay>>();
            if (dsChuyenBayDuaVaoSanBayDi != null) lists.Add(dsChuyenBayDuaVaoSanBayDi);
            if (dsChuyenBayDuaVaoSanBayDen != null) lists.Add(dsChuyenBayDuaVaoSanBayDen);
            if (dsChuyenBayDuaVaoNgayBay != null) lists.Add(dsChuyenBayDuaVaoNgayBay);
            
            if (lists.Count == 0) // if all lists are null, return empty list
            {
                result = new List<DTO_ChuyenBay>();
            }
            else if (lists.Count == 1) // if only one list is not null, return that list
            {
                result = lists[0];
            }
            else
            {
                // get all unique MaChuyenBay from each list
                var keySets = lists
                    .Select(ls => new HashSet<string>(ls.Select(cb => cb.MaChuyenBay)))
                    .ToArray();

                // get the intersection of all sets
                result = lists[0]
                    .Where(cb => keySets.All(set => set.Contains(cb.MaChuyenBay)))
                    .ToList();
            }

            List<string> dsChuyenBayVaGioBay = new List<string>();
            foreach (var chuyenBay in result)
            {
                dsChuyenBayVaGioBay.Add($"{chuyenBay.MaChuyenBay}    -    Khởi hành: {chuyenBay.NgayBay?.ToString("dd/MM/yyyy")} {chuyenBay.GioBay?.ToString("HH:mm")}");
            }

            if (dsChuyenBayVaGioBay != null && dsChuyenBayVaGioBay.Count > 0)
            {
                LoadMaChuyenBay(cbbDSChuyenBay, dsChuyenBayVaGioBay);
            }
            else
            {
                ClearCombobox(cbbDSChuyenBay);
            }
        }

        public void LoadMaChuyenBay(Guna2ComboBox cbb, List<string> dsChuyenBayVaGioBay)
        {
            if (dsChuyenBayVaGioBay != null && dsChuyenBayVaGioBay.Count > 0)
            {
                cbb.Enabled = true; // turn on the combobox
                cbb.DataSource = dsChuyenBayVaGioBay;

                // Add tooltip to display MaChuyenBay
                ToolTip toolTip = new ToolTip();
                cbb.SelectedIndexChanged += (s, e) =>
                {
                    if (cbb.SelectedItem is DTO_ChuyenBay selectedChuyenBay)
                    {
                        toolTip.SetToolTip(cbb, selectedChuyenBay.GioBay.ToString());
                    }
                };
            }
        }

        public bool HasErrors()
        {
            if (cbbSanBayDi.SelectedIndex == -1
                || cbbSanBayDen.SelectedIndex == -1
                || cbbDSChuyenBay.SelectedIndex == -1)
            {
                return true;
            }
            return false;
        }

        private void btnTiepNhanChuyenBay_Click(object sender, EventArgs e)
        {
            if (HasErrors())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi tiếp tục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get first 7 characters (ex: CB00001)
            string maChuyenBay = cbbDSChuyenBay.SelectedItem.ToString().Substring(0, 7);
            thongTinChuyenBay = busChuyenBay.TimChuyenBayTheoMa(maChuyenBay);

            if (thongTinChuyenBay != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
