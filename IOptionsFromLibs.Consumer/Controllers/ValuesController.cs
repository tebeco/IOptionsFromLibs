using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOptionsFromLibs.Lib.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IOptionsFromLibs.Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOptions<ModuleAOptions> _moduleAOptions;

        public ValuesController(IOptions<ModuleAOptions> moduleAOptions)
        {
            _moduleAOptions = moduleAOptions;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject(_moduleAOptions.Value));
        }
    }
}
