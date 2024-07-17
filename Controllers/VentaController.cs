using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstApi.DTO.Venta;

namespace DatabaseFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ApiDataBaseFirtsContext _context;
        private readonly IMapper _mapper;

        public VentasController(ApiDataBaseFirtsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetVentaDTO>>> GetVentas()
        {
            var ventas = await _context.Ventas.ToListAsync();
            var ventasDTO = _mapper.Map<List<GetVentaDTO>>(ventas);
            return Ok(ventasDTO);
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetVentaDTO>> GetVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }

            var ventaDTO = _mapper.Map<GetVentaDTO>(venta);
            return Ok(ventaDTO);
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<ActionResult> PostVenta(InsertVentaDTO insertVentaDTO)
        {
            var venta = _mapper.Map<Venta>(insertVentaDTO);
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();

            return Ok(venta.IdVenta);
        }

        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, PutVentaDTO putVentaDTO)
        {
            if (id != putVentaDTO.IdVenta)
            {
                return BadRequest();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _mapper.Map(putVentaDTO, venta);
            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.IdVenta == id);
        }
    }
}
