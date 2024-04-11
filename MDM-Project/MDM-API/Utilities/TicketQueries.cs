namespace MDM_API.Utilities
{
    public static class TicketQueries
    {
        public const string GET_ALL_TICKETS = "MATCH(vx:VeXe) return vx";

        public const string CREATE_TICKET = 
            "CREATE (vx1:VeXe " +
            "{" +
                "MaDatVe: $maDatVe, " +
                "ThoiGian: $date, " +
                "SoGhe: $soGhe, " +
                "DiemLenXe: '113 SaiGon', " +
                "MaHoaDon: 1, " +
                "TrangThai: 'Đã thanh toán', " +
                "TongTien: 500000" +
            "})";

        public const string CREATE_TICKET_TRIP_RELATIONSHIP =
            "MATCH(cx:ChuyenXe {MaChuyen: $maChuyen}), (vx:VeXe {MaDatVe: $maDatVe}) " +
            "WITH cx, vx " +
            "CREATE (vx)-[:BaoGom]->(cx);";

        public const string CREATE_USER_TICKET_RELATIONSHIP =
            "MATCH(tk:TaiKhoan {MaTaiKhoan: $maTaiKhoan}), (vx: VeXe {MaDatVe: $maDatVe})" +
            "WITH tk, vx " +
            "CREATE (tk)-[:Dat]->(vx)";
    }
}
