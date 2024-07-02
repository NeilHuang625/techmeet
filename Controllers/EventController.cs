using Microsoft.AspNetCore.Mvc;
using techmeet.Models;
using techmeet.Repositories;

namespace techmeet.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase{
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository){
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> GetEvents(){
            return await _eventRepository.GetAllEventsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id){
            var evt = await _eventRepository.GetEventByIdAsync(id);
            if(evt == null){
                return NotFound();
            }
            return evt;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event evt){
            await _eventRepository.AddEventAsync(evt);
            return CreatedAtAction(nameof(GetEvent), new { id = evt.EventId}, evt);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event evt){
            if(id != evt.EventId){
                return BadRequest();
            }

            await _eventRepository.UpdateEventAsync(evt);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id){
            var evt = await _eventRepository.GetEventByIdAsync(id);
            if(evt == null){
                return NotFound();
            }

            await _eventRepository.DeleteEventAsync(id);
            return NoContent();
        }
    }
}