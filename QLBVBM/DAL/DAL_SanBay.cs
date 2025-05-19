using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System.Data;
using System.Diagnostics;

namespace QLBVBM.DAL
{
    public class DAL_SanBay
    {
        private DataHelper dataHelper = new DataHelper();

        public List<DTO_SanBay> LayDanhSachSanBay()
        {
            List<DTO_SanBay> dsSanBay = new List<DTO_SanBay>();
            try
            {
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayDanhSachSanBay (DAL_SanBay.cs): {ex.Message}");
                return new List<DTO_SanBay>();
            }
            return dsSanBay;
        }

        public bool ThemSanBay(DTO_SanBay sanBay)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ThemSanBay (DAL_SanBay.cs): {ex.Message}");
                return false;
            }
        }

        public DTO_SanBay? LaySanBayCuoi()
        {
            try
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LaySanBayCuoi (DAL_SanBay.cs): {ex.Message}");
            }
            return null;
        }
    }
}
