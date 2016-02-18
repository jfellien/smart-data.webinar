namespace Spree.QueryModel.Queries
{
    public class AlleProdukteDerKategorie
    {
        public AlleProdukteDerKategorie(string kategorie)
        {
            Kategorie = kategorie;
        }
        public string Kategorie { get; private set; }
    }
}