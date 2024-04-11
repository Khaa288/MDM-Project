namespace MDM_API.Utilities
{
    public static class LocationQueries
    {
        public const string UPDATE_LOCATIONS_RELATIONSHIP =
            "MATCH(o:DiaDiem {MaDiaDiem: $diemDi})<-[r:CungDat]->(d:DiaDiem {MaDiaDiem: $diemDen}) " +
            "SET r.SoLan = r.SoLan + 1 " +
            "RETURN o, r, d";
    }
}
