using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DAL
{
    public class DAL_HangVeCB
    {
        private DataHelper dataHelper = new DataHelper();

        public bool ThemHangVe(DTO_HangVeCB hangVeCB)
        {
            string query = "INSERT INTO HANGVECB (MaChuyenBay, MaHangGhe, SoLuongGhe) " +
                "VALUES (@MaChuyenBay, @MaHangGhe, @SoLuongGhe)";
            
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaChuyenBay", hangVeCB.MaChuyenBay),
                new MySqlParameter("@MaHangGhe", hangVeCB.MaHangGhe),
                new MySqlParameter("@SoLuongGhe", hangVeCB.SoLuongGhe)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
