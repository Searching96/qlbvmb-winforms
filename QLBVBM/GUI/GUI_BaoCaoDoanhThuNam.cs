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
    public partial class GUI_BaoCaoDoanhThuNam : Form
    {
        private BUS_ChuyenBay busChuyenBay = new BUS_ChuyenBay();
        private BUS_VeChuyenBay busVeChuyenBay = new BUS_VeChuyenBay();
        private ComboBox cbbNam; // Declare the ComboBox for years

        public GUI_BaoCaoDoanhThuNam()
        {
            InitializeComponent();
            ConfigureYearComboBox();
        }

        private void ConfigureYearComboBox()
        {
            // Get the position and size of the existing dtpNam control
            var location = dtpNam.Location;
            var size = dtpNam.Size;

            // Create and configure the ComboBox
            cbbNam = new ComboBox();
            cbbNam.Location = location;
            cbbNam.Size = size;
            cbbNam.DropDownStyle = ComboBoxStyle.DropDownList; // Prevent direct text entry
            cbbNam.Font = dtpNam.Font;

            // Populate the ComboBox with years (for example, from 2000 to current year + 5)
            int currentYear = DateTime.Now.Year;
            for (int year = 2000; year <= currentYear; year++)
            {
                cbbNam.Items.Add(year);
            }

            // Set the current year as default
            cbbNam.SelectedItem = currentYear;

            // Add the control to the form
            this.Controls.Add(cbbNam);

            // Hide the original DateTimePicker
            dtpNam.Visible = false;
        }

        private void GUI_BaoCaoDoanhThuNam_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
        }

        private void btnLapBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            if (cbbNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm để lập báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use the ComboBox selected value
            int nam = (int)cbbNam.SelectedItem;
            decimal tongDoanhThu = LoadDoanhThuTheoNam(nam);

            // Display total revenue in the textbox
            txtTongDoanhThuCacChuyenBayTrongNam.Text = tongDoanhThu.ToString("N0") + " VND";
        }

        private void SetupDataGridView()
        {
            dgvBaoCaoDoanhThuNam.Columns.Clear();

            dgvBaoCaoDoanhThuNam.ColumnHeadersVisible = true;

            dgvBaoCaoDoanhThuNam.Columns.Add("Thang", "Tháng");
            dgvBaoCaoDoanhThuNam.Columns.Add("SoChuyenBay", "Số chuyến bay");
            dgvBaoCaoDoanhThuNam.Columns.Add("DoanhThu", "Doanh thu");
            dgvBaoCaoDoanhThuNam.Columns.Add("TyLe", "Tỷ lệ");

            // Align numbers to the right
            dgvBaoCaoDoanhThuNam.Columns["Thang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBaoCaoDoanhThuNam.Columns["SoChuyenBay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBaoCaoDoanhThuNam.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBaoCaoDoanhThuNam.Columns["TyLe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Center header text
            dgvBaoCaoDoanhThuNam.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Make header font bold and set colors
            dgvBaoCaoDoanhThuNam.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBaoCaoDoanhThuNam.Font, FontStyle.Bold);
            dgvBaoCaoDoanhThuNam.EnableHeadersVisualStyles = false;
            dgvBaoCaoDoanhThuNam.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgvBaoCaoDoanhThuNam.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBaoCaoDoanhThuNam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Show grid lines between cells
            dgvBaoCaoDoanhThuNam.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Optional: Make grid lines bolder by handling CellPainting
            dgvBaoCaoDoanhThuNam.CellPainting -= dgvBaoCaoDoanhThuNam_CellPainting; // Avoid multiple subscriptions
            dgvBaoCaoDoanhThuNam.CellPainting += dgvBaoCaoDoanhThuNam_CellPainting;
        }


        // Add this event handler to your form
        private void dgvBaoCaoDoanhThuNam_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) // Header or cell border
            {
                e.PaintBackground(e.ClipBounds, true);
                e.PaintContent(e.ClipBounds);

                using (Pen pen = new Pen(Color.Gray, 2)) // Thicker line
                {
                    // Draw right border
                    e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    // Draw bottom border
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    // Draw left border
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                    // Draw top border
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                }
                e.Handled = true;
            }
        }

        private decimal LoadDoanhThuTheoNam(int nam)
        {
            // Step 2: Get all flights in the selected year
            var dsChuyenBay = busChuyenBay.LayTatCaChuyenBayTheoNam(nam);
            if (dsChuyenBay == null || dsChuyenBay.Count == 0)
            {
                dgvBaoCaoDoanhThuNam.Rows.Clear();
                MessageBox.Show("Không có chuyến bay nào trong năm này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            // Step 3: Get all tickets for these flights
            var dsVeChuyenBay = new List<DTO_VeChuyenBay>();
            foreach (var cb in dsChuyenBay)
            {
                List<DTO_VeChuyenBay> veList = new List<DTO_VeChuyenBay>();
                busVeChuyenBay.LayVeChuyenBayTheoMaChuyenBay(cb.MaChuyenBay, out veList);
                if (veList != null)
                    dsVeChuyenBay.AddRange(veList);
            }

            // Step 4: Calculate total revenue for PAID tickets in the year
            // Giả sử trạng thái vé đã thanh toán là DonGia > 0 và có thể có thêm trường trạng thái nếu bạn bổ sung
            var veDaThanhToan = dsVeChuyenBay.Where(v => v.DonGia.HasValue && v.TrangThaiVe == "Da_Thanh_Toan").ToList();
            decimal tongDoanhThuNam = veDaThanhToan.Sum(v => v.DonGia ?? 0);

            // Step 5: List months with flights
            var thangCoChuyenBay = dsChuyenBay
                .Where(cb => cb.NgayBay.HasValue)
                .Select(cb => cb.NgayBay.Value.Month)
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            dgvBaoCaoDoanhThuNam.Rows.Clear();

            // Step 6-8: For each month, count flights, sum revenue, calculate ratio
            foreach (var thang in thangCoChuyenBay)
            {
                // Flights in this month
                var chuyenBayThang = dsChuyenBay.Where(cb => cb.NgayBay.HasValue && cb.NgayBay.Value.Month == thang).ToList();
                int soChuyenBay = chuyenBayThang.Count;

                // Tickets for these flights
                var maChuyenBayThang = chuyenBayThang.Select(cb => cb.MaChuyenBay).ToHashSet();
                var veThang = veDaThanhToan.Where(v => v.MaChuyenBay != null && maChuyenBayThang.Contains(v.MaChuyenBay)).ToList();
                decimal doanhThuThang = veThang.Sum(v => v.DonGia ?? 0);

                // Ratio
                string tyLe = tongDoanhThuNam > 0
                    ? (doanhThuThang / tongDoanhThuNam).ToString("P2")
                    : "0%";

                // Add to DataGridView
                dgvBaoCaoDoanhThuNam.Rows.Add(
                    thang,
                    soChuyenBay,
                    doanhThuThang.ToString("N0"),
                    tyLe
                );
            }

            // Return the total revenue for the year
            return tongDoanhThuNam;
        }

        private void lblTongDoanhThuCacChuyenBayTrongNam_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
