using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoremREST
{
    public class QuerySpec
    {
        private string name;
        private string type;

        public QuerySpec(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
    }
}
