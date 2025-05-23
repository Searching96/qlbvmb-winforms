using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_SanBay
    {
        private DAL_SanBay DAL_SanBay = new DAL_SanBay();

        public string LayTenSanBay(string maSanBay)
        {
            return DAL_SanBay.LayTenSanBay(maSanBay);
        }

        public List<DTO_SanBay> LayDanhSachSanBay()
        {
            return DAL_SanBay.LayDanhSachSanBay();
        }

        public bool ThemSanBay(DTO_SanBay sanBay)
        {
            return DAL_SanBay.ThemSanBay(sanBay);
        }

        public DTO_SanBay? LaySanBayCuoi()
        {
            return DAL_SanBay.LaySanBayCuoi();
        }

        public string PhatSinhMaSanBay()
        {
            DTO_SanBay sanBayCuoi = LaySanBayCuoi();
            if (sanBayCuoi != null)
            {
                string maSanBayCuoi = sanBayCuoi.MaSanBay;
                int lastNumber = int.Parse(maSanBayCuoi.Substring(2));
                return "SB" + (lastNumber + 1).ToString("D5");
            }
            else
            {
                return "SB00001";
            }
        }
    }
}
