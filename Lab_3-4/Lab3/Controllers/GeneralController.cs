using Lab3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly ConsultantContext _сontext;


        public GeneralController(ConsultantContext сontext)
        {
            _сontext = сontext;
        }
        //GET
        [HttpGet("GetFull")]
        public async Task<ActionResult<IEnumerable<Consultant>>> GetConsultants()
        {
            if (_сontext.Consultants == null)
            {
                return NotFound();
            }
            return await _сontext.Consultants.ToListAsync();
        }

        //GET ID
        [HttpGet("Consultant/{id}")]
        public async Task<ActionResult<Consultant>> GetConsultant(int id)
        {
            if (_сontext.Consultants == null)
            {
                return NotFound();
            }
            var consultant = await _сontext.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            return consultant;
        }
        //GET W_ID
        [HttpGet("Order/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            if (_сontext.Orders == null)
            {
                return NotFound();
            }
            var order = await _сontext.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        //POST 
        [HttpPost("Consultant")]
        public async Task<ActionResult<Consultant>> PostConsultant(Consultant consultant)
        {
            _сontext.Consultants.Add(consultant);
            await _сontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConsultant), new { id = consultant.EmployeeID }, consultant);
        }
        [HttpPost("Order")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _сontext.Orders.Add(order);
            await _сontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConsultant), new { id = order.OrderID }, order);
        }
        [HttpPut("Consultant/{id}")]
        public Task<IActionResult> PutConsultant(int id, Consultant consultant)
        {
            if (id != consultant.EmployeeID)
            {
                return Task.FromResult<IActionResult>(BadRequest());
            }
            return Task.FromResult<IActionResult>(NoContent());
        }
        [HttpPut("Order/{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("Consultant/{id}")]
        public async Task<IActionResult> DeleteConsultant(int id)
        {
            if (_сontext.Consultants == null)
            {
                return NotFound();
            }
            var consultant = await _сontext.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }

            _сontext.Consultants.Remove(consultant);
            await _сontext.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("Order/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_сontext.Orders == null)
            {
                return NotFound();
            }
            var order = await _сontext.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _сontext.Orders.Remove(order);
            await _сontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
