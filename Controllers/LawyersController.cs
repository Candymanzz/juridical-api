using juridical_api.Contracts;
using juridical_api.DTO;
using juridical_api.Models.Entities;
using juridical_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace juridical_api.Controllers
{
    [ApiController]
    [Route("api/lawyers")]
    public class LawyersController : ControllerBase
    {
        private readonly IRepository<LawyersEntities, LawyersDto> lawyersRepository;

        public LawyersController(IRepository<LawyersEntities, LawyersDto> lawyersRepository)
        {
            this.lawyersRepository = lawyersRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(lawyersRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var lawyer = lawyersRepository.Get(id);
                if (lawyer == null)
                {
                    return NotFound();
                }
                return Ok(lawyer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create(LawyersEntities lawyer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                lawyersRepository.Create(lawyer);

                return CreatedAtAction(nameof(Get), new { id = lawyer!.Id }, lawyer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                lawyersRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, LawyersEntities lawyer)
        {
            try
            {
                if (id != lawyer.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                lawyersRepository.Update(id, lawyer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }
    }
}
