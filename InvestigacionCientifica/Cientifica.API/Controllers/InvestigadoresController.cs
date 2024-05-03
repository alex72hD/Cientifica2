using Cientifica.API.Data;
using Cientifica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cientifica.API.Controllers
{
    [ApiController]
    [Route("/api/investigadores")]
    public class InvestigadoresController : ControllerBase
    {
        private readonly DataContext _Context;
        public InvestigadoresController(DataContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult>get()
        {
            return Ok(await _Context.Investigadores.ToListAsync());

        }
        [HttpPost]
        public async Task<ActionResult> Post(Investigador investigador)
        {
            _Context.Add(investigador);
            await _Context.SaveChangesAsync();  
            return Ok(investigador);
        }
        [HttpGet("int:id")]
        public async Task<ActionResult>get(int id)
        {
            var investigador = await _Context.Investigadores.FirstOrDefaultAsync(x=> x.Id==id);
            if (investigador == null) 
            { 
                return NotFound();
            
            }
              return Ok(investigador);
        }
        [HttpPut]
        public async Task<ActionResult> put(Investigador investigador)
        {
            _Context.Update(investigador);
            await _Context.SaveChangesAsync();
            return Ok(investigador);

        }
        [HttpDelete("id:int")]
        public async Task<ActionResult>Delete(int id)
        {
            var fila = await _Context.Investigadores.Where( x=> x.Id == id ).ExecuteDeleteAsync();    
            if (fila == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
       
    }
}
