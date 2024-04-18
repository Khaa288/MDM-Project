namespace MDM_API.Utilities
{
    public class RecommendationQueries
    {
        // Recommend top 3 trip based on the most frequently booking tickets
        public const string RECOMMENDATION1 =
            "MATCH (tk: TaiKhoan {MaTaiKhoan: $maTaiKhoan})-[r:DaDat]->(cx:ChuyenXe) " +
            "RETURN r.SoLan, cx.MaChuyen " +
            "ORDER BY r.SoLan DESC " +
            "LIMIT 3 ";

        // Recommend top 5 trips based on top 3 latest tickets -> get locations -> Top [2 -> 10] new trip based on the locations
        public const string RECOMMENDATION2 =
            "MATCH p = (tk:TaiKhoan {MaTaiKhoan: $maTaiKhoan})-[r:Dat]->(cx:ChuyenXe)-[]->(dd:DiaDiem)<-[]-(gy:ChuyenXe) " +
            "WHERE cx.MaChuyen <> gy.MaChuyen " +
            "RETURN dd.TenDiaDiem, collect(gy.MaChuyen)[0..2] ";

        // Recommend top 3 trips based on top 1 locations pairs with highest "CungDat" relationship number 
        public const string RECOMMENDATION3 =
            "CALL { " +
                "MATCH (dd1:DiaDiem)-[r:CungDat]->(dd2:DiaDiem) " +
                "RETURN dd1, dd2 " +
                "ORDER BY r.SoLan DESC " +
                "LIMIT 1 " +
            "} " +
            "MATCH (origin:DiaDiem)<-[:CoDiemDi]-(cx:ChuyenXe)-[:CoDiemDen]->(d2:des) " +
            "WHERE (origin = dd1 and des = dd2) or (origin = dd2 and des = dd1) " +
            "RETURN cx " +
            "LIMIT 3 ";
    }
}
