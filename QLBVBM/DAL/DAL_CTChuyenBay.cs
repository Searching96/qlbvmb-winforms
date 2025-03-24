using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVBM.DAL
{
    public class DAL_CTChuyenBay
    {
        private DataHelper dataHelper = new DataHelper();

        public bool ThemCTChuyenBay(DTO_CTChuyenBay ctChuyenBay)
        {
            string query = "INSERT INTO CTCHUYENBAY (MaChuyenBay, MaSanBayTG, ThoiGianDung, GhiChu) " +
                "VALUES (@MaChuyenBay, @MaSanBayTG, @ThoiGianDung, @GhiChu)";
            
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaChuyenBay", ctChuyenBay.MaChuyenBay),
                new MySqlParameter("@MaSanBayTG", ctChuyenBay.MaSanBayTG),
                new MySqlParameter("@ThoiGianDung", ctChuyenBay.ThoiGianDung),
                new MySqlParameter("@GhiChu", ctChuyenBay.GhiChu)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
