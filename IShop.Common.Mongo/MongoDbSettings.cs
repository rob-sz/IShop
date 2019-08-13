using System.Collections.Generic;

namespace IShop.Common.Mongo
{
    public class MongoDbSettings
    {
        public IEnumerable<Database> Databases { get; set; }

        public class Database
        {
            public string Name { get; set; }
            public string ConnectionString { get; set; }
        }
    }
}
