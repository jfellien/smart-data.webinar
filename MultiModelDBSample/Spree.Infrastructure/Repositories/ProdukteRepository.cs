using System.Collections.Generic;
using RestSharp;
using Spree.Contracts;

namespace Spree.Infrastructure.Repositories
{
    public class ProdukteRepository
    {
        private readonly RestClient _restClient;

        private const string Url = "http://192.168.178.20:3000/";

        public ProdukteRepository()
        {
            _restClient = new RestClient(Url);
        }

        public IReadOnlyList<Produkt> DerKategorie(string kategorieName)
        {
            var retrieveFor = new RestRequest("/api/produkte-der-kategorie/{kategorie}", Method.GET);
            retrieveFor.RequestFormat = DataFormat.Json;

            retrieveFor.AddUrlSegment("kategorie", kategorieName);

            var response = _restClient.Execute<List<Produkt>>(retrieveFor);

            return response.Data;
        }
    }
}