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
            List<DTO_HanhKhach> dsHanhKhach = dalHanhKhach.LayDanhSachHanhKhach();
            foreach (DTO_HanhKhach hanhKhach in dsHanhKhach)
            {
                if (hanhKhach.SoCMND == CMND) // also use String.Equals for case-insensitive comparison
                {
                    return hanhKhach;
                }
            }
            return null;
        }
    }
}
