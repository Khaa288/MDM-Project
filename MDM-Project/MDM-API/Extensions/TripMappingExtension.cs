using MDM_API.Models;
using Neo4j.Driver;

public static class TripMappingExtension {
    public static IEnumerable<TripResponse> Map(this List<IRecord> list) {
        return list.Select(value => {
                return new TripResponse {
                    TripId = value["cx"].As<INode>().Properties["MaChuyen"].As<string>(),
                    VehicleType = value["cx"].As<INode>().Properties["LoaiXe"].As<string>(),
                    JourneyType = value["cx"].As<INode>().Properties["LoaiHanhTrinh"].As<string>(),
                    EmptySeats = value["cx"].As<INode>().Properties["SoGheTrong"].As<string>(),
                    StartTime = value["cx"].As<INode>().Properties["ThoiGianKhoiHanh"].As<string>(),
                    ArrivedTime = value["cx"].As<INode>().Properties["ThoiGianDen"].As<string>(),

                    OriginName = value["origin"].As<INode>().Properties["TenDiaDiem"].As<string>(),
                    DestinationName = value["des"].As<INode>().Properties["TenDiaDiem"].As<string>(),
                };
        });
    }
}