using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Mvc;
using MorseCoder.PCL.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MorseCoder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TranslatorController : Controller
    {
        [FromServices]
        public ITranslatorService _translatorService { get; set; }

        // GET: api/translator
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _translatorService.TranslatorKeys.ToArray();
        }

        // GET api/translator/translatorKey/input
        [HttpGet("{translatorKey}/{input}")]
        public string Get(string translatorKey, [FromUri] string input)
        {
            return _translatorService.Translate(translatorKey, input);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
