using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> Get()
        {
            Request.HttpContext.Response.Headers.Add("Access-Control-Request-Headers", "*");

            using (var db = new AppDb())
            {
                await db.Connection.OpenAsync();
                var query = new ArticleQuery(db);
                var result = await query.GetAll();
                return new OkObjectResult(result);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> Get(int id)
        {
            Request.HttpContext.Response.Headers.Add("Access-Control-Request-Headers", "*");

            using (var db = new AppDb())
            {
                await db.Connection.OpenAsync();
                var query = new ArticleQuery(db);
                var result = await query.GetOne(id);
                return new OkObjectResult(result);
            }
        }
    }
}

public class CustomActionFilter : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        var result = context.HttpContext.Request.Headers.Any(x => x.Key == "Authorization" && x.Value == "FT");
        if (!result)
        {
            context.HttpContext.Response.StatusCode = 403;
            throw new AccessViolationException("Mr. D. prumpaði");
        };
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}