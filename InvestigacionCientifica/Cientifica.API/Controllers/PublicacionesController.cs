using Cientifica.API.Data;
using Cientifica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cientifica.API.Controllers
   
{
     [ApiController]
  [Route("/api/publicaciones")]
  public class PublicacionesController : ControllerBase
  {
      private readonly DataContext _Context;
      public PublicacionesController(DataContext context)
      {
          _Context = context;
      }
      [HttpGet]
      public async Task<ActionResult> get()
      {
          return Ok(await _Context.Publicaciones.ToListAsync());
      }
      [HttpPost]
      public async Task<ActionResult> post(Publicacion publicacion)
      {
          _Context.Add(publicacion);
          await _Context.SaveChangesAsync();
          return Ok(publicacion);
      }
        [HttpGet("int:id")]
public async Task<ActionResult> get(int id)
{
    var publicacion = await _Context.Publicaciones.FirstOrDefaultAsync(x => x.Id == id);
    if (publicacion == null)
    {
        return NotFound();

    }
    return Ok(publicacion);
}
[HttpPut]
public async Task<ActionResult> put(Publicacion publicacion)
{
    _Context.Update(publicacion);
    await _Context.SaveChangesAsync();
    return Ok(publicacion);

}
[HttpDelete("id:int")]
public async Task<ActionResult> Delete(int id)
{

    var fila = await _Context.Publicaciones.Where(x => x.Id == id).ExecuteDeleteAsync();

    if (fila == 0)
    {
        return NotFound();
    }
    return NoContent();
}
  } 
    
}
