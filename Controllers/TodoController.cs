using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocCrud.Data;
using PocCrud.Models;

namespace PocCrud.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAllAsync([FromServices]AppDbContext context)
        {
            var todos = await context.Todos.AsNoTracking().ToListAsync();
            return Ok(todos);
        }

        [HttpGet]
        [Route("todos/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices]AppDbContext context,
                                                 [FromRoute]int id)
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(todo);
        }

        // [HttpPut]
        // [Route("todos/{id}")]
        // public async Task<IActionResult> UpdateAsync([FromServices]AppDbContext context,
        //                                              [FromRoute]int id, 
        //                                              [FromBody]Todo todo)
        // {
        //     context.Todos.Update(todo);
        //     await context.Todos.SaveChangesAsync();
        // }

        [HttpPost]
        [Route("todos")]
        public async Task<IActionResult> PostAsync ([FromServices]AppDbContext context,
                           [FromBody]Todo todo)
        {
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpDelete]
        [Route("todos/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context,
                                         [FromRoute]int id)
        {
            var todo = await context.Todos.FirstAsync(x => x.Id == id);
            context.Todos.Remove(todo);
            await context.SaveChangesAsync();
            return Ok(todo);
        }

    }
}