using Fluent_CQRS;

namespace Spree.Contracts.Events
{
    public class ProduktWurdeInWarenkorbGelegt : IAmAnEventMessage
    {
        public string Id { get; set; }
        public int ProduktId { get; set; }
    }
}