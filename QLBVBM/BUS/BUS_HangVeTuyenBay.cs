using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_HangVeTuyenBay
    {
        public DAL_HangVeTuyenBay DAL_HangVeTuyenBay = new DAL_HangVeTuyenBay();

        public int LayDonGiaQuyDinh(string maSanBayDi, string maSanBayDen, string maHangGhe)
        {
            return DAL_HangVeTuyenBay.LayDonGiaQuyDinh(maSanBayDi, maSanBayDen, maHangGhe);
        }

        public List<DTO_SanBay> LaySanBayDenTheoSanBayDi(string maSanBayDi)
        {
            return DAL_HangVeTuyenBay.LaySanBayDenTheoSanBayDi(maSanBayDi);
        }

        public List<DTO_HangGhe> LayHangGheTheoTuyenBay(string maSanBayDi, string maSanBayDen)
        {
            return DAL_HangVeTuyenBay.LayHangGheTheoTuyenBay(maSanBayDi, maSanBayDen);
        }
    }
}
