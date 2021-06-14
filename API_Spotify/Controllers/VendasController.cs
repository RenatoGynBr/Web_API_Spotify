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
        public ActionResult<IEnumerable<Venda>> Get([FromQuery] PaginacaoParametros paginacaoParametros)
        {
            try
            {
                var numeroPagina = paginacaoParametros.NumeroPagina;
                var tamanhoPagina = paginacaoParametros.TamanhoPagina;
                var lista = _context.Vendas.OrderByDescending(x => x.DataVenda);
                return lista
                    .Include(x => x.VendaItens)
                    .Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina)
                    .AsNoTracking().ToList();
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


        /*
        *** REGISTRAR NOVA VENDA com CASHBACK (implementar via EF)
        *-- insert [Venda]: DataVenda, NomeCliente, TotalVenda, TotalCashback
        INSERT INTO [dbo].[Venda] VALUES ('2021-6-15', 'Edson Arantes', 100, 20);

        -- insert [VendaItem]: Quantidade, ValorUnitario, IdProduto, IdVenda
        INSERT INTO [dbo].[VendaItem] VALUES (2, 19.99, 11, 44)

        -- update TOTAL

        -- update CASHBACK
        *** Cálculo de CASHBACK (implementar via EF)
        * 
        UPDATE [dbo].[Venda] SET TotalCashback = (
        SELECT SUM(Cashback) from (
        SELECT (Quantidade*ValorUnitario)*(Percentual/100) 'Cashback' FROM [dbo].[Venda]
        LEFT JOIN [dbo].[VendaItem] ON [dbo].[VendaItem].VendaId = [dbo].[Venda].VendaId 
        LEFT JOIN [dbo].[Album] ON [dbo].[Album].AlbumId = [dbo].[VendaItem].AlbumId 
        LEFT JOIN [dbo].[Cashback] ON [dbo].[Cashback].GeneroId = [dbo].[Album].GeneroId AND DiaSemana = DATEPART(dw,[dbo].[Venda].DataVenda)
        WHERE [dbo].[Venda].VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])
        ) result
        ) WHERE VendaId = (SELECT MAX(VendaId) FROM [dbo].[Venda])
        *
        */


    }
}
