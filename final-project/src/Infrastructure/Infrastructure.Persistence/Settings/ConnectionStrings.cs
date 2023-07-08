namespace Infrastructure.Persistence.Settings;
public sealed class ConnectionStrings {
    public MongoDbSettings MongoDb { get; set; } = null!;
    public string MsSQL { get; set; } = null!;

    public class MongoDbSettings {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}