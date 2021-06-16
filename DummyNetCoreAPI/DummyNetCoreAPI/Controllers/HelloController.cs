using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyNetCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : Controller
    {
        [HttpGet]
        public Hello Get()
        {
            var hello = new Hello();
            return hello;

        }


    }

}
