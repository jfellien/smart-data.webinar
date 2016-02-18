using System.Collections.Generic;

namespace Spree.QueryModel
{
    class MockedProdukteRepository
    {
        public static IEnumerable<Produkt> GetAll()
        {
            return new List<Produkt>
            {
                new Produkt(1, "Matrix 1", 9.99, "DVD"),
                new Produkt(2, "Matrix 2", 9.99, "DVD"),
                new Produkt(3, "Einer flog übers Kuckucksnest", 4.99, "VHS")
            };
        } 
    }
}