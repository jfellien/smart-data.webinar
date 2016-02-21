using System;
using System.Collections.Generic;
using Fluent_CQRS;
using Serilog;
using Spree.Domain.Events;

namespace Spree.Domain.Model
{
    class Warenkorb : Aggregate
    {
        public Warenkorb(string id, IEnumerable<IAmAnEventMessage> history) : base(id, history)
        {

        }

        public void ProduktHinzufügen(int produktId)
        {
            Log.Information("Add Product {productId}", produktId);

            Changes.Add(new ProduktWurdeInWarenkorbGelegt
            {
                Id = Id,
                ProduktId = produktId
            });
        }
    }
}
