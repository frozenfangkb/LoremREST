using LoremREST.Models;
using LoremREST.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LoremREST.Controllers
{
    [Route("api")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly QueryService _queryService;

        public QueryController(QueryService queryService)
        {
            _queryService = queryService;
        }

        [Route("json")]
        [HttpGet]
        public ActionResult<Query> JsonPost()
        {
            var queryString = Request.QueryString.Value;

            if (queryString == "")
            {
                return BadRequest();
            }

            var parsedQueryString = HttpUtility.ParseQueryString(queryString);

            List<QuerySpec> specsList = new List<QuerySpec>();

            for (int i = 0; i < parsedQueryString.Count; i++)
            {
                specsList.Add(new QuerySpec(parsedQueryString.GetKey(i), parsedQueryString.GetValues(i)[0]));
            }

            Query theQuery = new Query(
                    sha256_hash(queryString),
                    specsList
                );

            Query savedQuery = _queryService.Create(theQuery);

            return Ok(savedQuery);
        }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
