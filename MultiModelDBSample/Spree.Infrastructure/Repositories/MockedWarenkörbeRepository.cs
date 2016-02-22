using System.Collections.Generic;
using Spree.Contracts;

namespace Spree.Infrastructure.Repositories
{
    public class MockedWarenkörbeRepository
    {
        static readonly IList<Warenkorb> Database = new List<Warenkorb>
            {
                new Warenkorb("1", "1"),
                new Warenkorb("2", "2"),
                new Warenkorb("3", "3")
            };

        public static IEnumerable<Warenkorb> GetAll()
        {
            return Database;
        }

        public static void Store(Warenkorb warenkorb)
        {
            // HINWEIS:
            // Der Warenkorb hat schon sein Produkt, 
            // weil im EventHandler die Zuordnungnschon erfolgte und die Daten InMemory verarbeitet werden.
        }
    }
}