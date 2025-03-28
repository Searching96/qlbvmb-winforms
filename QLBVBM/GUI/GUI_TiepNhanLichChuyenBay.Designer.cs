
namespace QLBVBM.GUI
{
    partial class GUI_TiepNhanLichChuyenBay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMaChuyenBay = new Label();
            txtMaChuyenBay = new TextBox();
            lblSanBayDi = new Label();
            lblSanBayDen = new Label();
            dtpNgayGioBay = new DateTimePicker();
            lblNgayGioBay = new Label();
            lblThoiGianBay = new Label();
            lblSoLuongGheHang1 = new Label();
            lblSoLuongGheHang2 = new Label();
            txtThoiGianBay = new TextBox();
            txtSoLuongGheHang2 = new TextBox();
            txtSoLuongGheHang1 = new TextBox();
            dgvDSSanBayTG = new DataGridView();
            cbbSanBayDi = new ComboBox();
            cbbSanBayDen = new ComboBox();
            btnTiepNhan = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDSSanBayTG).BeginInit();
            SuspendLayout();
            // 
            // lblMaChuyenBay
            // 
            lblMaChuyenBay.AutoSize = true;
            lblMaChuyenBay.Location = new Point(19, 56);
            lblMaChuyenBay.Name = "lblMaChuyenBay";
            lblMaChuyenBay.Size = new Size(108, 20);
            lblMaChuyenBay.TabIndex = 0;
            lblMaChuyenBay.Text = "Mã chuyến bay";
            // 
            // txtMaChuyenBay
            // 
            txtMaChuyenBay.Location = new Point(19, 79);
            txtMaChuyenBay.Name = "txtMaChuyenBay";
            txtMaChuyenBay.Size = new Size(190, 27);
            txtMaChuyenBay.TabIndex = 1;
            // 
            // lblSanBayDi
            // 
            lblSanBayDi.AutoSize = true;
            lblSanBayDi.Location = new Point(413, 56);
            lblSanBayDi.Name = "lblSanBayDi";
            lblSanBayDi.Size = new Size(90, 20);
            lblSanBayDi.TabIndex = 2;
            lblSanBayDi.Text = "Sân bay đến";
            // 
            // lblSanBayDen
            // 
            lblSanBayDen.AutoSize = true;
            lblSanBayDen.Location = new Point(215, 56);
            lblSanBayDen.Name = "lblSanBayDen";
            lblSanBayDen.Size = new Size(78, 20);
            lblSanBayDen.TabIndex = 3;
            lblSanBayDen.Text = "Sân bay đi";
            // 
            // dtpNgayGioBay
            // 
            dtpNgayGioBay.Location = new Point(19, 147);
            dtpNgayGioBay.Name = "dtpNgayGioBay";
            dtpNgayGioBay.Size = new Size(248, 27);
            dtpNgayGioBay.TabIndex = 6;
            // 
            // lblNgayGioBay
            // 
            lblNgayGioBay.AutoSize = true;
            lblNgayGioBay.Location = new Point(353, 204);
            lblNgayGioBay.Name = "lblNgayGioBay";
            lblNgayGioBay.Size = new Size(147, 20);
            lblNgayGioBay.TabIndex = 7;
            lblNgayGioBay.Text = "Số lượng ghế hạng 2";
            // 
            // lblThoiGianBay
            // 
            lblThoiGianBay.AutoSize = true;
            lblThoiGianBay.Location = new Point(19, 204);
            lblThoiGianBay.Name = "lblThoiGianBay";
            lblThoiGianBay.Size = new Size(147, 20);
            lblThoiGianBay.TabIndex = 8;
            lblThoiGianBay.Text = "Số lượng ghế hạng 1";
            // 
            // lblSoLuongGheHang1
            // 
            lblSoLuongGheHang1.AutoSize = true;
            lblSoLuongGheHang1.Location = new Point(353, 124);
            lblSoLuongGheHang1.Name = "lblSoLuongGheHang1";
            lblSoLuongGheHang1.Size = new Size(99, 20);
            lblSoLuongGheHang1.TabIndex = 9;
            lblSoLuongGheHang1.Text = "Thời gian bay (phút)";
            // 
            // lblSoLuongGheHang2
            // 
            lblSoLuongGheHang2.AutoSize = true;
            lblSoLuongGheHang2.Location = new Point(19, 124);
            lblSoLuongGheHang2.Name = "lblSoLuongGheHang2";
            lblSoLuongGheHang2.Size = new Size(109, 20);
            lblSoLuongGheHang2.TabIndex = 10;
            lblSoLuongGheHang2.Text = "Ngày - Giờ bay";
            // 
            // txtThoiGianBay
            // 
            txtThoiGianBay.Location = new Point(353, 147);
            txtThoiGianBay.Name = "txtThoiGianBay";
            txtThoiGianBay.Size = new Size(252, 27);
            txtThoiGianBay.TabIndex = 13;
            txtThoiGianBay.TextChanged += txtThoiGianBay_TextChanged;
            // 
            // txtSoLuongGheHang2
            // 
            txtSoLuongGheHang2.Location = new Point(353, 227);
            txtSoLuongGheHang2.Name = "txtSoLuongGheHang2";
            txtSoLuongGheHang2.Size = new Size(252, 27);
            txtSoLuongGheHang2.TabIndex = 14;
            txtSoLuongGheHang2.TextChanged += txtSoLuongGheHang2_TextChanged;
            // 
            // txtSoLuongGheHang1
            // 
            txtSoLuongGheHang1.Location = new Point(19, 227);
            txtSoLuongGheHang1.Name = "txtSoLuongGheHang1";
            txtSoLuongGheHang1.Size = new Size(248, 27);
            txtSoLuongGheHang1.TabIndex = 15;
            txtSoLuongGheHang1.TextChanged += txtSoLuongGheHang1_TextChanged;
            // 
            // dgvDSSanBayTG
            // 
            dgvDSSanBayTG.AllowUserToAddRows = false;
            dgvDSSanBayTG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSSanBayTG.ColumnHeadersHeight = 29;
            dgvDSSanBayTG.Location = new Point(19, 298);
            dgvDSSanBayTG.Name = "dgvDSSanBayTG";
            dgvDSSanBayTG.RowHeadersWidth = 51;
            dgvDSSanBayTG.Size = new Size(700, 172);
            dgvDSSanBayTG.TabIndex = 18;
            dgvDSSanBayTG.CellValidating += DgvDSSanBayTG_CellValidating;
            dgvDSSanBayTG.ShowCellErrors = true;
            dgvDSSanBayTG.ShowRowErrors = true;
            // 
            // cbbSanBayDi
            // 
            cbbSanBayDi.FormattingEnabled = true;
            cbbSanBayDi.Location = new Point(215, 79);
            cbbSanBayDi.Name = "cbbSanBayDi";
            cbbSanBayDi.Size = new Size(192, 28);
            cbbSanBayDi.TabIndex = 16;
            cbbSanBayDi.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // cbbSanBayDen
            // 
            cbbSanBayDen.FormattingEnabled = true;
            cbbSanBayDen.Location = new Point(413, 79);
            cbbSanBayDen.Name = "cbbSanBayDen";
            cbbSanBayDen.Size = new Size(192, 28);
            cbbSanBayDen.TabIndex = 17;
            cbbSanBayDen.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // btnTiepNhan
            // 
            btnTiepNhan.Location = new Point(19, 492);
            btnTiepNhan.Name = "btnTiepNhan";
            btnTiepNhan.Size = new Size(700, 29);
            btnTiepNhan.TabIndex = 19;
            btnTiepNhan.Text = "Tiếp nhận lịch chuyến bay";
            btnTiepNhan.UseVisualStyleBackColor = true;
            btnTiepNhan.Click += btnTiepNhan_Click;
            // 
            // GUI_TiepNhanLichChuyenBay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 573);
            Controls.Add(btnTiepNhan);
            Controls.Add(cbbSanBayDen);
            Controls.Add(cbbSanBayDi);
            Controls.Add(dgvDSSanBayTG);
            Controls.Add(txtSoLuongGheHang1);
            Controls.Add(txtSoLuongGheHang2);
            Controls.Add(txtThoiGianBay);
            Controls.Add(lblSoLuongGheHang2);
            Controls.Add(lblSoLuongGheHang1);
            Controls.Add(lblThoiGianBay);
            Controls.Add(lblNgayGioBay);
            Controls.Add(dtpNgayGioBay);
            Controls.Add(lblSanBayDen);
            Controls.Add(lblSanBayDi);
            Controls.Add(txtMaChuyenBay);
            Controls.Add(lblMaChuyenBay);
            Name = "GUI_TiepNhanLichChuyenBay";
            Text = "Tiếp Nhận Lịch Chuyến Bay";
            ((System.ComponentModel.ISupportInitialize)dgvDSSanBayTG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaChuyenBay;
        private TextBox txtMaChuyenBay;
        private Label lblSanBayDi;
        private Label lblSanBayDen;
        private DateTimePicker dtpNgayGioBay;
        private Label lblNgayGioBay;
        private Label lblThoiGianBay;
        private Label lblSoLuongGheHang1;
        private Label lblSoLuongGheHang2;
        private TextBox txtThoiGianBay;
        private TextBox txtSoLuongGheHang2;
        private TextBox txtSoLuongGheHang1;
        private DataGridView dgvDSSanBayTG;
        private ComboBox cbbSanBayDi;
        private ComboBox cbbSanBayDen;
        private Button btnTiepNhan;
    }
}