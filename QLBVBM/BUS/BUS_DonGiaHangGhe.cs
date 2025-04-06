using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_DonGiaHangGhe
    {
        private DAL_DonGiaHangGhe DAL_DonGiaHangGhe = new DAL_DonGiaHangGhe();

        public List<DTO_DonGiaHangGhe> LayDanhSachTenHangGheChuyenBay(string maChuyenBay)
        {
            return DAL_DonGiaHangGhe.LayDanhSachTenHangGheChuyenBay(maChuyenBay);
        }
    }
}
