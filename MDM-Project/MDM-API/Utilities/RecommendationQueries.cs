namespace MDM_API.Utilities
{
    public class RecommendationQueries
    {
        // Recommend top 3 trip based on the most frequently booking tickets
        public const string RECOMMENDATION1 =
            "MATCH (tk: TaiKhoan {MaTaiKhoan: $maTaiKhoan})-[r:DaDat]->(cx:ChuyenXe) " +
            "RETURN cx " +
            "ORDER BY r.SoLan DESC " +
            "LIMIT 3 ";

        // Recommend top 5 trips based on top 3 latest tickets -> get locations -> Top [2 -> 10] new trip based on the locations
        public const string RECOMMENDATION2 =
            "MATCH p = (tk:TaiKhoan {MaTaiKhoan: $maTaiKhoan})-[r:Dat]->(cx:ChuyenXe)-[]->(dd:DiaDiem)<-[]-(gy:ChuyenXe) " +
            "WHERE cx.MaChuyen <> gy.MaChuyen " +
            "RETURN collect(gy)[0..2] as cx";

        // Recommend top 3 trips based on top 1 locations pairs with highest "CungDat" relationship number 
        public const string GET_MOST_FREQUENT_ORDER_ALONG_LOCATIONS =
            "MATCH (dd1:DiaDiem)-[r:CungDat]->(dd2:DiaDiem) " +
            "RETURN dd1, dd2 " +
            "ORDER BY r.SoLan DESC " +
            "LIMIT 1 ";

        public const string RECOMMENDATION3 =
            "MATCH (origin:DiaDiem)<-[:CoDiemDi]-(cx:ChuyenXe)-[:CoDiemDen]->(des:DiaDiem) " +
            "WHERE " +
                "(origin.MaDiaDiem = $maDiaDiem1 and des.MaDiaDiem = $maDiaDiem2) or " +
                "(origin.MaDiaDiem = $maDiaDiem2 and des.MaDiaDiem = $maDiaDiem1) " +
            "RETURN cx " +
            "LIMIT 3 ";
    }
}
