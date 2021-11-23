namespace Catalog_api.Settings
{
    public class MongoDbSettings
    {
        public string? ConnectionString 
        { 
            get
            {
                var protocol = Environment.GetEnvironmentVariable("MONGO_PROTOCOL");
                var host = Environment.GetEnvironmentVariable("MONGO_HOST");
                var port = Environment.GetEnvironmentVariable("MONGO_PORT");
                var user = Environment.GetEnvironmentVariable("MONGO_USER");
                var password = Environment.GetEnvironmentVariable("MONGO_PASSWORD");
                return $"{protocol}://{user}:{password}@{host}:{port}";
            }
        }
    }
}
