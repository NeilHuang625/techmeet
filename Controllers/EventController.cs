using Microsoft.AspNetCore.Mvc;
using techmeet.Models;
using techmeet.Repositories;

namespace techmeet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _eventRepository.GetAllEventsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var evt = await _eventRepository.GetEventByIdAsync(id);
            if (evt == null)
            {
                return NotFound();
            }
            return evt;
        }

        public class EventFormData
        {
            public IFormFile? File { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Location { get; set; }
            public string MaxParticipants { get; set; }
            public string UserId { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent([FromForm] EventFormData formData)
        {
            var evt = new Event
            {
                Title = formData.Title,
                Description = formData.Description,
                StartTime = formData.StartTime,
                EndTime = formData.EndTime,
                Location = formData.Location,
                MaxParticipants = formData.MaxParticipants,
                UserId = formData.UserId
            };

            await _eventRepository.AddEventAsync(evt, formData.File);
            return CreatedAtAction(nameof(GetEvent), new { id = evt.EventId }, evt);
        }

        public class UpdateEventFormData
        {
            public int EventId { get; set; }
            public IFormFile? File { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Location { get; set; }
            public string MaxParticipants { get; set; }
            public string UserId { get; set; }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, [FromForm] UpdateEventFormData formData)
        {
            if (id != formData.EventId)
            {
                return BadRequest();
            }

            var evt = new Event
            {
                EventId = id,
                Title = formData.Title,
                Description = formData.Description,
                StartTime = formData.StartTime,
                EndTime = formData.EndTime,
                Location = formData.Location,
                MaxParticipants = formData.MaxParticipants,
                UserId = formData.UserId
            };

            await _eventRepository.UpdateEventAsync(evt, formData.File);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var evt = await _eventRepository.GetEventByIdAsync(id);
            if (evt == null)
            {
                return NotFound();
            }

            await _eventRepository.DeleteEventAsync(id);
            return NoContent();
        }
    }
}