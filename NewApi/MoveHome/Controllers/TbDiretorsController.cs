using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveHome.DataContext;
using MoveHome.Model;

namespace MoveHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbDiretorsController : ControllerBase
    {
        private readonly FilmesDbContext _context;

        public TbDiretorsController(FilmesDbContext context)
        {
            _context = context;
        }

        // GET: api/TbDiretors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDiretor>>> GetTbDiretors()
        {
          if (_context.TbDiretors == null)
          {
              return NotFound();
          }
            return await _context.TbDiretors.ToListAsync();
        }

        // GET: api/TbDiretors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDiretor>> GetTbDiretor(int id)
        {
          if (_context.TbDiretors == null)
          {
              return NotFound();
          }
            var tbDiretor = await _context.TbDiretors.FindAsync(id);

            if (tbDiretor == null)
            {
                return NotFound();
            }

            return tbDiretor;
        }

        // PUT: api/TbDiretors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDiretor(int id, TbDiretor tbDiretor)
        {
            if (id != tbDiretor.IdDiretor)
            {
                return BadRequest();
            }

            _context.Entry(tbDiretor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDiretorExists(id))
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

        // POST: api/TbDiretors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbDiretor>> PostTbDiretor(TbDiretor tbDiretor)
        {
          if (_context.TbDiretors == null)
          {
              return Problem("Entity set 'FilmesDbContext.TbDiretors'  is null.");
          }
            _context.TbDiretors.Add(tbDiretor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDiretor", new { id = tbDiretor.IdDiretor }, tbDiretor);
        }

        // DELETE: api/TbDiretors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDiretor(int id)
        {
            if (_context.TbDiretors == null)
            {
                return NotFound();
            }
            var tbDiretor = await _context.TbDiretors.FindAsync(id);
            if (tbDiretor == null)
            {
                return NotFound();
            }

            _context.TbDiretors.Remove(tbDiretor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDiretorExists(int id)
        {
            return (_context.TbDiretors?.Any(e => e.IdDiretor == id)).GetValueOrDefault();
        }
    }
}
