using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstApi.DTO.Factura;

namespace DatabaseFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly ApiDataBaseFirtsContext _context;
        private readonly IMapper _mapper;

        public FacturasController(ApiDataBaseFirtsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFacturaDTO>>> GetFacturas()
        {
            var facturas = await _context.Facturas.ToListAsync();
            var facturasDTO = _mapper.Map<List<GetFacturaDTO>>(facturas);
            return Ok(facturasDTO);
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetFacturaDTO>> GetFactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            var facturaDTO = _mapper.Map<GetFacturaDTO>(factura);
            return Ok(facturaDTO);
        }

        // POST: api/Facturas
        [HttpPost]
        public async Task<ActionResult> PostFactura(InsertFacturaDTO insertFacturaDTO)
        {
            var factura = _mapper.Map<Factura>(insertFacturaDTO);
            await _context.Facturas.AddAsync(factura);
            await _context.SaveChangesAsync();

            return Ok(factura.IdFactura);
        }

        // PUT: api/Facturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, PutFacturaDTO putFacturaDTO)
        {
            if (id != putFacturaDTO.IdFactura)
            {
                return BadRequest();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _mapper.Map(putFacturaDTO, factura);
            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.IdFactura == id);
        }
    }
}
