namespace Spree.QueryModel
{
    public class Produkt
    {
        public Produkt(int id, string name, double preis, string kategorie)
        {
            Id = id;
            Name = name;
            Preis = preis;
            Kategorie = kategorie;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Preis { get; private set; }
        public string Kategorie { get; private set; }
    }
}