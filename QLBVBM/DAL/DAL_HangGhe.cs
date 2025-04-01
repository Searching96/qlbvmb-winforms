using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DAL
{
    public class DAL_HangGhe
    {
        private DataHelper dataHelper = new DataHelper();

        public List<DTO_HangGhe> LayDanhSachHangGhe()
        {
            List<DTO_HangGhe> dsHangGhe = new List<DTO_HangGhe>();
            string query = "SELECT * FROM HANGGHE";
            DataTable dt = dataHelper.ExecuteQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                DTO_HangGhe hangGhe = new DTO_HangGhe
                {
                    MaHangGhe = dr["MaHangGhe"].ToString(),
                    TenHangGhe = dr["TenHangGhe"].ToString()
                };
                dsHangGhe.Add(hangGhe);
            }

            return dsHangGhe;
        }

        public bool ThemHangGhe(DTO_HangGhe hangGhe)
        {
            string query = "INSERT INTO HANGGHE (MaHangGhe, TenHangGhe) VALUES (@MaHangGhe, @TenHangGhe)";

            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@MaHangGhe", hangGhe.MaHangGhe),
                new MySqlParameter("@TenHangGhe", hangGhe.TenHangGhe)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public DTO_HangGhe? LayHangGheCuoi()
        {
            string query = "SELECT * FROM HANGGHE ORDER BY MaHangGhe DESC LIMIT 1";
            DataTable dt = dataHelper.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new DTO_HangGhe
                {
                    MaHangGhe = dr["MaHangGhe"].ToString(),
                };
            }

            return null;
        }
    }
}
