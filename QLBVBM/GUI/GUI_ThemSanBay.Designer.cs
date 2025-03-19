namespace QLBVBM.GUI
{
    partial class GUI_ThemSanBay
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
            lblMaSanBay = new Label();
            lblTenSanBay = new Label();
            txtMaSanBay = new TextBox();
            txtTenSanBay = new TextBox();
            btnThem = new Button();
            dgvSanBay = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSanBay).BeginInit();
            SuspendLayout();
            // 
            // lblMaSanBay
            // 
            lblMaSanBay.AutoSize = true;
            lblMaSanBay.Location = new Point(128, 80);
            lblMaSanBay.Name = "lblMaSanBay";
            lblMaSanBay.Size = new Size(86, 20);
            lblMaSanBay.TabIndex = 2;
            lblMaSanBay.Text = "Mã Sân Bay";
            // 
            // lblTenSanBay
            // 
            lblTenSanBay.AutoSize = true;
            lblTenSanBay.Location = new Point(128, 130);
            lblTenSanBay.Name = "lblTenSanBay";
            lblTenSanBay.Size = new Size(88, 20);
            lblTenSanBay.TabIndex = 3;
            lblTenSanBay.Text = "Tên Sân Bay";
            // 
            // txtMaSanBay
            // 
            txtMaSanBay.Location = new Point(220, 73);
            txtMaSanBay.Name = "txtMaSanBay";
            txtMaSanBay.Size = new Size(212, 27);
            txtMaSanBay.TabIndex = 4;
            // 
            // txtTenSanBay
            // 
            txtTenSanBay.Location = new Point(220, 123);
            txtTenSanBay.Name = "txtTenSanBay";
            txtTenSanBay.Size = new Size(212, 27);
            txtTenSanBay.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(220, 180);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvSanBay
            // 
            dgvSanBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanBay.Location = new Point(12, 244);
            dgvSanBay.Name = "dgvSanBay";
            dgvSanBay.RowHeadersWidth = 51;
            dgvSanBay.Size = new Size(776, 194);
            dgvSanBay.TabIndex = 7;
            // 
            // GUI_ThemSanBay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvSanBay);
            Controls.Add(btnThem);
            Controls.Add(txtTenSanBay);
            Controls.Add(txtMaSanBay);
            Controls.Add(lblTenSanBay);
            Controls.Add(lblMaSanBay);
            Name = "GUI_ThemSanBay";
            Text = "GUI_ThemSanBay";
            Load += GUI_ThemSanBay_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanBay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaSanBay;
        private Label lblTenSanBay;
        private TextBox txtMaSanBay;
        private TextBox txtTenSanBay;
        private Button btnThem;
        private DataGridView dgvSanBay;
    }
}