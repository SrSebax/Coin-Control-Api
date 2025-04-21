using CoinControl.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoinControl.Api.Data;
using CoinControl.Api.Dtos;

namespace CoinControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CoinControlDbContext _context;

        public CategoriaController(CoinControlDbContext context)
        {
            _context = context;
        }

        // GET: api/Categoria?uid=xxx
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias([FromQuery] string uid)
        {
            if (string.IsNullOrEmpty(uid))
                return BadRequest("Falta el UID del usuario.");

            // Filtra por UID
            return await _context.Categorias
                .Where(c => c.Uid == uid)
                .ToListAsync();
        }

        // GET: api/Categoria/{uid}/{id}
        [HttpGet("{uid}/{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(string uid, int id)
        {
            // Buscar la categoría por UID e ID
            var categoria = await _context.Categorias
                .Where(c => c.Uid == uid && c.Id == id)
                .FirstOrDefaultAsync();

            if (categoria == null)
                return NotFound();

            return categoria;
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(CategoriaCreateDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Uid == dto.Uid);
            if (user == null)
                return NotFound("El usuario no existe.");

            var categoria = new Categoria
            {
                Uid = dto.Uid,
                Nombre = dto.Nombre,
                Tipo = dto.Tipo,
                GastoProgramado = dto.GastoProgramado,
                Icono = dto.Icono,
                Color = dto.Color,
                Frecuencia = dto.Frecuencia,
                User = user
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoria), new { uid = categoria.Uid, id = categoria.Id }, categoria);
        }

        // PUT: api/Categoria/{uid}/{id}
        [HttpPut("{uid}/{id}")]
        public async Task<IActionResult> PutCategoria(string uid, int id, Categoria categoria)
        {
            if (id != categoria.Id || uid != categoria.Uid)
                return BadRequest("El ID o el UID no coinciden.");

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(uid, id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Categoria/{uid}/{id}
        [HttpDelete("{uid}/{id}")]
        public async Task<IActionResult> DeleteCategoria(string uid, int id)
        {
            var categoria = await _context.Categorias
                .Where(c => c.Uid == uid && c.Id == id)
                .FirstOrDefaultAsync();

            if (categoria == null)
                return NotFound();

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(string uid, int id)
        {
            return _context.Categorias
                .Any(e => e.Uid == uid && e.Id == id);
        }
    }
}
