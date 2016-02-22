using System.Collections.Generic;
using System.Linq;
using Spree.Contracts;
using Spree.Infrastructure.Repositories;
using Spree.QueryModel.Queries;

namespace Spree.QueryModel
{
    public class Produkte
    {
        public IEnumerable<Produkt> Query(AlleProdukteDerKategorie query)
        {
            return MockedProdukteRepository
                    .GetAll()
                    .Where(produkt => produkt.Kategorie == query.Kategorie)
                    .ToList();
        } 
    }
}