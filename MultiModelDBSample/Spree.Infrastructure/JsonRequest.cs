using RestSharp;

namespace Spree.Infrastructure
{
    class JsonRequest : RestRequest
    {
        public JsonRequest(string resource, Method method) : base(resource, method)
        {
            AddHeader("Content-Type", "application/json");
        }
    }
}