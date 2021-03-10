using LoremREST.Helpers;
using LoremREST.Models;
using LoremREST.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
                    Utilities.sha256_hash(queryString),
                    specsList
                );

            Query savedQuery = _queryService.Create(theQuery);

            return Ok(savedQuery.oid);
        }
    }
}
