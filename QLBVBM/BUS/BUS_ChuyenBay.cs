using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_ChuyenBay
    {
        private DAL_ChuyenBay DAL_ChuyenBay = new DAL_ChuyenBay();

        public DTO_ChuyenBay LayChuyenBayCuoi()
        {
            return DAL_ChuyenBay.LayChuyenBayCuoi();
        }

        public bool ThemChuyenBay(DTO_ChuyenBay chuyenBay)
        {
            return DAL_ChuyenBay.ThemChuyenBay(chuyenBay);
        }
    }
}
