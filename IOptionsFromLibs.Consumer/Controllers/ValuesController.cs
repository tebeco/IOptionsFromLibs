using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using IOptionsFromLibs.Lib.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IOptionsFromLibs.Consumer.Controllers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //  WON'T BE USE UNLESS YOU CHANGE STARTUP.Configure
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
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
            return Ok(JsonSerializer.Serialize(_moduleAOptions.Value));
        }
    }
}
