#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetService.Models;

namespace PetService.Controllers
{
    [Route("api/VentaDetalles")]
    [ApiController]
    public class VentaDetallesController : ControllerBase
    {
        private readonly PetServiceContext _context;

        public VentaDetallesController(PetServiceContext context)
        {
            _context = context;
        }

        // GET: api/VentaDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaDetalles>>> GetVentaDetalles()
        {
            return await _context.VentaDetalles.ToListAsync();
        }

        // GET: api/VentaDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDetalles>> GetVentaDetalles(int id)
        {
            var ventaDetalles = await _context.VentaDetalles.FindAsync(id);

            if (ventaDetalles == null)
            {
                return NotFound();
            }

            return ventaDetalles;
        }

        // PUT: api/VentaDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentaDetalles(int id, VentaDetalles ventaDetalles)
        {
            if (id != ventaDetalles.IdVentaDetalle)
            {
                return BadRequest();
            }

            _context.Entry(ventaDetalles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaDetallesExists(id))
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

        // POST: api/VentaDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VentaDetalles>> PostVentaDetalles(VentaDetalles ventaDetalles)
        {
            _context.VentaDetalles.Add(ventaDetalles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentaDetalles", new { id = ventaDetalles.IdVentaDetalle }, ventaDetalles);
        }

        // DELETE: api/VentaDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentaDetalles(int id)
        {
            var ventaDetalles = await _context.VentaDetalles.FindAsync(id);
            if (ventaDetalles == null)
            {
                return NotFound();
            }

            _context.VentaDetalles.Remove(ventaDetalles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaDetallesExists(int id)
        {
            return _context.VentaDetalles.Any(e => e.IdVentaDetalle == id);
        }
    }
}
