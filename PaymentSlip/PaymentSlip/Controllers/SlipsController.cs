using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSlip;
using PaymentSlip.Model;

namespace PaymentSlip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlipsController : ControllerBase
    {
        private readonly PaymentSlipContext _context;

        public SlipsController(PaymentSlipContext context)
        {
            _context = context;
        }

        // GET: api/Slips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slip>>> GetSlip()
        {
          if (_context.Slip == null)
          {
              return NotFound();
          }
            return await _context.Slip.ToListAsync();
        }

        // GET: api/Slips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slip>> GetSlip(long id)
        {
          if (_context.Slip == null)
          {
              return NotFound();
          }
            var slip = await _context.Slip.FindAsync(id);

            if (slip == null)
            {
                return NotFound();
            }

            return slip;
        }

        // PUT: api/Slips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlip(long id, Slip slip)
        {
            if (id != slip.Id)
            {
                return BadRequest();
            }

            _context.Entry(slip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlipExists(id))
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

        // POST: api/Slips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Slip>> PostSlip(Slip slip)
        {
          if (_context.Slip == null)
          {
              return Problem("Entity set 'PaymentSlipContext.Slip'  is null.");
          }
            _context.Slip.Add(slip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlip", new { id = slip.Id }, slip);
        }

        // DELETE: api/Slips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlip(long id)
        {
            if (_context.Slip == null)
            {
                return NotFound();
            }
            var slip = await _context.Slip.FindAsync(id);
            if (slip == null)
            {
                return NotFound();
            }

            _context.Slip.Remove(slip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SlipExists(long id)
        {
            return (_context.Slip?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
