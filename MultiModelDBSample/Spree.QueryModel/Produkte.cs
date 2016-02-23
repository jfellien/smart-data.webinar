using System.Collections.Generic;
using Spree.Contracts;
using Spree.Infrastructure.Repositories;
using Spree.QueryModel.Queries;

namespace Spree.QueryModel
{
    public class Produkte
    {
        public IEnumerable<Produkt> Query(AlleProdukteDerKategorie query)
        {
            var produkte = new ProdukteRepository();

            return produkte.DerKategorie(query.Kategorie);
        } 
    }
}