using Cientifica.API.Data;
using Cientifica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cientifica.API.Controllers
{


    [ApiController]
    [Route("/api/proyectosdeinvestigacion")]
    public class ProyectosDeInvesgacionesController:ControllerBase
    {
        private readonly DataContext _context;

        public ProyectosDeInvesgacionesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.ActividadesDeInvestigaciones.ToListAsync());


        }
        [HttpPost]
        public async Task<ActionResult> Post(ProyectoDeInvestigacion proyectoDeInvestigacion)
        {
            _context.Add(proyectoDeInvestigacion);
            await _context.SaveChangesAsync();
            return Ok(proyectoDeInvestigacion);

        }



        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var proyecto = await _context.ProyectoDeInvestigaciones.FirstOrDefaultAsync(x => x.Id == id);

            if (proyecto == null) { 
         
                return NotFound();

            }

            return Ok(proyecto);


        }
        [HttpPut]
        public async Task<ActionResult> Put(ProyectoDeInvestigacion proyectoDeInvestigacion)
        {
            _context.Update(proyectoDeInvestigacion);
            await _context.SaveChangesAsync();
            return Ok(proyectoDeInvestigacion);

        }


        [HttpDelete("id:int")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.ProyectoDeInvestigaciones.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (filasafectadas == 0)
            {

                return NotFound();

            }

            return NoContent();


        }



    }




}

