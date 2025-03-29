
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
            btnThemSanBay = new Button();
            btnThemHangGhe = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDSSanBayTG).BeginInit();
            SuspendLayout();
            // 
            // lblMaChuyenBay
            // 
            lblMaChuyenBay.AutoSize = true;
            lblMaChuyenBay.Location = new Point(17, 42);
            lblMaChuyenBay.Name = "lblMaChuyenBay";
            lblMaChuyenBay.Size = new Size(88, 15);
            lblMaChuyenBay.TabIndex = 0;
            lblMaChuyenBay.Text = "Mã chuyến bay";
            // 
            // txtMaChuyenBay
            // 
            txtMaChuyenBay.Location = new Point(17, 58);
            txtMaChuyenBay.Margin = new Padding(3, 2, 3, 2);
            txtMaChuyenBay.Name = "txtMaChuyenBay";
            txtMaChuyenBay.ReadOnly = true;
            txtMaChuyenBay.Size = new Size(168, 23);
            txtMaChuyenBay.TabIndex = 1;
            // 
            // lblSanBayDi
            // 
            lblSanBayDi.AutoSize = true;
            lblSanBayDi.Location = new Point(461, 42);
            lblSanBayDi.Name = "lblSanBayDi";
            lblSanBayDi.Size = new Size(71, 15);
            lblSanBayDi.TabIndex = 2;
            lblSanBayDi.Text = "Sân bay đến";
            // 
            // lblSanBayDen
            // 
            lblSanBayDen.AutoSize = true;
            lblSanBayDen.Location = new Point(238, 40);
            lblSanBayDen.Name = "lblSanBayDen";
            lblSanBayDen.Size = new Size(61, 15);
            lblSanBayDen.TabIndex = 3;
            lblSanBayDen.Text = "Sân bay đi";
            // 
            // dtpNgayGioBay
            // 
            dtpNgayGioBay.Location = new Point(17, 110);
            dtpNgayGioBay.Margin = new Padding(3, 2, 3, 2);
            dtpNgayGioBay.Name = "dtpNgayGioBay";
            dtpNgayGioBay.Size = new Size(263, 23);
            dtpNgayGioBay.TabIndex = 6;
            dtpNgayGioBay.Value = new DateTime(2025, 4, 29, 11, 16, 0, 368);
            // 
            // lblNgayGioBay
            // 
            lblNgayGioBay.AutoSize = true;
            lblNgayGioBay.Location = new Point(367, 153);
            lblNgayGioBay.Name = "lblNgayGioBay";
            lblNgayGioBay.Size = new Size(116, 15);
            lblNgayGioBay.TabIndex = 7;
            lblNgayGioBay.Text = "Số lượng ghế hạng 2";
            // 
            // lblThoiGianBay
            // 
            lblThoiGianBay.AutoSize = true;
            lblThoiGianBay.Location = new Point(17, 153);
            lblThoiGianBay.Name = "lblThoiGianBay";
            lblThoiGianBay.Size = new Size(116, 15);
            lblThoiGianBay.TabIndex = 8;
            lblThoiGianBay.Text = "Số lượng ghế hạng 1";
            // 
            // lblSoLuongGheHang1
            // 
            lblSoLuongGheHang1.AutoSize = true;
            lblSoLuongGheHang1.Location = new Point(367, 93);
            lblSoLuongGheHang1.Name = "lblSoLuongGheHang1";
            lblSoLuongGheHang1.Size = new Size(115, 15);
            lblSoLuongGheHang1.TabIndex = 9;
            lblSoLuongGheHang1.Text = "Thời gian bay (phút)";
            // 
            // lblSoLuongGheHang2
            // 
            lblSoLuongGheHang2.AutoSize = true;
            lblSoLuongGheHang2.Location = new Point(17, 93);
            lblSoLuongGheHang2.Name = "lblSoLuongGheHang2";
            lblSoLuongGheHang2.Size = new Size(86, 15);
            lblSoLuongGheHang2.TabIndex = 10;
            lblSoLuongGheHang2.Text = "Ngày - Giờ bay";
            // 
            // txtThoiGianBay
            // 
            txtThoiGianBay.Location = new Point(367, 110);
            txtThoiGianBay.Margin = new Padding(3, 2, 3, 2);
            txtThoiGianBay.Name = "txtThoiGianBay";
            txtThoiGianBay.Size = new Size(263, 23);
            txtThoiGianBay.TabIndex = 13;
            txtThoiGianBay.TextChanged += txtThoiGianBay_TextChanged;
            // 
            // txtSoLuongGheHang2
            // 
            txtSoLuongGheHang2.Location = new Point(367, 170);
            txtSoLuongGheHang2.Margin = new Padding(3, 2, 3, 2);
            txtSoLuongGheHang2.Name = "txtSoLuongGheHang2";
            txtSoLuongGheHang2.Size = new Size(263, 23);
            txtSoLuongGheHang2.TabIndex = 14;
            txtSoLuongGheHang2.TextChanged += txtSoLuongGheHang2_TextChanged;
            // 
            // txtSoLuongGheHang1
            // 
            txtSoLuongGheHang1.Location = new Point(17, 170);
            txtSoLuongGheHang1.Margin = new Padding(3, 2, 3, 2);
            txtSoLuongGheHang1.Name = "txtSoLuongGheHang1";
            txtSoLuongGheHang1.Size = new Size(263, 23);
            txtSoLuongGheHang1.TabIndex = 15;
            txtSoLuongGheHang1.TextChanged += txtSoLuongGheHang1_TextChanged;
            // 
            // dgvDSSanBayTG
            // 
            dgvDSSanBayTG.AllowUserToAddRows = false;
            dgvDSSanBayTG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSSanBayTG.ColumnHeadersHeight = 29;
            dgvDSSanBayTG.Location = new Point(17, 224);
            dgvDSSanBayTG.Margin = new Padding(3, 2, 3, 2);
            dgvDSSanBayTG.Name = "dgvDSSanBayTG";
            dgvDSSanBayTG.RowHeadersWidth = 51;
            dgvDSSanBayTG.Size = new Size(612, 129);
            dgvDSSanBayTG.TabIndex = 18;
            dgvDSSanBayTG.CellValidating += DgvDSSanBayTG_CellValidating;
            // 
            // cbbSanBayDi
            // 
            cbbSanBayDi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSanBayDi.FormattingEnabled = true;
            cbbSanBayDi.Location = new Point(238, 58);
            cbbSanBayDi.Margin = new Padding(3, 2, 3, 2);
            cbbSanBayDi.Name = "cbbSanBayDi";
            cbbSanBayDi.Size = new Size(168, 23);
            cbbSanBayDi.TabIndex = 16;
            // 
            // cbbSanBayDen
            // 
            cbbSanBayDen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSanBayDen.FormattingEnabled = true;
            cbbSanBayDen.Location = new Point(461, 58);
            cbbSanBayDen.Margin = new Padding(3, 2, 3, 2);
            cbbSanBayDen.Name = "cbbSanBayDen";
            cbbSanBayDen.Size = new Size(168, 23);
            cbbSanBayDen.TabIndex = 17;
            // 
            // btnTiepNhan
            // 
            btnTiepNhan.Location = new Point(17, 369);
            btnTiepNhan.Margin = new Padding(3, 2, 3, 2);
            btnTiepNhan.Name = "btnTiepNhan";
            btnTiepNhan.Size = new Size(612, 22);
            btnTiepNhan.TabIndex = 19;
            btnTiepNhan.Text = "Tiếp nhận lịch chuyến bay";
            btnTiepNhan.UseVisualStyleBackColor = true;
            btnTiepNhan.Click += btnTiepNhan_Click;
            // 
            // btnThemSanBay
            // 
            btnThemSanBay.Location = new Point(17, 399);
            btnThemSanBay.Margin = new Padding(3, 2, 3, 2);
            btnThemSanBay.Name = "btnThemSanBay";
            btnThemSanBay.Size = new Size(304, 22);
            btnThemSanBay.TabIndex = 20;
            btnThemSanBay.Text = "Thêm sân bay mới";
            btnThemSanBay.UseVisualStyleBackColor = true;
            btnThemSanBay.Click += btnThemSanBay_Click;
            // 
            // btnThemHangGhe
            // 
            btnThemHangGhe.Location = new Point(326, 399);
            btnThemHangGhe.Margin = new Padding(3, 2, 3, 2);
            btnThemHangGhe.Name = "btnThemHangGhe";
            btnThemHangGhe.Size = new Size(304, 22);
            btnThemHangGhe.TabIndex = 21;
            btnThemHangGhe.Text = "Thêm hạng ghế mới";
            btnThemHangGhe.UseVisualStyleBackColor = true;
            btnThemHangGhe.Click += btnThemHangGhe_Click;
            // 
            // GUI_TiepNhanLichChuyenBay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 430);
            Controls.Add(btnThemHangGhe);
            Controls.Add(btnThemSanBay);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private Button btnThemSanBay;
        private Button btnThemHangGhe;
    }
}