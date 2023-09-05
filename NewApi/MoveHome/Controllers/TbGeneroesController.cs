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
    public class TbGeneroesController : ControllerBase
    {
        private readonly FilmesDbContext _context;

        public TbGeneroesController(FilmesDbContext context)
        {
            _context = context;
        }

        // GET: api/TbGeneroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGenero>>> GetTbGeneros()
        {
          if (_context.TbGeneros == null)
          {
              return NotFound();
          }
            return await _context.TbGeneros.ToListAsync();
        }

        // GET: api/TbGeneroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGenero>> GetTbGenero(int id)
        {
          if (_context.TbGeneros == null)
          {
              return NotFound();
          }
            var tbGenero = await _context.TbGeneros.FindAsync(id);

            if (tbGenero == null)
            {
                return NotFound();
            }

            return tbGenero;
        }

        // PUT: api/TbGeneroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGenero(int id, TbGenero tbGenero)
        {
            if (id != tbGenero.IdGenero)
            {
                return BadRequest();
            }

            _context.Entry(tbGenero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGeneroExists(id))
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

        // POST: api/TbGeneroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbGenero>> PostTbGenero(TbGenero tbGenero)
        {
          if (_context.TbGeneros == null)
          {
              return Problem("Entity set 'FilmesDbContext.TbGeneros'  is null.");
          }
            _context.TbGeneros.Add(tbGenero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbGenero", new { id = tbGenero.IdGenero }, tbGenero);
        }

        // DELETE: api/TbGeneroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGenero(int id)
        {
            if (_context.TbGeneros == null)
            {
                return NotFound();
            }
            var tbGenero = await _context.TbGeneros.FindAsync(id);
            if (tbGenero == null)
            {
                return NotFound();
            }

            _context.TbGeneros.Remove(tbGenero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGeneroExists(int id)
        {
            return (_context.TbGeneros?.Any(e => e.IdGenero == id)).GetValueOrDefault();
        }
    }
}
