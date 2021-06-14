using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Spotify.Context;
using API_Spotify.Models;

namespace API_Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaItensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendaItensController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaItem>>> GetVendaItens()
        {
            return await _context.VendaItens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaItem>> GetVendaItemById(int id)
        {
            var vendaItem = await _context.VendaItens.FindAsync(id);

            if (vendaItem == null)
            {
                return NotFound();
            }

            return vendaItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendaItem(int id, VendaItem vendaItem)
        {
            if (id != vendaItem.VendaItemId)
            {
                return BadRequest();
            }

            _context.Entry(vendaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaItemExists(id))
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
        public async Task<ActionResult<VendaItem>> PostVendaItem(VendaItem vendaItem)
        {
            _context.VendaItens.Add(vendaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendaItem", new { id = vendaItem.VendaItemId }, vendaItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendaItem(int id)
        {
            var vendaItem = await _context.VendaItens.FindAsync(id);
            if (vendaItem == null)
            {
                return NotFound();
            }

            _context.VendaItens.Remove(vendaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaItemExists(int id)
        {
            return _context.VendaItens.Any(e => e.VendaItemId == id);
        }
    }
}
