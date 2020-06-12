using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterHack.Models;

namespace ShelterHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatchServicesController : ControllerBase
    {
        private readonly ShelterContext _context;

        public CatchServicesController(ShelterContext context)
        {
            _context = context;
        }

        // GET: api/CatchServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatchService>>> GetCatchServices()
        {
            return await _context.CatchServices.ToListAsync();
        }

        // GET: api/CatchServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatchService>> GetCatchService(int id)
        {
            var catchService = await _context.CatchServices.FindAsync(id);

            if (catchService == null)
            {
                return NotFound();
            }

            return catchService;
        }

        // PUT: api/CatchServices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatchService(int id, CatchService catchService)
        {
            if (id != catchService.Id)
            {
                return BadRequest();
            }

            _context.Entry(catchService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatchServiceExists(id))
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

        // POST: api/CatchServices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatchService>> PostCatchService(CatchService catchService)
        {
            _context.CatchServices.Add(catchService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatchService", new { id = catchService.Id }, catchService);
        }

        // DELETE: api/CatchServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatchService>> DeleteCatchService(int id)
        {
            var catchService = await _context.CatchServices.FindAsync(id);
            if (catchService == null)
            {
                return NotFound();
            }

            _context.CatchServices.Remove(catchService);
            await _context.SaveChangesAsync();

            return catchService;
        }

        private bool CatchServiceExists(int id)
        {
            return _context.CatchServices.Any(e => e.Id == id);
        }
    }
}
