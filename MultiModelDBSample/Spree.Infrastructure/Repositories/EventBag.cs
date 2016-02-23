using System;

namespace Spree.Infrastructure.Repositories
{
    class EventBag
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Timestamp { get; set; }
        public string Payload { get; set; }
    }
}