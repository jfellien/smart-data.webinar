using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using Fluent_CQRS;
using RestSharp;
using Serilog;

namespace Spree.Infrastructure.Repositories
{
    public class EventStore : IStoreAndRetrieveEvents
    {
        private readonly RestClient _restClient;

        private const string Url = "http://localhost:3000/";

        public EventStore()
        {
            _restClient = new RestClient(Url);
        }

        public void StoreFor<TAggregate>(string aggegateId, IAmAnEventMessage eventMessage) where TAggregate : Aggregate
        {
            var storeFor = new JsonRequest("/api/event", Method.POST);
            storeFor.AddJsonBody(eventMessage);

            var response = _restClient.Execute(storeFor);

            Log.Information("StoreFor executed");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Log.Error(response.ErrorMessage);
            }
        }

        public IEnumerable<IAmAnEventMessage> RetrieveFor(string aggregateId)
        {
            var retrieveFor = new JsonRequest("/api/events-for/{id}", Method.GET);
            retrieveFor.AddUrlSegment("id", aggregateId);

            var response = _restClient.Execute(retrieveFor);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Log.Error(response.ErrorMessage);
            }

            return new List<IAmAnEventMessage>();
        }

        public IEnumerable<IAmAnEventMessage> RetrieveFor<TAggregate>(string aggregateId) where TAggregate : Aggregate
        {
            return RetrieveFor(aggregateId);
        }

        public IEnumerable<IAmAnEventMessage> RetrieveFor<TAggregate>() where TAggregate : Aggregate
        {
            throw new NotImplementedException();
        }
    }
}
