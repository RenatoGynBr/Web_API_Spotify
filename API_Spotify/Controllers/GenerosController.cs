using API_Spotify.Context;
using API_Spotify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Spotify.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GenerosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genero>> Get()
        {
            try
            {
                return _context.Generos.AsNoTracking().ToList();
                //return _context.Generos.Include(x => x.Albuns).AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Genero> Get(int id)
        {
            try
            {
                //var genero = _context.Generos.Find(id);
                var genero = _context.Generos.AsNoTracking().FirstOrDefault(x => x.GeneroId == id);
                if (genero == null)
                    return NotFound();
                return genero;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }

    }
}
