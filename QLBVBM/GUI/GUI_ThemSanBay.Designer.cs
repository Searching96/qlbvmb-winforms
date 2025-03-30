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
            lblMaSanBay.Location = new Point(112, 60);
            lblMaSanBay.Name = "lblMaSanBay";
            lblMaSanBay.Size = new Size(68, 15);
            lblMaSanBay.TabIndex = 2;
            lblMaSanBay.Text = "Mã Sân Bay";
            // 
            // lblTenSanBay
            // 
            lblTenSanBay.AutoSize = true;
            lblTenSanBay.Location = new Point(112, 98);
            lblTenSanBay.Name = "lblTenSanBay";
            lblTenSanBay.Size = new Size(70, 15);
            lblTenSanBay.TabIndex = 3;
            lblTenSanBay.Text = "Tên Sân Bay";
            // 
            // txtMaSanBay
            // 
            txtMaSanBay.Location = new Point(192, 55);
            txtMaSanBay.Margin = new Padding(3, 2, 3, 2);
            txtMaSanBay.Name = "txtMaSanBay";
            txtMaSanBay.Size = new Size(186, 23);
            txtMaSanBay.TabIndex = 4;
            // 
            // txtTenSanBay
            // 
            txtTenSanBay.Location = new Point(192, 92);
            txtTenSanBay.Margin = new Padding(3, 2, 3, 2);
            txtTenSanBay.Name = "txtTenSanBay";
            txtTenSanBay.Size = new Size(186, 23);
            txtTenSanBay.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(192, 135);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(82, 22);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvSanBay
            // 
            dgvSanBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanBay.Location = new Point(10, 183);
            dgvSanBay.Margin = new Padding(3, 2, 3, 2);
            dgvSanBay.Name = "dgvSanBay";
            dgvSanBay.RowHeadersWidth = 51;
            dgvSanBay.Size = new Size(679, 146);
            dgvSanBay.TabIndex = 7;
            // 
            // GUI_ThemSanBay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 344);
            Controls.Add(dgvSanBay);
            Controls.Add(btnThem);
            Controls.Add(txtTenSanBay);
            Controls.Add(txtMaSanBay);
            Controls.Add(lblTenSanBay);
            Controls.Add(lblMaSanBay);
            Margin = new Padding(3, 2, 3, 2);
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