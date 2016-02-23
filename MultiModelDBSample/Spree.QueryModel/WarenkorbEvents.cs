using System.Collections.Generic;
using System.Linq;
using Fluent_CQRS;
using Fluent_CQRS.Extensions;
using Serilog;
using Spree.Contracts.Events;
using Spree.Infrastructure.Repositories;

namespace Spree.QueryModel
{
    public class WarenkorbEvents : IHandleEvents
    {
        
        public void Receive(IEnumerable<IAmAnEventMessage> events)
        {
            events.ToList().ForEach(message => message.HandleMeWith(this));
        }

        void Handle(ProduktWurdeInWarenkorbGelegt message)
        {
            var produkt = MockedProdukteRepository.GetAll().First(prod => prod.Id == message.ProduktId);

            var warenkorb = MockedWarenkörbeRepository.GetAll().First(korb => korb.Id == message.Id);

            warenkorb.Produkte.Add(produkt);

            MockedWarenkörbeRepository.Store(warenkorb);

            Log.Information("Produkt wurde in den Warenkorb gelegt und gespeichert.");
        }
    }
}
