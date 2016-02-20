using System.Linq;
using Spree.Domain.Warenkorb.Commands;
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

            // 2.) Warenkob des Users laden
            var warenkörbe = new Warenkörbe();
            var warenkorb = warenkörbe.Query(new WarenkorbDesUsers{UserId = "1"});

            // HINWEIS:
            // Anzeigen der Produkte damit der Anwender auswählen kann
            // In diesem Beispiel tuen wir so, als wenn der Anwender die erste DVD ausgewählt hat

            // 3.) Ausgewähltes Produkt in den Warenkorb legen
            var produktInDenWarenKorbLegen = new ProduktInDenWarenkorbLegen
            {
                Id = warenkorb.Id,
                ProduktId = dvds.First().Id
            };
        }
    }
}
