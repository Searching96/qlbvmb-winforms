﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using QLBVBM.DTO;
using System.Data;
using System.Diagnostics;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QLBVBM.DAL
{
    public class DAL_VeChuyenBay
    {
        private DataHelper dataHelper = new DataHelper();

        public bool ThemVeChuyenBay(DTO_VeChuyenBay veChuyenBay)
        {
            try
            {
                string query = "INSERT INTO VECHUYENBAY (MaVe, MaChuyenBay, MaHangGhe, TenHanhKhach, CMND, SoDienThoai, DonGia, TrangThaiVe) " +
                "VALUES (@MaVe, @MaChuyenBay, @MaHangGhe, @TenHanhKhach, @CMND, @SoDienThoai, @DonGia, @TrangThaiVe)";
                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaVe", veChuyenBay.MaVe),
                    new MySqlParameter("@MaChuyenBay", veChuyenBay.MaChuyenBay),
                    new MySqlParameter("@MaHangGhe", veChuyenBay.MaHangGhe),
                    new MySqlParameter("@TenHanhKhach", veChuyenBay.TenHanhKhach),
                    new MySqlParameter("@CMND", veChuyenBay.SoCMND),
                    new MySqlParameter("@SoDienThoai", veChuyenBay.SoDT),
                    new MySqlParameter("@DonGia", veChuyenBay.DonGia),
                    new MySqlParameter("@TrangThaiVe", veChuyenBay.TrangThaiVe)
                };
                int result = dataHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ThemVeChuyenBay (DAL_VeChuyenBay.cs): {ex.Message}");
                return false;
            }
        }

        public bool DatVeChuyenBay(DTO_VeChuyenBay veChuyenBay)
        {
            try
            {
                string query = "INSERT INTO VECHUYENBAY (MaVe, MaChuyenBay, MaHangGhe, TenHanhKhach, CMND, SoDienThoai, DonGia) " +
                "VALUES (@MaVe, @MaChuyenBay, @MaHangGhe, @TenHanhKhach, @CMND, @SoDienThoai, @DonGia)";
                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaVe", veChuyenBay.MaVe),
                    new MySqlParameter("@MaChuyenBay", veChuyenBay.MaChuyenBay),
                    new MySqlParameter("@MaHangGhe", veChuyenBay.MaHangGhe),
                    new MySqlParameter("@TenHanhKhach", veChuyenBay.TenHanhKhach),
                    new MySqlParameter("@CMND", veChuyenBay.SoCMND),
                    new MySqlParameter("@SoDienThoai", veChuyenBay.SoDT),
                    new MySqlParameter("@DonGia", veChuyenBay.DonGia),
                    new MySqlParameter("@TrangThaiVe", 2) //Chua thanh toan
                };
                int result = dataHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in DatVeChuyenBay (DAL_VeChuyenBay.cs): {ex.Message}");
                return false;
            }
        }

        public DTO_VeChuyenBay? LayVeChuyenBayCuoi()
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayVeChuyenBayCuoi (DAL_VeChuyenBay.cs): {ex.Message}");
                return null;
            }
        }

        public List<DTO_VeChuyenBay> LayDanhSachVeChuyenBay()
        {
            List<DTO_VeChuyenBay> dsVeChuyenBay = new List<DTO_VeChuyenBay>();

            try
            {
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
                        DonGia = Convert.ToInt32(dr["DonGia"]),
                        TrangThaiVe = Convert.ToInt32(dr["TrangThaiVe"]),
                    };
                    dsVeChuyenBay.Add(veChuyenBay);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayDanhSachVeChuyenBay (DAL_VeChuyenBay.cs): {ex.Message}");
                return new List<DTO_VeChuyenBay>();
            }

            return dsVeChuyenBay;
        }

        public List<DTO_VeChuyenBay> LayVeChuyenBayTheoMaChuyenBay(string maChuyenBay)
        {
            List<DTO_VeChuyenBay> dsVeChuyenBay = new List<DTO_VeChuyenBay>();

            try
            {
                string query = "SELECT * FROM VECHUYENBAY WHERE MaChuyenBay = @MaChuyenBay";
                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@MaChuyenBay", maChuyenBay)
                };

                DataTable dt = dataHelper.ExecuteQuery(query, parameters);
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
                        DonGia = Convert.ToInt32(dr["DonGia"]),
                        TrangThaiVe = Convert.ToInt32(dr["TrangThaiVe"]),
                    };
                    dsVeChuyenBay.Add(veChuyenBay);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayVeChuyenBayTheoMaChuyenBay (DAL_VeChuyenBay.cs): {ex.Message}");
                return new List<DTO_VeChuyenBay>();
            }

            return dsVeChuyenBay;
        }
      
        public List<DTO_VeChuyenBay> LayDanhSachVeDaThanhToan(String maChuyenBay)
        {
            List<DTO_VeChuyenBay> dsVeThanhToan = new List<DTO_VeChuyenBay>();

            try
            {
                string query = @"
                                SELECT vcb.*
                                FROM VECHUYENBAY vcb
                                JOIN HANGVECB hvcb ON vcb.MaChuyenBay = hvcb.MaChuyenBay
                                AND vcb.MaHangGhe = hvcb.MaHangGhe 
                                WHERE TrangThaiVe = 1
                                AND vcb.MaChuyenBay = @maChuyenBay
                                ";

                var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@maChuyenBay", maChuyenBay)
            };

                DataTable dt = dataHelper.ExecuteQuery(query, parameters);
                foreach (DataRow dr in dt.Rows)
                {
                    DTO_VeChuyenBay ve = new DTO_VeChuyenBay
                    {
                        MaVe = dr["MaVe"].ToString(),
                        MaChuyenBay = dr["MaChuyenBay"].ToString(),
                        MaHangGhe = dr["MaHangGhe"].ToString(),
                        TenHanhKhach = dr["TenHanhKhach"].ToString(),
                        SoCMND = dr["CMND"].ToString(),
                        SoDT = dr["SoDienThoai"].ToString(),
                        DonGia = Convert.ToInt32(dr["DonGia"]),
                        TrangThaiVe = Convert.ToInt32(dr["TrangThaiVe"])
                    };
                    dsVeThanhToan.Add(ve);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LayDanhSachVeDaThanhToan (DAL_VeChuyenBay.cs): {ex.Message}");
                return new List<DTO_VeChuyenBay>();
            }
            

            return dsVeThanhToan;
        }
    }
}
