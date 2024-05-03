using Cientifica.API.Data;
using Cientifica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cientifica.API.Controllers
{
    [ApiController]
    [Route("/api/asignacion")]
    public class AsignacionesController:ControllerBase
    {
        private readonly DataContext _context;

        public AsignacionesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Asignaciones.ToListAsync());


        }
        [HttpPost]
        public async Task<ActionResult> Post(Asignacion asignacion )
        {
            _context.Add(asignacion);
            
            



            await _context.SaveChangesAsync();
            return Ok(asignacion);
            


        }

        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {
            var asignacion = await _context.Asignaciones.FirstOrDefaultAsync(x=>x.Id==id);

            if (asignacion == null)
            {
                return NotFound();

            }

            return Ok(asignacion);



        }


        [HttpPut]
        public async Task<ActionResult> Put(Asignacion asignacion)
        {
            _context.Update(asignacion);

            await _context.SaveChangesAsync();
            return Ok(asignacion);



        }


        [HttpDelete("id:int")]

        public async Task<ActionResult> Delete(int id)
        {
            var filasafectadas = await _context.Asignaciones.Where(x=>x.Id==id).ExecuteDeleteAsync();

            if (filasafectadas == 0)
            {
                return NotFound();

            }

            return NoContent();



        }




    }
}
