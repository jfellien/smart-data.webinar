using System.Collections.Generic;

namespace Spree.Contracts
{
    public class Warenkorb
    {
        public Warenkorb(string id, string userId)
        {
            Id = id;
            UserId = userId;
            Produkte = new List<Produkt>();
        }

        public string Id { get; private set; }
        public string UserId { get; private set; }
        public IList<Produkt> Produkte { get; set; }
    }
}