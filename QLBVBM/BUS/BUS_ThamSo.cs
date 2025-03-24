using QLBVBM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_ThamSo
    {
        private DAL_ThamSo DAL_ThamSo = new DAL_ThamSo();

        public int LaySoLuongSanBayToiDa()
        {
            return DAL_ThamSo.LaySoLuongSanBayToiDa();
        }

        public int LayThoiGianBayToiThieu()
        {
            return DAL_ThamSo.LayThoiGianBayToiThieu();
        }

        public int LayThoiGianDungToiThieu()
        {
            return DAL_ThamSo.LayThoiGianDungToiThieu();
        }

        public int LayThoiGianDungToiDa()
        {
            return DAL_ThamSo.LayThoiGianDungToiDa();
        }
    }
}
