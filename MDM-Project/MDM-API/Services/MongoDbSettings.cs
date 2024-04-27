namespace MDM_API.Services
{
    public class MongoDbSettings
    {
        public string Local { get; set; } = null!;
        public string Database { get; set; } = null!;
        public List<string> CollectionNames { get; set; } = null!;
    }
}
