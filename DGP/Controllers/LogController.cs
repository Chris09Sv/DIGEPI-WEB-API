using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DGP.Data;

namespace DGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly DGPContext _context;

        public LogController(DGPContext context)
        {
            _context = context;
        }

        // GET: api/Log
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laboratorios>>> GetLaboratorios()
        {
            return await _context.TLaboratorios.ToListAsync();
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Laboratorios>> GetLaboratorios(int id)
        {
            var laboratorios = await _context.TLaboratorios.FindAsync(id);

            if (laboratorios == null)
            {
                return NotFound();
            }

            return laboratorios;
        }

        // PUT: api/Log/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaboratorios(int id, Laboratorios laboratorios)
        {
            if (id != laboratorios.Id)
            {
                return BadRequest();
            }

            _context.Entry(laboratorios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaboratoriosExists(id))
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

        // POST: api/Log
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Laboratorios>> PostLaboratorios(Laboratorios laboratorios)
        {
            _context.TLaboratorios.Add(laboratorios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLaboratorios", new { id = laboratorios.Id }, laboratorios);
        }

        // DELETE: api/Log/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Laboratorios>> DeleteLaboratorios(int id)
        {
            var laboratorios = await _context.TLaboratorios.FindAsync(id);
            if (laboratorios == null)
            {
                return NotFound();
            }

            _context.TLaboratorios.Remove(laboratorios);
            await _context.SaveChangesAsync();

            return laboratorios;
        }

        private bool LaboratoriosExists(int id)
        {
            return _context.TLaboratorios.Any(e => e.Id == id);
        }
    }
}
