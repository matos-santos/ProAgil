using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProAgil.API.Data;
using ProAgil.API.Model;


namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        public EventoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            } catch(Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar ao banco de dados");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id) 
        {
            try {
                var results = await _context.Eventos.FirstOrDefaultAsync(w => w.EventoId == id);

                return Ok(results);
            } catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar ao banco de dados");
            }
        }
    }
}