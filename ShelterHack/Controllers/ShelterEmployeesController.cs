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
    public class ShelterEmployeesController : ControllerBase
    {
        private readonly ShelterContext _context;

        public ShelterEmployeesController(ShelterContext context)
        {
            _context = context;
        }

        // GET: api/ShelterEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelterEmployee>>> GetShelterEmployees()
        {
            return await _context.ShelterEmployees.ToListAsync();
        }

        // GET: api/ShelterEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShelterEmployee>> GetShelterEmployee(int id)
        {
            var shelterEmployee = await _context.ShelterEmployees.FindAsync(id);

            if (shelterEmployee == null)
            {
                return NotFound();
            }

            return shelterEmployee;
        }

        // PUT: api/ShelterEmployees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelterEmployee(int id, ShelterEmployee shelterEmployee)
        {
            if (id != shelterEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(shelterEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShelterEmployeeExists(id))
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

        // POST: api/ShelterEmployees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ShelterEmployee>> PostShelterEmployee(ShelterEmployee shelterEmployee)
        {
            _context.ShelterEmployees.Add(shelterEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShelterEmployee", new { id = shelterEmployee.Id }, shelterEmployee);
        }

        // DELETE: api/ShelterEmployees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShelterEmployee>> DeleteShelterEmployee(int id)
        {
            var shelterEmployee = await _context.ShelterEmployees.FindAsync(id);
            if (shelterEmployee == null)
            {
                return NotFound();
            }

            _context.ShelterEmployees.Remove(shelterEmployee);
            await _context.SaveChangesAsync();

            return shelterEmployee;
        }

        private bool ShelterEmployeeExists(int id)
        {
            return _context.ShelterEmployees.Any(e => e.Id == id);
        }
    }
}
