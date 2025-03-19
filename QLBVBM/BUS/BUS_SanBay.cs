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
        private DAL_SanBay dal = new DAL_SanBay();

        public List<DTO_SanBay> LayDanhSachSanBay()
        {
            return dal.LayDanhSachSanBay();
        }

        public bool ThemSanBay(DTO_SanBay sanBay)
        {
            return dal.ThemSanBay(sanBay);
        }
    }
}
