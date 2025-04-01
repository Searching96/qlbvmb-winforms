using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_HangGhe
    {
        private DAL_HangGhe DAL_HangGhe = new DAL_HangGhe();

        public List<DTO_HangGhe> LayDanhSachHangGhe()
        {
            return DAL_HangGhe.LayDanhSachHangGhe();
        }

        public bool ThemHangGhe(DTO_HangGhe hangGhe)
        {
            return DAL_HangGhe.ThemHangGhe(hangGhe);
        }

        public DTO_HangGhe? LayHangGheCuoi()
        {
            return DAL_HangGhe.LayHangGheCuoi();
        }

        public string PhatSinhMaHangGhe()
        {
            DTO_HangGhe hangGheCuoi = LayHangGheCuoi();
            if (hangGheCuoi != null)
            {
                string maHangGheCuoi = hangGheCuoi.MaHangGhe;
                int lastNumber = int.Parse(maHangGheCuoi.Substring(2));
                return "HG" + (lastNumber + 1).ToString("D5");
            }
            else
            {
                return "HG00001";
            }
        }
    }
}
