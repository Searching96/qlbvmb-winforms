using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System.Data;

namespace QLBVBM.DAL
{
    public class DAL_VeChuyenBay
    {
        private DataHelper dataHelper = new DataHelper();

        public bool ThemVeChuyenBay(DTO_VeChuyenBay veChuyenBay)
        {
            string query = "INSERT INTO VECHUYENBAY (MaVe, MaChuyenBay, MaHangGhe, MaHanhKhach) " +
                "VALUES (@MaVe, @MaChuyenBay, @MaHangGhe, @MaHanhKhach";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaVe", veChuyenBay.MaVe),
                new MySqlParameter("@MaChuyenBay", veChuyenBay.MaChuyenBay),
                new MySqlParameter("@MaHangGhe", veChuyenBay.MaHangGhe),
                new MySqlParameter("@SoGhe", veChuyenBay.MaHanhKhach)
            };
            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public DTO_VeChuyenBay? LayVeChuyenBayCuoi()
        {
            string query = "SELECT * FROM VECHUYENBAY ORDER BY MaVe DESC LIMIT 1";
            DataTable dt = dataHelper.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new DTO_VeChuyenBay
                {
                    MaVe = dr["MaVe"].ToString(),
                };
            }
            return null;
        }

        public List<DTO_VeChuyenBay> LayDanhSachVeChuyenBay()
        {
            List<DTO_VeChuyenBay> dsVeChuyenBay = new List<DTO_VeChuyenBay>();
            string query = "SELECT * FROM VECHUYENBAY";
            DataTable dt = dataHelper.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                DTO_VeChuyenBay veChuyenBay = new DTO_VeChuyenBay
                {
                    MaVe = dr["MaVe"].ToString(),
                    MaChuyenBay = dr["MaChuyenBay"].ToString(),
                    MaHangGhe = dr["MaHangGhe"].ToString(),
                    MaHanhKhach = dr["MaHanhKhach"].ToString()
                };
                dsVeChuyenBay.Add(veChuyenBay);
            }
            return dsVeChuyenBay;
        }
    }
}
