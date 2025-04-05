using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBVBM.DAL;
using QLBVBM.DTO;
using QLBVBM.BUS;

namespace QLBVBM.GUI
{
    public partial class GUI_ThemHanhKhach: Form
    {
        private BUS_HanhKhach busHanhKhach = new BUS_HanhKhach();

        public GUI_ThemHanhKhach()
        {
            InitializeComponent();
            PhatSinhMaHanhKhach();
        }

        public void PhatSinhMaHanhKhach()
        {
            txtMaHanhKhach.Text = busHanhKhach.PhatSinhMaHanhKhach();
        }
    }
}
