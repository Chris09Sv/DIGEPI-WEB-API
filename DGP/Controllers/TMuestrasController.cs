using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DGP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace DGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TMuestrasController : ControllerBase
    {
        private readonly ILogger<TMuestrasController> _logger;

        private readonly DGPContext _context;

        public TMuestrasController(DGPContext context, ILogger<TMuestrasController> logger)
        {
            _logger = logger;

            _context = context;
        }

        // GET: api/TMuestras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TMuestras>>> GetTMuestras()
        {
            return await _context.TMuestras.ToListAsync();
        }

        // GET: api/TMuestras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TMuestras>> GetTMuestras(int id)
        {
            var userName = User.Identity.Name;
            _logger.LogInformation($"User [{userName}] is viewing values.");
            var tMuestras = await _context.TMuestras.FindAsync(id);

            if (tMuestras == null)
            {
                return NotFound();
            }

            return tMuestras;
        }

        // PUT: api/TMuestras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTMuestras(int id, TMuestras tMuestras)
        {
            if (id != tMuestras.ID)
            {
                return BadRequest();
            }

            _context.Entry(tMuestras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TMuestrasExists(id))
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

        // POST: api/TMuestras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TMuestras>> PostTMuestras(TMuestras tMuestras)
        {
            _context.TMuestras.Add(tMuestras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTMuestras", new { id = tMuestras.ID }, tMuestras);
        }

        // DELETE: api/TMuestras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TMuestras>> DeleteTMuestras(int id)
        {
            var tMuestras = await _context.TMuestras.FindAsync(id);
            if (tMuestras == null)
            {
                return NotFound();
            }

            _context.TMuestras.Remove(tMuestras);
            await _context.SaveChangesAsync();

            return tMuestras;
        }

        private bool TMuestrasExists(int id)
        {
            return _context.TMuestras.Any(e => e.ID == id);
        }
    }
}
