using System;

namespace IShop.Common.Networking
{
    public class ServiceNotFoundException : Exception
    {
        public string ServiceName { get; set; }

        public ServiceNotFoundException(string serviceName)
            : this(string.Empty, serviceName)
        {
        }

        public ServiceNotFoundException(string message, string serviceName)
            : base(message)
        {
            ServiceName = serviceName;
        }
    }
}
