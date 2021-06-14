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
        public async Task<ActionResult<IEnumerable<Venda>>> Get([FromQuery] PaginacaoParametros paginacaoParametros)
        {
            try
            {
                var numeroPagina = paginacaoParametros.NumeroPagina;
                var tamanhoPagina = paginacaoParametros.TamanhoPagina;
                var lista = _context.Vendas.OrderByDescending(x => x.DataVenda);
                return await lista
                    .Include(x => x.VendaItens)
                    .Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina)
                    .AsNoTracking().ToListAsync();
                //return _context.Vendas.Include(x => x.VendaItens).AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> Get(int id)
        {
            try
            {
                //var entity = _context.Vendas.Find(id);
                var entity = await _context.Vendas
                    .Include(x => x.VendaItens)
                    .ThenInclude(y => y.Album)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.VendaId == id);
                if (entity == null)
                    return NotFound();
                return entity;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }
        /*
        [HttpGet]
        public IEnumerable<minhaVenda> GetDetalhes()
        {
            var results = (from itens in _context.VendaItens
                           join vendas in _context.Vendas
                                on itens.VendaId equals vendas.VendaId
                           select new minhaVenda
                           {
                               VendaId = vendas.VendaId,
                               AlbumTitulo = itens.Album.Titulo,
                               Quantidade = itens.Quantidade,
                               ValorUnitario = itens.ValorUnitario,
                               NomeCliente = vendas.NomeCliente,
                               TotalAmount = vendas.TotalVenda,
                               DataVenda = vendas.DataVenda,
                               TotalCashback = vendas.TotalCashback
                           }).ToList();

            return results;
        }
        */

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, Venda venda)
        {
            if (id != venda.VendaId)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Venda>> PostVendaItem(Venda venda)
        {
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendaItem", new { id = venda.VendaId }, venda);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            var entity = await _context.Vendas.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Vendas.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool VendaExiste(int id)
        {
            return _context.Vendas.Any(e => e.VendaId == id);
        }

    }
}
