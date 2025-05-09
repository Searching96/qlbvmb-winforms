﻿using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
            string query = "INSERT INTO HANGVECB (MaChuyenBay, MaHangGhe, SoLuongGhe, SoLuongGheDaBan, SLGheDaDat, DonGia) " +
                "VALUES (@MaChuyenBay, @MaHangGhe, @SoLuongGhe, @SoLuongGheDaBan, @SLGheDaDat, @DonGia)";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaChuyenBay", hangVeCB.MaChuyenBay),
                new MySqlParameter("@MaHangGhe", hangVeCB.MaHangGhe),
                new MySqlParameter("@SoLuongGhe", hangVeCB.SoLuongGhe),
                new MySqlParameter("@SoLuongGheDaBan", hangVeCB.SoLuongGheDaBan ?? 0),
                new MySqlParameter("@SLGheDaDat", hangVeCB.SoLuongGheDaDat ?? 0),
                new MySqlParameter("@DonGia", hangVeCB.DonGia)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool CapNhatSoLuongVeDaBan(string maChuyenBay, string maHangGhe)
        {
            string query = @"UPDATE HANGVECB 
                            SET SoLuongGheDaBan = SoLuongGheDaBan + 1 
                            WHERE MaChuyenBay = @MaChuyenBay 
                            AND MaHangGhe = @MaHangGhe";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaChuyenBay", maChuyenBay),
                new MySqlParameter("@MaHangGhe", maHangGhe)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public List<DTO_HangVeCB> TraCuuHangVe(string maChuyenBay)
        {
            List<DTO_HangVeCB> dsHangVe = new List<DTO_HangVeCB>();

            string query = $"SELECT * FROM HANGVECB WHERE MaChuyenBay = '{maChuyenBay}'";
            DataTable dt = dataHelper.ExecuteQuery(query);

            foreach (DataRow dr in dt.Rows)
            {
                DTO_HangVeCB hangVeCB = new DTO_HangVeCB
                {
                    MaChuyenBay = dr["MaChuyenBay"].ToString(),
                    MaHangGhe = dr["MaHangGhe"].ToString(),
                    SoLuongGhe = Convert.ToInt32(dr["SoLuongGhe"]),
                    SoLuongGheDaBan = Convert.ToInt32(dr["SoLuongGheDaBan"]),
                    DonGia = Convert.ToInt32(dr["DonGia"])
                };
                dsHangVe.Add(hangVeCB);
            }
            return dsHangVe;
        }

        public bool CapNhatSoLuongGheDaDat(string maChuyenBay, string maHangGhe)
        {
            string query = @"UPDATE HANGVECB 
                            SET SLGheDaDat = SLGheDaDat + 1 
                            WHERE MaChuyenBay = @MaChuyenBay 
                            AND MaHangGhe = @MaHangGhe";

            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@MaChuyenBay", maChuyenBay),
                new MySqlParameter("@MaHangGhe", maHangGhe)
            };

            int result = dataHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
