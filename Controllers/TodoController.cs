using Microsoft.AspNetCore.Mvc;
using PocCrud.Models;

namespace PocCrud.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("todos")]
        public List<Todo> Get()
        {
            return new List<Todo>();
        }

    }
}