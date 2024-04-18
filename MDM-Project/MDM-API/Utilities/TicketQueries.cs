namespace MDM_API.Utilities
{
    public static class TicketQueries
    {
        public const string GET_ALL_TICKETS = "MATCH(vx:VeXe) return vx";

        public const string CREATE_TICKET = 
            "MATCH (tk: TaiKhoan {MaTaiKhoan: $maTaiKhoan}), (cx:ChuyenXe {MaChuyen: $maChuyen}) " +
            "CREATE (tk)" +
            "-[:Dat {" +
                "MaDatVe: $maDatVe, " +
                "ThoiGian: $date, " +
                "SoGhe: $soGhe, " +
                "DiemLenXe: '113 SaiGon', " +
                "MaHoaDon: 1, " +
                "TrangThai: 'Đã thanh toán', " +
                "TongTien: 500000" +
            "}]" +
            "->(cx)";
    }
}
