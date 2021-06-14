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
    public class CashbacksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CashbacksController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Cashback>> Get()
        {
            try
            {
                return _context.Cashbacks.AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }

        [HttpGet("{generoId}")]
        public ActionResult<IEnumerable<Cashback>> Get(int generoId)
        {
            try
            {
                return _context.Cashbacks.AsNoTracking().Where(x => x.GeneroId == generoId).ToList();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }

        [HttpGet("{generoId}, {diaSemanaId}")]
        public ActionResult<Cashback> Get(int generoId, int diaSemanaId)
        {
            try
            {
                var result =  _context.Cashbacks.AsNoTracking().FirstOrDefault(x => x.GeneroId == generoId && x.DiaSemana == diaSemanaId);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: " + e.Message);
            }
        }
    }
}
