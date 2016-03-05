﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MorseCoder.PCL.Interfaces;
using MorseCoder.PCL;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MorseCoder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AlphabetToMorseController : Controller
    {        
        [FromServices]
        public ITranslator _translator { get; set; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/input
        [HttpGet("{input}")]
        public string Get(string input)
        {
            return _translator.Translate(input);
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
