using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoremREST.Models
{
    public class Query
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string oid { get; set; }

        public string queryHash { get; set; }

        [BsonElement("queryStructure")]
        public List<QuerySpec> querySpecs { get; set; }

        public Query(string queryHash, List<QuerySpec> querySpecs)
        {
            this.queryHash = queryHash;
            this.querySpecs = querySpecs;
        }

        public Query()
        {
        }
    }
}
