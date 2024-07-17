using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstApi.DTO.Producto;

namespace DatabaseFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApiDataBaseFirtsContext _context;
        private readonly IMapper _mapper;

        public ProductosController(ApiDataBaseFirtsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductoDTO>>> GetProductos()
        {
            var productos = await _context.Productos.ToListAsync();
            var productosDTO = _mapper.Map<List<GetProductoDTO>>(productos);
            return Ok(productosDTO);
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductoDTO>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            var productoDTO = _mapper.Map<GetProductoDTO>(producto);
            return Ok(productoDTO);
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult> PostProducto(InsertProductoDTO insertProductoDTO)
        {
            var producto = _mapper.Map<Producto>(insertProductoDTO);
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return Ok(producto.IdProducto);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, PutProductoDTO putProductoDTO)
        {
            if (id != putProductoDTO.IdProducto)
            {
                return BadRequest();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _mapper.Map(putProductoDTO, producto);
            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
