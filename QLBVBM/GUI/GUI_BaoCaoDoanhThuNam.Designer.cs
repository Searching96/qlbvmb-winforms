namespace QLBVBM.GUI
{
    partial class GUI_BaoCaoDoanhThuNam
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnLapBaoCaoDoanhThu = new Guna.UI2.WinForms.Guna2Button();
            dtpNam = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblNamLapBaoCao = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnThoat = new Guna.UI2.WinForms.Guna2Button();
            lblTongDoanhThuCacChuyenBayTrongNam = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtTongDoanhThuCacChuyenBayTrongNam = new Guna.UI2.WinForms.Guna2TextBox();
            dgvBaoCaoDoanhThuNam = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoDoanhThuNam).BeginInit();
            SuspendLayout();
            // 
            // btnLapBaoCaoDoanhThu
            // 
            btnLapBaoCaoDoanhThu.BorderRadius = 10;
            btnLapBaoCaoDoanhThu.CustomizableEdges = customizableEdges1;
            btnLapBaoCaoDoanhThu.DisabledState.BorderColor = Color.DarkGray;
            btnLapBaoCaoDoanhThu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLapBaoCaoDoanhThu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLapBaoCaoDoanhThu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLapBaoCaoDoanhThu.FillColor = Color.FromArgb(64, 64, 64);
            btnLapBaoCaoDoanhThu.Font = new Font("Arial", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLapBaoCaoDoanhThu.ForeColor = Color.White;
            btnLapBaoCaoDoanhThu.Location = new Point(744, 53);
            btnLapBaoCaoDoanhThu.Name = "btnLapBaoCaoDoanhThu";
            btnLapBaoCaoDoanhThu.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLapBaoCaoDoanhThu.Size = new Size(360, 72);
            btnLapBaoCaoDoanhThu.TabIndex = 0;
            btnLapBaoCaoDoanhThu.Text = "Lập báo cáo doanh thu";
            btnLapBaoCaoDoanhThu.Click += btnLapBaoCaoDoanhThu_Click;
            // 
            // dtpNam
            // 
            dtpNam.BorderRadius = 7;
            dtpNam.Checked = true;
            dtpNam.CustomFormat = "yyyy";
            dtpNam.CustomizableEdges = customizableEdges3;
            dtpNam.FillColor = Color.White;
            dtpNam.Font = new Font("Segoe UI", 9F);
            dtpNam.Format = DateTimePickerFormat.Custom;
            dtpNam.Location = new Point(12, 53);
            dtpNam.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpNam.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpNam.Name = "dtpNam";
            dtpNam.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dtpNam.Size = new Size(400, 72);
            dtpNam.TabIndex = 2;
            dtpNam.Value = new DateTime(2025, 5, 25, 18, 17, 35, 434);
            // 
            // lblNamLapBaoCao
            // 
            lblNamLapBaoCao.BackColor = Color.Transparent;
            lblNamLapBaoCao.Font = new Font("Arial", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNamLapBaoCao.Location = new Point(12, 12);
            lblNamLapBaoCao.Name = "lblNamLapBaoCao";
            lblNamLapBaoCao.Size = new Size(223, 35);
            lblNamLapBaoCao.TabIndex = 3;
            lblNamLapBaoCao.Text = "Năm lập báo cáo";
            // 
            // btnThoat
            // 
            btnThoat.BorderRadius = 10;
            btnThoat.CustomizableEdges = customizableEdges5;
            btnThoat.DisabledState.BorderColor = Color.DarkGray;
            btnThoat.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThoat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThoat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThoat.FillColor = Color.Silver;
            btnThoat.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(1120, 53);
            btnThoat.Name = "btnThoat";
            btnThoat.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnThoat.Size = new Size(224, 72);
            btnThoat.TabIndex = 41;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
            // 
            // lblTongDoanhThuCacChuyenBayTrongNam
            // 
            lblTongDoanhThuCacChuyenBayTrongNam.BackColor = Color.Transparent;
            lblTongDoanhThuCacChuyenBayTrongNam.Font = new Font("Arial", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongDoanhThuCacChuyenBayTrongNam.Location = new Point(219, 176);
            lblTongDoanhThuCacChuyenBayTrongNam.Name = "lblTongDoanhThuCacChuyenBayTrongNam";
            lblTongDoanhThuCacChuyenBayTrongNam.Size = new Size(607, 35);
            lblTongDoanhThuCacChuyenBayTrongNam.TabIndex = 42;
            lblTongDoanhThuCacChuyenBayTrongNam.Text = "Tổng Doanh Thu Các Chuyến Bay Trong Năm:";
            lblTongDoanhThuCacChuyenBayTrongNam.Click += lblTongDoanhThuCacChuyenBayTrongNam_Click;
            // 
            // txtTongDoanhThuCacChuyenBayTrongNam
            // 
            txtTongDoanhThuCacChuyenBayTrongNam.BackColor = Color.White;
            txtTongDoanhThuCacChuyenBayTrongNam.BorderColor = Color.Silver;
            txtTongDoanhThuCacChuyenBayTrongNam.BorderRadius = 7;
            txtTongDoanhThuCacChuyenBayTrongNam.CustomizableEdges = customizableEdges7;
            txtTongDoanhThuCacChuyenBayTrongNam.DefaultText = "";
            txtTongDoanhThuCacChuyenBayTrongNam.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTongDoanhThuCacChuyenBayTrongNam.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTongDoanhThuCacChuyenBayTrongNam.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTongDoanhThuCacChuyenBayTrongNam.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTongDoanhThuCacChuyenBayTrongNam.FillColor = Color.LightGray;
            txtTongDoanhThuCacChuyenBayTrongNam.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTongDoanhThuCacChuyenBayTrongNam.Font = new Font("Segoe UI", 9F);
            txtTongDoanhThuCacChuyenBayTrongNam.ForeColor = Color.Black;
            txtTongDoanhThuCacChuyenBayTrongNam.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTongDoanhThuCacChuyenBayTrongNam.Location = new Point(835, 155);
            txtTongDoanhThuCacChuyenBayTrongNam.Margin = new Padding(6, 6, 6, 6);
            txtTongDoanhThuCacChuyenBayTrongNam.Name = "txtTongDoanhThuCacChuyenBayTrongNam";
            txtTongDoanhThuCacChuyenBayTrongNam.PlaceholderText = "";
            txtTongDoanhThuCacChuyenBayTrongNam.ReadOnly = true;
            txtTongDoanhThuCacChuyenBayTrongNam.SelectedText = "";
            txtTongDoanhThuCacChuyenBayTrongNam.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtTongDoanhThuCacChuyenBayTrongNam.Size = new Size(360, 72);
            txtTongDoanhThuCacChuyenBayTrongNam.TabIndex = 43;
            // 
            // dgvBaoCaoDoanhThuNam
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvBaoCaoDoanhThuNam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBaoCaoDoanhThuNam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBaoCaoDoanhThuNam.ColumnHeadersHeight = 4;
            dgvBaoCaoDoanhThuNam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBaoCaoDoanhThuNam.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBaoCaoDoanhThuNam.GridColor = Color.FromArgb(231, 229, 255);
            dgvBaoCaoDoanhThuNam.Location = new Point(12, 260);
            dgvBaoCaoDoanhThuNam.Name = "dgvBaoCaoDoanhThuNam";
            dgvBaoCaoDoanhThuNam.RowHeadersVisible = false;
            dgvBaoCaoDoanhThuNam.RowHeadersWidth = 82;
            dgvBaoCaoDoanhThuNam.Size = new Size(1333, 528);
            dgvBaoCaoDoanhThuNam.TabIndex = 44;
            dgvBaoCaoDoanhThuNam.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvBaoCaoDoanhThuNam.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvBaoCaoDoanhThuNam.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvBaoCaoDoanhThuNam.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvBaoCaoDoanhThuNam.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvBaoCaoDoanhThuNam.ThemeStyle.BackColor = Color.White;
            dgvBaoCaoDoanhThuNam.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvBaoCaoDoanhThuNam.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvBaoCaoDoanhThuNam.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBaoCaoDoanhThuNam.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvBaoCaoDoanhThuNam.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvBaoCaoDoanhThuNam.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvBaoCaoDoanhThuNam.ThemeStyle.HeaderStyle.Height = 4;
            dgvBaoCaoDoanhThuNam.ThemeStyle.ReadOnly = false;
            dgvBaoCaoDoanhThuNam.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvBaoCaoDoanhThuNam.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBaoCaoDoanhThuNam.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvBaoCaoDoanhThuNam.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvBaoCaoDoanhThuNam.ThemeStyle.RowsStyle.Height = 41;
            dgvBaoCaoDoanhThuNam.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvBaoCaoDoanhThuNam.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvBaoCaoDoanhThuNam.CellContentClick += guna2DataGridView1_CellContentClick;
            dgvBaoCaoDoanhThuNam.CellPainting += dgvBaoCaoDoanhThuNam_CellPainting;
            // 
            // GUI_BaoCaoDoanhThuNam
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1356, 795);
            Controls.Add(dgvBaoCaoDoanhThuNam);
            Controls.Add(txtTongDoanhThuCacChuyenBayTrongNam);
            Controls.Add(lblTongDoanhThuCacChuyenBayTrongNam);
            Controls.Add(btnThoat);
            Controls.Add(lblNamLapBaoCao);
            Controls.Add(dtpNam);
            Controls.Add(btnLapBaoCaoDoanhThu);
            Name = "GUI_BaoCaoDoanhThuNam";
            Text = "Báo cáo doanh thu năm";
            Load += GUI_BaoCaoDoanhThuNam_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoDoanhThuNam).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnLapBaoCaoDoanhThu;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNam;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNamLapBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongDoanhThuCacChuyenBayTrongNam;
        private Guna.UI2.WinForms.Guna2TextBox txtTongDoanhThuCacChuyenBayTrongNam;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBaoCaoDoanhThuNam;
    }
}