using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SolsticeAPIChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{ContactId}")]
        public ActionResult<string> Get(int ContactId)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{ContactId}")]
        public void Put(int ContactId, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{ContactId}")]
        public void Delete(int ContactId)
        {
        }
    }
}