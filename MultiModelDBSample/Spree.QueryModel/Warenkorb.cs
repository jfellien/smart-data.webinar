namespace Spree.QueryModel
{
    public class Warenkorb
    {
        public Warenkorb(string id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        public string Id { get; private set; }
        public string UserId { get; private set; }
    }
}