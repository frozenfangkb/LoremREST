using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoremREST.Models
{
    public class QueryDatabaseSettings : IQueryDatabaseSettings
    {
        public string QueryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IQueryDatabaseSettings
    {
        string QueryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
