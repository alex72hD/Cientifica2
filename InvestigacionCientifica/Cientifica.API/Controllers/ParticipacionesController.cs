using Cientifica.API.Data;
using Cientifica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cientifica.API.Controllers
{
    [ApiController]
  [Route("/api/participaciones")]
  public class ParticipacionesController : ControllerBase
  {
      private readonly DataContext _context;
      public ParticipacionesController(DataContext context)
      {
          _context = context;
      }
      [HttpGet]
      public async Task<ActionResult> get()
      {

          return Ok(await _context.Participaciones.ToListAsync());
      }
      [HttpPost]
      public async Task<ActionResult> Post(Participacion participacion)
      {
          _context.Add(participacion);
          await _context.SaveChangesAsync();
          return Ok(participacion);
      }
      [HttpGet("int:id")]
      public async Task<ActionResult> get(int id)
      {
          var participacion = await _context.Investigadores.FirstOrDefaultAsync(x => x.Id == id);
          if (participacion == null)
          {
              return NotFound();

          }
          return Ok(participacion);
      }
      [HttpPut]
      public async Task<ActionResult> put(Participacion participacion)
      {
          _context.Update(participacion);
          await _context.SaveChangesAsync();
          return Ok(participacion);

      }
      [HttpDelete("id:int")]
      public async Task<ActionResult> Delete(int id)
      {
          var fila = await _context.Participaciones.Where(x => x.Id == id).ExecuteDeleteAsync();
          if (fila == 0)
          {
              return NotFound();
          }
          return NoContent();
      }
  }
}
