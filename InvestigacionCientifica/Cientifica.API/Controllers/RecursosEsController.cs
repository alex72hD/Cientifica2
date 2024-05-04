using Cientifica.API.Data;
using Cientifica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cientifica.API.Controllers
{
   [ApiController]
   [Route("/api/recursosEs")]    
   public class RecursosEsController:ControllerBase
   {
       private readonly DataContext _Context;
       public RecursosEsController(DataContext context)
       {
           _Context = context;
       }
       [HttpGet]
       public async Task<ActionResult> get()
       {
           return Ok(await _Context.RecursosEs.ToListAsync());
       }
       [HttpPost]
       public async Task<ActionResult> post(RecursosE recursosE)
       {
           _Context.Add(recursosE);
           await _Context.SaveChangesAsync();
           return Ok(recursosE);
       }
   [HttpGet("int:id")]
   public async Task<ActionResult> get(int id)
{

    var recursosE = await _Context.RecursosEs.FirstOrDefaultAsync(x => x.Id == id);

    if (recursosE == null)
    {
        return NotFound();

    }
    return Ok(recursosE);
}
[HttpPut]
public async Task<ActionResult> put(RecursosE recursosE)
{
    _Context.Update(recursosE);
    await _Context.SaveChangesAsync();
    return Ok(recursosE);

}
[HttpDelete("id:int")]
public async Task<ActionResult> Delete(int id)
{
    var fila = await _Context.RecursosEs.Where(x => x.Id == id).ExecuteDeleteAsync();

    if (fila == 0)
    {
        return NotFound();
    }
    return NoContent();
}
       
   }
}
