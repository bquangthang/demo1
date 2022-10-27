using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demo1.Models;

namespace demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly DemoContext _context;

        public ApartmentsController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Apartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> Getapartments()
        {
            return await _context.apartments.Include(b => b.users).ToListAsync();
        }

        // GET: api/Apartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetApartment(long id)
        {
            var apartment = await _context.apartments.FindAsync(id);

            if (apartment == null)
            {
                return NotFound();
            }

            return apartment;
        }

        //// PUT: api/Apartments/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutApartment(long id, Apartment apartment)
        //{
        //    if (id != apartment.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(apartment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ApartmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // patch: api/Apartments/5
        // change apartment's name only
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchApartment(int id, Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return BadRequest();
            }

            var target = await _context.apartments.FindAsync(id);
            target.Name = apartment.Name;
            _context.Entry(target).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(id))
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

        // POST: api/Apartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apartment>> PostApartment(Apartment apartment)
        {
            _context.apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartment", new { id = apartment.Id }, apartment);
        }

        //// DELETE: api/Apartments/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteApartment(long id)
        //{
        //    var apartment = await _context.apartments.FindAsync(id);
        //    if (apartment == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.apartments.Remove(apartment);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ApartmentExists(long id)
        {
            return _context.apartments.Any(e => e.Id == id);
        }
    }
}
