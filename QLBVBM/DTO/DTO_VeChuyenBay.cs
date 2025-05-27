namespace QLBVBM.DTO
{
    public enum TrangThaiVe
    {
        TatCa = -1,
        DaHuy = 0,
        DaThanhToan = 1,
        ChuaThanhToan = 2
    }
    public class DTO_VeChuyenBay
    {
        private string? maVe;
        private string? maChuyenBay;
        private string? maHangGhe;
        private string? tenHanhKhach;
        private string? CMND;
        private string? SDT;
        private int? donGia;
        private int? trangThaiVe;

        public DTO_VeChuyenBay(string? maVe = null, string? maChuyenBay = null,
                            string? maHangGhe = null, string? tenHanhKhach = null,
                            string? CMND = null, string? SDT = null, int? donGia = null, int? trangThaiVe = null)
        {
            this.maVe = maVe;
            this.maChuyenBay = maChuyenBay;
            this.maHangGhe = maHangGhe;
            this.tenHanhKhach = tenHanhKhach;
            this.CMND = CMND;
            this.SDT = SDT;
            this.donGia = donGia;
            this.trangThaiVe = trangThaiVe;
        }

        public string? MaVe { get => maVe; set => maVe = value; }
        public string? MaChuyenBay { get => maChuyenBay; set => maChuyenBay = value; }
        public string? MaHangGhe { get => maHangGhe; set => maHangGhe = value; }
        public string? TenHanhKhach { get => tenHanhKhach; set => tenHanhKhach = value; }
        public string? SoCMND { get => CMND; set => CMND = value; }
        public string? SoDT { get => SDT; set => SDT = value; }
        public int? DonGia { get => donGia; set => donGia = value; }
        public int? TrangThaiVe { get => trangThaiVe; set => trangThaiVe = value; }
    }
}
