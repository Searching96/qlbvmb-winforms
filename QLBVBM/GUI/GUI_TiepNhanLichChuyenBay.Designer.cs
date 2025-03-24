
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
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
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
            label1.AutoSize = true;
            label1.Location = new Point(413, 55);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 2;
            label1.Text = "Sân bay đến";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 56);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 3;
            label2.Text = "Sân bay đi";
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
            label3.AutoSize = true;
            label3.Location = new Point(353, 204);
            label3.Name = "label3";
            label3.Size = new Size(147, 20);
            label3.TabIndex = 7;
            label3.Text = "Số lượng ghế hạng 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 204);
            label4.Name = "label4";
            label4.Size = new Size(147, 20);
            label4.TabIndex = 8;
            label4.Text = "Số lượng ghế hạng 1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(353, 124);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 9;
            label5.Text = "Thời gian bay";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 124);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 10;
            label6.Text = "Ngày - Giờ bay";
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
            dgvDSSanBayTG.RowHeadersWidth = 51;
            dgvDSSanBayTG.Size = new Size(700, 172);
            dgvDSSanBayTG.TabIndex = 0;
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
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMaChuyenBay);
            Controls.Add(lblMaChuyenBay);
            Name = "GUI_TiepNhanLichChuyenBay";
            Text = "Tiếp Nhận Lịch Chuyến Bay";
            ((System.ComponentModel.ISupportInitialize)dgvDSSanBayTG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupDgvColumns(DataGridView dgv, int rowCount)
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
                // Here will be changed
                DataSource = new List<string> { "Hà Nội", "TP.Hồ Chí Minh", "Đà Nẵng" }
            };
            dgv.Columns.Add(colTenSanBay);

            DataGridViewTextBoxColumn colThoiGianDung = new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianDung",
                HeaderText = "Thời gian dừng",
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

        #endregion

        private Label lblMaChuyenBay;
        private TextBox txtMaChuyenBay;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox5;
        private TextBox textBox3;
        private TextBox textBox4;
        private DataGridView dgvDSSanBayTG;
        private ComboBox cbbSanBayDi;
        private ComboBox cbbSanBayDen;
    }
}