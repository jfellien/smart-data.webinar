using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using fastJSON;
using Fluent_CQRS;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using Serilog;
using Spree.Contracts;
using Spree.Contracts.Events;

namespace Spree.Infrastructure.Repositories
{
    public class EventStore : IStoreAndRetrieveEvents
    {
        private readonly RestClient _restClient;

        private const string Url = "http://192.168.178.20:3000/";

        public EventStore()
        {
            _restClient = new RestClient(Url);
        }

        public void StoreFor<TAggregate>(string aggegateId, IAmAnEventMessage eventMessage) where TAggregate : Aggregate
        {
            var storeFor = new JsonRequest("/api/event", Method.POST);

            var serializer = new JsonSerializer();

            var payload = serializer.Serialize(eventMessage);
            var eventBag = serializer.Serialize(new EventBag
                {
                    Id = aggegateId,
                    Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Type = eventMessage.GetType().ToString(),
                    Payload = payload
                });

            storeFor.AddParameter("application/json; charset=utf-8", eventBag, ParameterType.RequestBody);
            
            var response = _restClient.Execute(storeFor);

            Log.Information("StoreFor executed");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Log.Error(response.ErrorMessage);
            }
        }

        public IEnumerable<IAmAnEventMessage> RetrieveFor(string aggregateId)
        {
            var retrieveFor = new RestRequest("/api/events-for/{id}", Method.GET);
            retrieveFor.RequestFormat = DataFormat.Json;

            retrieveFor.AddUrlSegment("id", aggregateId);

            var response = _restClient.Execute<List<EventBag>>(retrieveFor);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Log.Error(response.ErrorMessage);
            }

            var events = new List<IAmAnEventMessage>();

            response.Data.ForEach(eventBag =>
            {
                
                var typeOfEvent = ContractTypes.ResolveFrom(eventBag.Type);
                var eventObject = JSON.ToObject(eventBag.Payload, typeOfEvent);

                events.Add(eventObject as IAmAnEventMessage);
            });

            return events;
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
