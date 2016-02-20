using System.Collections.Generic;

namespace Spree.QueryModel
{
    class MockedWarenkörbeRepository
    {
        public static IEnumerable<Warenkorb> GetAll()
        {
            return new List<Warenkorb>
            {
                new Warenkorb("1", "1"),
                new Warenkorb("2", "2"),
                new Warenkorb("3", "3")
            };
        } 
    }
}