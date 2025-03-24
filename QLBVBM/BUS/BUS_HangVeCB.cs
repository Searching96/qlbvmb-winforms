using QLBVBM.DAL;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.BUS
{
    public class BUS_HangVeCB
    {
        private DAL_HangVeCB DAL_HangVeCB = new DAL_HangVeCB();

        public bool ThemHangVeCB(DTO_HangVeCB hangVeCB)
        {
            return DAL_HangVeCB.ThemHangVe(hangVeCB);
        }
    }
}
