
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
            dateTimePicker1 = new DateTimePicker();
            lblNgayGioBay = new Label();
            lblThoiGianBay = new Label();
            lblSoLuongGheHang1 = new Label();
            lblSoLuongGheHang2 = new Label();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            dgvDSSanBayTG = new DataGridView();
            cbbSanBayDi = new ComboBox();
            cbbSanBayDen = new ComboBox();
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
            // label1
            // 
            lblSanBayDi.AutoSize = true;
            lblSanBayDi.Location = new Point(413, 55);
            lblSanBayDi.Name = "label1";
            lblSanBayDi.Size = new Size(90, 20);
            lblSanBayDi.TabIndex = 2;
            lblSanBayDi.Text = "Sân bay đến";
            // 
            // label2
            // 
            lblSanBayDen.AutoSize = true;
            lblSanBayDen.Location = new Point(215, 56);
            lblSanBayDen.Name = "label2";
            lblSanBayDen.Size = new Size(78, 20);
            lblSanBayDen.TabIndex = 3;
            lblSanBayDen.Text = "Sân bay đi";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(19, 147);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(248, 27);
            dateTimePicker1.TabIndex = 6;
            // 
            // label3
            // 
            lblNgayGioBay.AutoSize = true;
            lblNgayGioBay.Location = new Point(353, 204);
            lblNgayGioBay.Name = "label3";
            lblNgayGioBay.Size = new Size(147, 20);
            lblNgayGioBay.TabIndex = 7;
            lblNgayGioBay.Text = "Số lượng ghế hạng 2";
            // 
            // label4
            // 
            lblThoiGianBay.AutoSize = true;
            lblThoiGianBay.Location = new Point(19, 204);
            lblThoiGianBay.Name = "label4";
            lblThoiGianBay.Size = new Size(147, 20);
            lblThoiGianBay.TabIndex = 8;
            lblThoiGianBay.Text = "Số lượng ghế hạng 1";
            // 
            // label5
            // 
            lblSoLuongGheHang1.AutoSize = true;
            lblSoLuongGheHang1.Location = new Point(353, 124);
            lblSoLuongGheHang1.Name = "label5";
            lblSoLuongGheHang1.Size = new Size(99, 20);
            lblSoLuongGheHang1.TabIndex = 9;
            lblSoLuongGheHang1.Text = "Thời gian bay";
            // 
            // label6
            // 
            lblSoLuongGheHang2.AutoSize = true;
            lblSoLuongGheHang2.Location = new Point(19, 124);
            lblSoLuongGheHang2.Name = "label6";
            lblSoLuongGheHang2.Size = new Size(109, 20);
            lblSoLuongGheHang2.TabIndex = 10;
            lblSoLuongGheHang2.Text = "Ngày - Giờ bay";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(353, 147);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(252, 27);
            textBox5.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(353, 227);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(252, 27);
            textBox3.TabIndex = 14;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(19, 227);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(248, 27);
            textBox4.TabIndex = 15;
            // 
            // dgvDSSanBayTG
            // 
            dgvDSSanBayTG.AllowUserToAddRows = false;
            dgvDSSanBayTG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSSanBayTG.ColumnHeadersHeight = 29;
            dgvDSSanBayTG.Location = new Point(19, 298);
            dgvDSSanBayTG.Name = "dgvDSSanBayTG";
            dgvDSSanBayTG.Size = new Size(700, 172);
            // 
            // cbbSanBayDi
            // 
            cbbSanBayDi.FormattingEnabled = true;
            cbbSanBayDi.Location = new Point(215, 79);
            cbbSanBayDi.Name = "cbbSanBayDi";
            cbbSanBayDi.Size = new Size(192, 28);
            cbbSanBayDi.TabIndex = 16;
            // 
            // cbbSanBayDen
            // 
            cbbSanBayDen.FormattingEnabled = true;
            cbbSanBayDen.Location = new Point(413, 78);
            cbbSanBayDen.Name = "cbbSanBayDen";
            cbbSanBayDen.Size = new Size(192, 28);
            cbbSanBayDen.TabIndex = 17;
            // 
            // GUI_TiepNhanLichChuyenBay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 573);
            Controls.Add(cbbSanBayDen);
            Controls.Add(cbbSanBayDi);
            Controls.Add(dgvDSSanBayTG);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox5);
            Controls.Add(lblSoLuongGheHang2);
            Controls.Add(lblSoLuongGheHang1);
            Controls.Add(lblThoiGianBay);
            Controls.Add(lblNgayGioBay);
            Controls.Add(dateTimePicker1);
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
        private DateTimePicker dateTimePicker1;
        private Label lblNgayGioBay;
        private Label lblThoiGianBay;
        private Label lblSoLuongGheHang1;
        private Label lblSoLuongGheHang2;
        private TextBox textBox5;
        private TextBox textBox3;
        private TextBox textBox4;
        private DataGridView dgvDSSanBayTG;
        private ComboBox cbbSanBayDi;
        private ComboBox cbbSanBayDen;
    }
}