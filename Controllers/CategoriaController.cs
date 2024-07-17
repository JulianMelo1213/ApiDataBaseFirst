using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstApi.DTO.Categoria;

namespace DatabaseFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ApiDataBaseFirtsContext _context;
        private readonly IMapper _mapper;

        public CategoriasController(ApiDataBaseFirtsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoriaDTO>>> GetCategorias()
        {
            var categorias = await _context.Categorias.ToListAsync();
            var categoriasDTO = _mapper.Map<List<GetCategoriaDTO>>(categorias);
            return Ok(categoriasDTO);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoriaDTO>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDTO = _mapper.Map<GetCategoriaDTO>(categoria);
            return Ok(categoriaDTO);
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult> PostCategoria(InsertCategoriaDTO insertCategoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(insertCategoriaDTO);
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria.IdCategoria);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, PutCategoriaDTO putCategoriaDTO)
        {
            if (id != putCategoriaDTO.IdCategoria)
            {
                return BadRequest();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _mapper.Map(putCategoriaDTO, categoria);
            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.IdCategoria == id);
        }
    }
}
