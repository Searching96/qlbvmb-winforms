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
    public class DAL_HanhKhach
    {
        private DataHelper dataHelper = new DataHelper();
        
        public bool ThemHanhKhach(DTO_HanhKhach hanhKhach)
        {
            string query = "INSERT INTO HANHKHACH (MaHanhKhach, HoTen, CMND, SDT) " +
                "VALUES (@MaHanhKhach, @HoTen, @CMND, @SDT)";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaHanhKhach", hanhKhach.MaHanhKhach),
                new MySqlParameter("@HoTen", hanhKhach.HoTen),
                new MySqlParameter("@CMND", hanhKhach.SoCMND),
                new MySqlParameter("@SDT", hanhKhach.SoDT)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public DTO_HanhKhach? LayHanhKhachCuoi()
        {
            string query = "SELECT * FROM HANHKHACH ORDER BY MaHanhKhach DESC LIMIT 1";
            DataTable dt = dataHelper.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new DTO_HanhKhach
                {
                    MaHanhKhach = dr["MaHanhKhach"].ToString(),
                };
            }
            return null;
        }

        public List<DTO_HanhKhach> LayDanhSachHanhKhach()
        {
            List<DTO_HanhKhach> dsHanhKhach = new List<DTO_HanhKhach>();
            string query = "SELECT * FROM HANHKHACH";
            DataTable dt = dataHelper.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                DTO_HanhKhach hanhKhach = new DTO_HanhKhach
                {
                    MaHanhKhach = dr["MaHanhKhach"].ToString(),
                    HoTen = dr["HoTen"].ToString(),
                    SoCMND = dr["CMND"].ToString(),
                    SoDT = dr["SDT"].ToString()
                };
                dsHanhKhach.Add(hanhKhach);
            }
            return dsHanhKhach;
        }
    }
}
