using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_CTChuyenBay
    {
        private DAL_CTChuyenBay DAL_CTChuyenBay = new DAL_CTChuyenBay();

        public bool ThemCTChuyenBay(DTO_CTChuyenBay ctChuyenBay)
        {
            return DAL_CTChuyenBay.ThemCTChuyenBay(ctChuyenBay);
        }
    }
}
