using juridical_api.Contracts;
using juridical_api.DTO;
using juridical_api.Models.Entities;
using juridical_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace juridical_api.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IRepository<ClientsEntities, ClientsDto> clientsRepository;

        public ClientsController(IRepository<ClientsEntities, ClientsDto> clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                return Ok(clientsRepository.GetAll());
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
                var client = clientsRepository.Get(id);
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
        public IActionResult Create(ClientsEntities client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                clientsRepository.Create(client);

                return CreatedAtAction(nameof(Get), new { id = client!.Id }, client);
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
                clientsRepository.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ClientsEntities client) 
        {
            try
            {
                if(id != client.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                clientsRepository.Update(id, client);
                return NoContent();
            }
            catch( Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }
    }
}
