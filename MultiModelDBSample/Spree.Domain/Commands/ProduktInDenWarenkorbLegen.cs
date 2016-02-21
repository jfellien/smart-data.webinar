using Fluent_CQRS;

namespace Spree.Domain.Commands
{
    public class ProduktInDenWarenkorbLegen : IAmACommandMessage
    {
        public string Id { get; set; }
        public int ProduktId { get; set; }
    }
}