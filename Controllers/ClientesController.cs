using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstApi.DTO.Cliente;

namespace DatabaseFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApiDataBaseFirtsContext _context;
        private readonly IMapper _mapper;

        public ClientesController(ApiDataBaseFirtsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClienteDTO>>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            var clientesDTO = _mapper.Map<List<GetClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetClienteDTO>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDTO = _mapper.Map<GetClienteDTO>(cliente);
            return Ok(clienteDTO);
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult> PostCliente(InsertClienteDTO insertClienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(insertClienteDTO);
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return Ok(cliente.IdCliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, PutClienteDTO putClienteDTO)
        {
            if (id != putClienteDTO.IdCliente)
            {
                return BadRequest();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _mapper.Map(putClienteDTO, cliente);
            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
