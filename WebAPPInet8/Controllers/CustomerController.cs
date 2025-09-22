using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPPInet8.Database;
using WebAPPInet8.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPPInet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = _context.Customers.ToList();
            if (result == null || result.Count == 0)
                return NotFound(new { message = "No se encontraron clientes." });
            return Ok(result);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return NotFound(new { message = "Cliente no encontrado." });
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] Customer value)
        {
            if (value == null)
                return BadRequest(new { message = "Datos inválidos." });
            _context.Customers.Add(value);
            _context.SaveChanges();
            return Created($"/api/customers/{value.Id}", value);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Put(int id, [FromBody] Customer value)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return NotFound(new { message = "Cliente no encontrado." });
            if (value == null)
                return BadRequest(new { message = "Datos inválidos." });
            customer.Name = value.Name;
            // ...actualiza otras propiedades si existen...
            _context.SaveChanges();
            return Ok(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return NotFound(new { message = "Cliente no encontrado." });
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok(new { message = "Cliente eliminado." });
        }
    }
}
