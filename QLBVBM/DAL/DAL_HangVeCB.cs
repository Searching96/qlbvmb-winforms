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
            string query = "INSERT INTO HANGVECB (MaChuyenBay, MaHangGhe, SoLuongGhe, SoLuongGheDaBan, DonGia) " +
                "VALUES (@MaChuyenBay, @MaHangGhe, @SoLuongGhe, @SoLuongGheDaBan, @DonGia)";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaChuyenBay", hangVeCB.MaChuyenBay),
                new MySqlParameter("@MaHangGhe", hangVeCB.MaHangGhe),
                new MySqlParameter("@SoLuongGhe", hangVeCB.SoLuongGhe),
                new MySqlParameter("@SoLuongGheDaBan", hangVeCB.SoLuongGheDaBan ?? 0),
                new MySqlParameter("@DonGia", hangVeCB.DonGia)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
