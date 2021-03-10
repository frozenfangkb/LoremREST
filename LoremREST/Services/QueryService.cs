using LoremREST.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoremREST.Services
{
    public class QueryService
    {
        private readonly IMongoCollection<Query> _queries;

        public QueryService(IQueryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _queries = database.GetCollection<Query>(settings.QueryCollectionName);
        }

        public List<Query> Get() =>
            _queries.Find(Query => true).ToList();

        public Query Get(string id) =>
            _queries.Find<Query>(Query => Query.oid == id).FirstOrDefault();

        public Query Create(Query Query)
        {
            _queries.InsertOne(Query);
            return Query;
        }

        public void Update(string id, Query QueryIn) =>
            _queries.ReplaceOne(Query => Query.oid == id, QueryIn);

        public void Remove(Query QueryIn) =>
            _queries.DeleteOne(Query => Query.oid == QueryIn.oid);

        public void Remove(string id) =>
            _queries.DeleteOne(Query => Query.oid == id);
    }
}
