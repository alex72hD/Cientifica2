using Cientifica.API.Data;
using Cientifica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cientifica.API.Controllers
{


    [ApiController]
    [Route("/api/actividadesdeinvestigacion")]
    public class ActividadesDeInvestigacionesController:ControllerBase
    {
        private readonly DataContext _context;

        public ActividadesDeInvestigacionesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.ActividadesDeInvestigaciones.ToListAsync());


        }

        [HttpPost]
        public async Task<ActionResult> Post(ActividadesDeInvestigacion actividadesDeInvestigacion)
        {
            _context.Add(actividadesDeInvestigacion);
            await _context.SaveChangesAsync();
            return Ok(actividadesDeInvestigacion);
        }


        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var actividad = await _context.ActividadesDeInvestigaciones.FirstOrDefaultAsync(x => x.Id == id);

            if (actividad == null)
            {
                return NotFound();

            }

            return Ok(actividad);


        }

        [HttpPut]
        public async Task<ActionResult> Putt(ActividadesDeInvestigacion actividadesDeInvestigacion)
        {
            _context.Update(actividadesDeInvestigacion);
            await _context.SaveChangesAsync();
            return Ok(actividadesDeInvestigacion);
        }

        [HttpDelete("id:int")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.ActividadesDeInvestigaciones.Where(x=>x.Id==id).ExecuteDeleteAsync();

            if (filasafectadas == 0)
            {
                return NotFound();

            }

            return NoContent();


        }

    }
}
