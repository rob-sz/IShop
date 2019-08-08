using System.Collections.Generic;

namespace IShop.Common.Networking
{
    public class RestClientSettings
    {
        public IEnumerable<Service> Services { get; set; }

        public class Service
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Host { get; set; }
            public int Port { get; set; }
        }
    }
}
