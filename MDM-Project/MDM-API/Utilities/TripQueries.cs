namespace MDM_API.Utilities
{
    public static class TripQueries
    {
        public const string GET_TRIP =
            "MATCH(cx:ChuyenXe {MaChuyen: $maChuyen}) " +
            "RETURN cx";

        public const string GET_TRIP_LOCATIONS =
            "MATCH(cx:ChuyenXe {MaChuyen: $maChuyen})-[]->(dd:DiaDiem)" +
            "RETURN dd";

        public const string UPDATE_TRIP_SEAT_QUANTITY = 
            "MATCH(cx:ChuyenXe {MaChuyen: $maChuyen}) " +
            "SET cx.SoGheTrong = $soGheConLai RETURN cx";

        public const string GET_TRIP_USER_RELATIONSHIP =
            "MATCH(cx:ChuyenXe {MaChuyen: $maChuyen})<-[r:DaDat]-(tk:TaiKhoan {MaTaiKhoan: $maTaiKhoan}) " +
            "RETURN count(r) as exists";

        public const string CREATE_TRIP_USER_RELATIONSHIP =
            "MATCH(cx:ChuyenXe {MaChuyen: $maChuyen}), (tk:TaiKhoan {MaTaiKhoan: $maTaiKhoan})" +
            "CREATE (cx)<-[:DaDat { SoLan: 1 }]-(tk)";

        public const string UPDATE_TRIP_USER_RELATIONSHIP =
            "MATCH(cx:ChuyenXe {MaChuyen: $maChuyen})<-[r:DaDat]-(tk:TaiKhoan {MaTaiKhoan: $maTaiKhoan}) " +
            "SET r.SoLan = r.SoLan + 1";
    }
}
