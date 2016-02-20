using System.Linq;
using Spree.QueryModel.Queries;

namespace Spree.QueryModel
{
    public class Warenkörbe
    {
        public Warenkorb Query(WarenkorbDesUsers query)
        {
            return MockedWarenkörbeRepository
                .GetAll()
                .Single(warenkorb => warenkorb.UserId == query.UserId);

        }
    }
}