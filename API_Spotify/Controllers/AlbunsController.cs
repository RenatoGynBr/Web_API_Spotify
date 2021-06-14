using API_Spotify.Context;
using API_Spotify.Models;
using API_Spotify.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Spotify.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    public class AlbunsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AlbunsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "CatalogoAlbuns")]
        public ActionResult<IEnumerable<Album>> Get([FromQuery] PaginacaoParametros paginacaoParametros)
        {
            try
            {
                var numeroPagina = paginacaoParametros.NumeroPagina;
                var tamanhoPagina = paginacaoParametros.TamanhoPagina;
                var lista = _context.Albuns.OrderBy(x => x.Titulo);
                return lista
                    .Include(y => y.Genero)
                    .Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina)
                    .AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }

        [HttpGet("{id}", Name = "AlbumPorId")]
        public ActionResult<Album> Get(int id)
        {
            try
            {
                //var disco = _context.Discos.Find(id);
                var disco = _context.Albuns.AsNoTracking().FirstOrDefault(x => x.AlbumId == id);
                if (disco == null)
                    return NotFound();
                return disco;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }


    }
}
