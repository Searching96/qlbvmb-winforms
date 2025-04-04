using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBVBM.DAL;
using QLBVBM.DTO;
using System.Transactions;

namespace QLBVBM.BUS
{
    public class BUS_HanhKhach
    {
        private DAL_HanhKhach dalHanhKhach = new DAL_HanhKhach();

        public bool ThemHanhKhach(DTO_HanhKhach hanhKhach)
        {
            return dalHanhKhach.ThemHanhKhach(hanhKhach);
        }

        public DTO_HanhKhach? LayHanhKhachCuoi()
        {
            return dalHanhKhach.LayHanhKhachCuoi();
        }

        public List<DTO_HanhKhach> LayDanhSachHanhKhach()
        {
            return dalHanhKhach.LayDanhSachHanhKhach();
        }

        public DTO_HanhKhach? TimHanhKhachTheoCMND(string CMND)
        {
            return dalHanhKhach.TimHanhKhachTheoCMND(CMND);
        }
        
        public bool ValidateCMND(string CMND)
        {
            return CMND.All(char.IsDigit) && CMND.Length <= 20;
        }
    }
}
