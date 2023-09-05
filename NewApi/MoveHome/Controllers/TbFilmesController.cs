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
    public class TbFilmesController : ControllerBase
    {
        private readonly FilmesDbContext _context;

        public TbFilmesController(FilmesDbContext context)
        {
            _context = context;
        }

        // GET: api/TbFilmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbFilme>>> GetTbFilmes()
        {
          if (_context.TbFilmes == null)
          {
              return NotFound();
          }
            return await _context.TbFilmes.ToListAsync();
        }

        // GET: api/TbFilmes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbFilme>> GetTbFilme(int id)
        {
          if (_context.TbFilmes == null)
          {
              return NotFound();
          }
            var tbFilme = await _context.TbFilmes.FindAsync(id);

            if (tbFilme == null)
            {
                return NotFound();
            }

            return tbFilme;
        }

        // PUT: api/TbFilmes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbFilme(int id, TbFilme tbFilme)
        {
            if (id != tbFilme.IdFilme)
            {
                return BadRequest();
            }

            _context.Entry(tbFilme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbFilmeExists(id))
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

        // POST: api/TbFilmes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbFilme>> PostTbFilme(TbFilme tbFilme)
        {
          if (_context.TbFilmes == null)
          {
              return Problem("Entity set 'FilmesDbContext.TbFilmes'  is null.");
          }
            _context.TbFilmes.Add(tbFilme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbFilme", new { id = tbFilme.IdFilme }, tbFilme);
        }

        // DELETE: api/TbFilmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbFilme(int id)
        {
            if (_context.TbFilmes == null)
            {
                return NotFound();
            }
            var tbFilme = await _context.TbFilmes.FindAsync(id);
            if (tbFilme == null)
            {
                return NotFound();
            }

            _context.TbFilmes.Remove(tbFilme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbFilmeExists(int id)
        {
            return (_context.TbFilmes?.Any(e => e.IdFilme == id)).GetValueOrDefault();
        }
    }
}
