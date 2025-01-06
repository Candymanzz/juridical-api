using juridical_api.Contracts;
using juridical_api.DTO;
using juridical_api.Models.Entities;
using juridical_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace juridical_api.Controllers
{
    [ApiController]
    [Route("api/courtHearings")]
    public class CourtHearingsController : ControllerBase
    {
        private readonly IRepository<CourtHearingsEntities, CourtHearingsDto> courtHearingsRepository;

        public CourtHearingsController(IRepository<CourtHearingsEntities, CourtHearingsDto> courtHearingsRepository)
        {
            this.courtHearingsRepository = courtHearingsRepository;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                return Ok(courtHearingsRepository.GetAll());
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
                var client = courtHearingsRepository.Get(id);
                if (client == null)
                {
                    return NotFound();
                }
                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create(CourtHearingsEntities courtHearings)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                courtHearingsRepository.Create(courtHearings);

                return CreatedAtAction(nameof(Get), new { id = courtHearings!.Id }, courtHearings);
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
                courtHearingsRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CourtHearingsEntities courtHearings)
        {
            try
            {
                if (id != courtHearings.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                courtHearingsRepository.Update(id, courtHearings);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }
    }
}
