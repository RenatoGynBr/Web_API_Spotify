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
    public class VendasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public VendasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Venda>> Get()
        {
            try
            {
                return _context.Vendas.AsNoTracking().ToList();
                //return _context.Vendas.Include(x => x.VendaItens).AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Venda> Get(int id)
        {
            try
            {
                //var entity = _context.Vendas.Find(id);
                var entity = _context.Vendas
                    .Include(x => x.VendaItens)
                    .ThenInclude(y => y.Album)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.VendaId == id);
                if (entity == null)
                    return NotFound();
                return entity;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }
    }
}
