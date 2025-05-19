namespace QLBVBM.GUI
{
    partial class GUI_TimChuyenBay
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTraCuuChuyenBay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbbSanBayDen = new Guna.UI2.WinForms.Guna2ComboBox();
            cbbSanBayDi = new Guna.UI2.WinForms.Guna2ComboBox();
            dtpNgayBay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblNgayGioBay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblSanBayDi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblSanBayDen = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbbDSChuyenBay = new Guna.UI2.WinForms.Guna2ComboBox();
            lblDSChuyenBay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnTiepNhanChuyenBay = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblTraCuuChuyenBay
            // 
            lblTraCuuChuyenBay.BackColor = Color.Transparent;
            lblTraCuuChuyenBay.Font = new Font("Arial", 18.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTraCuuChuyenBay.Location = new Point(206, 29);
            lblTraCuuChuyenBay.Name = "lblTraCuuChuyenBay";
            lblTraCuuChuyenBay.Size = new Size(238, 32);
            lblTraCuuChuyenBay.TabIndex = 1;
            lblTraCuuChuyenBay.Text = "Tra cứu chuyến bay";
            // 
            // cbbSanBayDen
            // 
            cbbSanBayDen.BackColor = Color.Transparent;
            cbbSanBayDen.BorderColor = Color.Silver;
            cbbSanBayDen.BorderRadius = 7;
            cbbSanBayDen.CustomizableEdges = customizableEdges1;
            cbbSanBayDen.DrawMode = DrawMode.OwnerDrawFixed;
            cbbSanBayDen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSanBayDen.FocusedColor = Color.FromArgb(94, 148, 255);
            cbbSanBayDen.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbbSanBayDen.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cbbSanBayDen.ForeColor = Color.FromArgb(68, 88, 112);
            cbbSanBayDen.ItemHeight = 44;
            cbbSanBayDen.Location = new Point(360, 126);
            cbbSanBayDen.Name = "cbbSanBayDen";
            cbbSanBayDen.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbbSanBayDen.Size = new Size(271, 50);
            cbbSanBayDen.TabIndex = 39;
            cbbSanBayDen.SelectedIndexChanged += FlightInfo_Changed;
            // 
            // cbbSanBayDi
            // 
            cbbSanBayDi.BackColor = Color.Transparent;
            cbbSanBayDi.BorderColor = Color.Silver;
            cbbSanBayDi.BorderRadius = 7;
            cbbSanBayDi.CustomizableEdges = customizableEdges3;
            cbbSanBayDi.DrawMode = DrawMode.OwnerDrawFixed;
            cbbSanBayDi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSanBayDi.FocusedColor = Color.FromArgb(94, 148, 255);
            cbbSanBayDi.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbbSanBayDi.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cbbSanBayDi.ForeColor = Color.FromArgb(68, 88, 112);
            cbbSanBayDi.ItemHeight = 44;
            cbbSanBayDi.Location = new Point(39, 126);
            cbbSanBayDi.Name = "cbbSanBayDi";
            cbbSanBayDi.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbbSanBayDi.Size = new Size(271, 50);
            cbbSanBayDi.TabIndex = 38;
            cbbSanBayDi.SelectedIndexChanged += FlightInfo_Changed;
            // 
            // dtpNgayBay
            // 
            dtpNgayBay.BackColor = Color.White;
            dtpNgayBay.BorderColor = Color.Silver;
            dtpNgayBay.BorderRadius = 7;
            dtpNgayBay.BorderThickness = 1;
            dtpNgayBay.Checked = true;
            dtpNgayBay.CustomizableEdges = customizableEdges5;
            dtpNgayBay.FillColor = Color.White;
            dtpNgayBay.Font = new Font("Segoe UI", 9F);
            dtpNgayBay.Format = DateTimePickerFormat.Long;
            dtpNgayBay.Location = new Point(41, 235);
            dtpNgayBay.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpNgayBay.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpNgayBay.Name = "dtpNgayBay";
            dtpNgayBay.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpNgayBay.Size = new Size(269, 50);
            dtpNgayBay.TabIndex = 36;
            dtpNgayBay.Value = new DateTime(2025, 4, 3, 19, 48, 48, 458);
            dtpNgayBay.ValueChanged += FlightInfo_Changed;
            // 
            // lblNgayGioBay
            // 
            lblNgayGioBay.BackColor = Color.Transparent;
            lblNgayGioBay.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblNgayGioBay.Location = new Point(41, 197);
            lblNgayGioBay.Name = "lblNgayGioBay";
            lblNgayGioBay.Size = new Size(97, 19);
            lblNgayGioBay.TabIndex = 34;
            lblNgayGioBay.Text = "Ngày - giờ bay";
            // 
            // lblSanBayDi
            // 
            lblSanBayDi.BackColor = Color.Transparent;
            lblSanBayDi.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblSanBayDi.Location = new Point(41, 89);
            lblSanBayDi.Name = "lblSanBayDi";
            lblSanBayDi.Size = new Size(71, 19);
            lblSanBayDi.TabIndex = 33;
            lblSanBayDi.Text = "Sân bay đi";
            // 
            // lblSanBayDen
            // 
            lblSanBayDen.BackColor = Color.Transparent;
            lblSanBayDen.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblSanBayDen.Location = new Point(360, 89);
            lblSanBayDen.Name = "lblSanBayDen";
            lblSanBayDen.Size = new Size(84, 19);
            lblSanBayDen.TabIndex = 32;
            lblSanBayDen.Text = "Sân bay đến";
            // 
            // cbbDSChuyenBay
            // 
            cbbDSChuyenBay.BackColor = Color.Transparent;
            cbbDSChuyenBay.BorderColor = Color.Silver;
            cbbDSChuyenBay.BorderRadius = 7;
            cbbDSChuyenBay.CustomizableEdges = customizableEdges7;
            cbbDSChuyenBay.DrawMode = DrawMode.OwnerDrawFixed;
            cbbDSChuyenBay.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDSChuyenBay.FocusedColor = Color.FromArgb(94, 148, 255);
            cbbDSChuyenBay.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbbDSChuyenBay.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cbbDSChuyenBay.ForeColor = Color.FromArgb(68, 88, 112);
            cbbDSChuyenBay.ItemHeight = 44;
            cbbDSChuyenBay.Location = new Point(168, 375);
            cbbDSChuyenBay.Name = "cbbDSChuyenBay";
            cbbDSChuyenBay.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbbDSChuyenBay.Size = new Size(320, 50);
            cbbDSChuyenBay.TabIndex = 41;
            // 
            // lblDSChuyenBay
            // 
            lblDSChuyenBay.BackColor = Color.Transparent;
            lblDSChuyenBay.Font = new Font("Arial", 18.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblDSChuyenBay.Location = new Point(190, 319);
            lblDSChuyenBay.Name = "lblDSChuyenBay";
            lblDSChuyenBay.Size = new Size(271, 32);
            lblDSChuyenBay.TabIndex = 42;
            lblDSChuyenBay.Text = "Danh sách chuyến bay";
            // 
            // btnTiepNhanChuyenBay
            // 
            btnTiepNhanChuyenBay.BorderRadius = 10;
            btnTiepNhanChuyenBay.CustomizableEdges = customizableEdges9;
            btnTiepNhanChuyenBay.DisabledState.BorderColor = Color.DarkGray;
            btnTiepNhanChuyenBay.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTiepNhanChuyenBay.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTiepNhanChuyenBay.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTiepNhanChuyenBay.FillColor = Color.FromArgb(64, 64, 64);
            btnTiepNhanChuyenBay.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnTiepNhanChuyenBay.ForeColor = Color.White;
            btnTiepNhanChuyenBay.Location = new Point(226, 604);
            btnTiepNhanChuyenBay.Name = "btnTiepNhanChuyenBay";
            btnTiepNhanChuyenBay.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnTiepNhanChuyenBay.Size = new Size(183, 42);
            btnTiepNhanChuyenBay.TabIndex = 43;
            btnTiepNhanChuyenBay.Text = "Chọn chuyến bay";
            btnTiepNhanChuyenBay.Click += btnTiepNhanChuyenBay_Click;
            // 
            // GUI_TimChuyenBay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 673);
            Controls.Add(btnTiepNhanChuyenBay);
            Controls.Add(lblDSChuyenBay);
            Controls.Add(cbbDSChuyenBay);
            Controls.Add(cbbSanBayDen);
            Controls.Add(cbbSanBayDi);
            Controls.Add(dtpNgayBay);
            Controls.Add(lblNgayGioBay);
            Controls.Add(lblSanBayDi);
            Controls.Add(lblSanBayDen);
            Controls.Add(lblTraCuuChuyenBay);
            Name = "GUI_TimChuyenBay";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GUI_TimChuyenBay";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTraCuuChuyenBay;
        private Guna.UI2.WinForms.Guna2ComboBox cbbSanBayDen;
        private Guna.UI2.WinForms.Guna2ComboBox cbbSanBayDi;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayBay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNgayGioBay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSanBayDi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSanBayDen;
        private Guna.UI2.WinForms.Guna2ComboBox cbbDSChuyenBay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDSChuyenBay;
        private Guna.UI2.WinForms.Guna2Button btnTiepNhanChuyenBay;
    }
}