using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMongoDbTest.Data;
using NetMongoDbTest.Models;

namespace NetMongoDbTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<List<Customer>> GetAll()
        {
            return await _service.GetAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<Customer> GetById(Guid id)
        {
            var cus = await _service.GetAsyncById(id);

            if (cus == null)
                return null;

            return cus;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerDTO dto)
        {
            var cus = new Customer
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Detail = dto.Detail
            };

            await _service.CreateAsync(cus);
            return CreatedAtAction(nameof(GetAll), new { id = cus.Id }, cus);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Guid id, CustomerDTO cusDto)
        {
            var customerToUpdate = await _service.GetAsyncById(id);

            if (customerToUpdate == null)
                return NotFound();

            var customer = new Customer
            {
                Id = id,
                Name = cusDto.Name,
                Detail = cusDto.Detail
            };

            await _service.UpdateAsync(id, customer);

            return Ok(new { message = "Successfully updated", cusDto} );
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _service.GetAsyncById(id);

            if (customer == null)
                return NotFound();

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}