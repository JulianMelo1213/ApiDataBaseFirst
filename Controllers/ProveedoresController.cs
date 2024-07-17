using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstApi.DTO.Proveedor;

namespace DatabaseFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ApiDataBaseFirtsContext _context;
        private readonly IMapper _mapper;

        public ProveedoresController(ApiDataBaseFirtsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProveedoreDTO>>> GetProveedores()
        {
            var proveedores = await _context.Proveedores.ToListAsync();
            var proveedoresDTO = _mapper.Map<List<GetProveedoreDTO>>(proveedores);
            return Ok(proveedoresDTO);
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProveedoreDTO>> GetProveedore(int id)
        {
            var proveedore = await _context.Proveedores.FindAsync(id);

            if (proveedore == null)
            {
                return NotFound();
            }

            var proveedoreDTO = _mapper.Map<GetProveedoreDTO>(proveedore);
            return Ok(proveedoreDTO);
        }

        // POST: api/Proveedores
        [HttpPost]
        public async Task<ActionResult> PostProveedore(InsertProveedoreDTO insertProveedoreDTO)
        {
            var proveedore = _mapper.Map<Proveedore>(insertProveedoreDTO);
            await _context.Proveedores.AddAsync(proveedore);
            await _context.SaveChangesAsync();

            return Ok(proveedore.IdProveedor);
        }

        // PUT: api/Proveedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedore(int id, PutProveedoreDTO putProveedoreDTO)
        {
            if (id != putProveedoreDTO.IdProveedor)
            {
                return BadRequest();
            }

            var proveedore = await _context.Proveedores.FindAsync(id);
            if (proveedore == null)
            {
                return NotFound();
            }

            _mapper.Map(putProveedoreDTO, proveedore);
            _context.Entry(proveedore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedoreExists(id))
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

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedore(int id)
        {
            var proveedore = await _context.Proveedores.FindAsync(id);
            if (proveedore == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedoreExists(int id)
        {
            return _context.Proveedores.Any(e => e.IdProveedor == id);
        }
    }
}
