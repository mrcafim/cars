using Cars.Domain.Interfaces.Services;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _service;
        public CarController(ICarService carService)
        {
            _service = carService;
        }


        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _service.List();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarModel car)
        {
            if (car == null)
                return BadRequest("The car information can not be null");

            var result = await _service.Create(car);

            if (result != null)
            {
                return Created(nameof(Get), result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleted = await _service.Delete(id);

            if (deleted)
                return Ok();

            return NotFound($"Car not found with the identifier {id}");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CarModel model)
        {
            var updated = await _service.Update(id, model);

            if (updated)
                return Ok();

            return BadRequest($"Car not found with the identifier {id}");
        }

    }
}
