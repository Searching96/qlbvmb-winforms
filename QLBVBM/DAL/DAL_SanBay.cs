
using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System.Data;

namespace QLBVBM.DAL
{
    public class DAL_SanBay
    {
        private DataHelper dataHelper = new DataHelper();

        public List<DTO_SanBay> LayDanhSachSanBay()
        {
            List<DTO_SanBay> dsSanBay = new List<DTO_SanBay>();
            string query = "SELECT * FROM SANBAY";
            DataTable dt = dataHelper.ExecuteQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                DTO_SanBay sanBay = new DTO_SanBay
                {
                    MaSanBay = dr["MaSanBay"].ToString(),
                    TenSanBay = dr["TenSanBay"].ToString()
                };
                dsSanBay.Add(sanBay);
            }

            return dsSanBay;
        }

        public bool ThemSanBay(DTO_SanBay sanBay)
        {
            string query = "INSERT INTO SANBAY (MaSanBay, TenSanBay) VALUES (@MaSanBay, @TenSanBay)";
            
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@MaSanBay", sanBay.MaSanBay),
                new MySqlParameter("@TenSanBay", sanBay.TenSanBay)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public DTO_SanBay? LaySanBayCuoi()
        {
            string query = "SELECT * FROM SANBAY ORDER BY MaSanBay DESC LIMIT 1";
            DataTable dt = dataHelper.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new DTO_SanBay
                {
                    MaSanBay = dr["MaSanBay"].ToString(),
                };
            }

            return null;
        }
    }
}
