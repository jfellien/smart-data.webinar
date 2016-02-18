using Spree.QueryModel;
using Spree.QueryModel.Queries;

namespace Spree.Application
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1.) Alle Produkte einer Kategorie holen
            var produkte = new Produkte();
            var dvds = produkte.Query(new AlleProdukteDerKategorie("DVD"));
            // alternative Schreibweisen:
            // --> produkte.DerKategorie("DVD");
            // --> produkte.DVDs();

            // 2.) Ausgewähltes Produkt in den Warenkorb legen

        }
    }
}
