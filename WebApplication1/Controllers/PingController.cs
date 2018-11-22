using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    [Route("ping")]
    public class PingController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return $"pong {DateTime.Now}";
        }
    }
}
