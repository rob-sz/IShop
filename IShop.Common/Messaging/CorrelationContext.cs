using System;

namespace IShop.Common.Messaging
{
    public class CorrelationContext : ICorrelationContext
    {
        public Guid CorrelationId { get; set; }
        public DateTime CorrelationDate { get; set; }
        public string TraceIdentifier { get; set; }
        public string ResourcePath { get; set; }
    }
}
