using juridical_api.Contracts;
using juridical_api.DTO;
using juridical_api.Models.Entities;
using juridical_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace juridical_api.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IRepository<DocumentsEntities, DocumentsDto> documentsRepository;

        public DocumentsController(IRepository<DocumentsEntities, DocumentsDto> documentsRepository)
        {
            this.documentsRepository = documentsRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(documentsRepository.GetAll());
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
                var documents = documentsRepository.Get(id);
                if (documents == null)
                {
                    return NotFound();
                }
                return Ok(documents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create(DocumentsEntities document)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                documentsRepository.Create(document);

                return CreatedAtAction(nameof(Get), new { id = document!.Id }, document);
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
                documentsRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DocumentsEntities document)
        {
            try
            {
                if (id != document.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                documentsRepository.Update(id, document);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }
    }
}
