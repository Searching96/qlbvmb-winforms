using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBVBM.BUS;
using QLBVBM.DTO;

namespace QLBVBM.GUI
{
    public partial class GUI_LapBaoCao : Form
    {
        private BUS_VeChuyenBay busVeChuyenBay = new BUS_VeChuyenBay();
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();

        public GUI_LapBaoCao()
        {
            InitializeComponent();
            SetResponsive();

        }
        public void SetResponsive()
        {
            foreach (Control control in this.Controls)
            {
                control.Anchor = AnchorStyles.None;
            }
        }
        private void btnLapBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            dgvBaoCaoDoanhThu.Rows.Clear();
            txtTongDoanhThu.Text = "";

            int thang = dtpThangBaoCao.Value.Month;
            int nam = dtpNamBaoCao.Value.Year;

            List<DTO_ChuyenBay> dsChuyenBay = busChuyenBay.LayTatCaChuyenBayDuaVaoThangNamBay(thang, nam);

            //lay ve da thanh toan theo chuyen bay
            if (dsChuyenBay != null && dsChuyenBay.Count > 0)
            {
                List<DTO_VeChuyenBay> dsVeChuyenBayDaThanhToan = new List<DTO_VeChuyenBay>();
                
                dsVeChuyenBayDaThanhToan = busVeChuyenBay.LayVeThanhToanTheoChuyenBay(dsChuyenBay);

                dgvBaoCaoDoanhThu.Rows.Clear();

                //tong doanh thu
                var tongDoanhThu = dsVeChuyenBayDaThanhToan
                    .Sum(h => h.DonGia);
                txtTongDoanhThu.Text = string.Format("{0:0,0}", tongDoanhThu);
                /*foreach (var ve in dsVeChuyenBayDaThanhToan)
                {
                    MessageBox.Show($"Ve: {ve.MaChuyenBay} - DonGia: {ve.DonGia}");
                }*/

                //dgv doanh thu
                var dsMaChuyenBay = dsChuyenBay
                    .Select(h => h.MaChuyenBay)
                    .Distinct();

                int stt = 1;
                foreach (var maChuyenBay in dsMaChuyenBay)
                {
                    var dsVeCuaChuyenBay = dsVeChuyenBayDaThanhToan
                        .Where(h => h.MaChuyenBay == maChuyenBay)
                        .ToList();

                    var tongSoLuongDaBan = dsVeCuaChuyenBay.Count();

                    var doanhThu = dsVeCuaChuyenBay
                        .Sum(h => h.DonGia);

                    decimal tyLe = 0;
                    if (doanhThu > 0 && tongDoanhThu > 0)
                    {
                        tyLe = Math.Round((decimal)doanhThu / (decimal)tongDoanhThu * 100m, 2);
                    }

                    dgvBaoCaoDoanhThu.Rows.Add(
                        stt++,
                        maChuyenBay,
                        tongSoLuongDaBan,
                        tyLe,
                        doanhThu
                    );
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy chuyến bay đã bay trong thời gian trên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
