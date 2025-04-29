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
            string query = "INSERT INTO VECHUYENBAY (MaVe, MaChuyenBay, MaHangGhe, TenHanhKhach, CMND, SoDienThoai) " +
                "VALUES (@MaVe, @MaChuyenBay, @MaHangGhe, @TenHanhKhach, @CMND, @SoDienThoai)";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaVe", veChuyenBay.MaVe),
                new MySqlParameter("@MaChuyenBay", veChuyenBay.MaChuyenBay),
                new MySqlParameter("@MaHangGhe", veChuyenBay.MaHangGhe),
                new MySqlParameter("@TenHanhKhach", veChuyenBay.TenHanhKhach),
                new MySqlParameter("@CMND", veChuyenBay.SoCMND),
                new MySqlParameter("@SoDienThoai", veChuyenBay.SoDT),
                new MySqlParameter("@TrangThaiVe", 1)
            };
            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DatVeChuyenBay(DTO_VeChuyenBay veChuyenBay)
        {
            string query = "INSERT INTO VECHUYENBAY (MaVe, MaChuyenBay, MaHangGhe, TenHanhKhach, CMND, SoDienThoai) " +
                "VALUES (@MaVe, @MaChuyenBay, @MaHangGhe, @TenHanhKhach, @CMND, @SoDienThoai)";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaVe", veChuyenBay.MaVe),
                new MySqlParameter("@MaChuyenBay", veChuyenBay.MaChuyenBay),
                new MySqlParameter("@MaHangGhe", veChuyenBay.MaHangGhe),
                new MySqlParameter("@TenHanhKhach", veChuyenBay.TenHanhKhach),
                new MySqlParameter("@CMND", veChuyenBay.SoCMND),
                new MySqlParameter("@SoDienThoai", veChuyenBay.SoDT),
                new MySqlParameter("@TrangThaiVe", 2)
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
                    TenHanhKhach = dr["TenHanhKhach"].ToString(),
                    SoCMND = dr["CMND"].ToString(),
                    SoDT = dr["SoDienThoai"].ToString(),
                    TrangThaiVe = Convert.ToInt32(dr["TrangThaiVe"]),
                    ThoiDiemThanhToan = dr["ThoiDiemThanhToan"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["ThoiDiemThanhToan"]) : null
                };
                dsVeChuyenBay.Add(veChuyenBay);
            }
            return dsVeChuyenBay;
        }
    }
}
