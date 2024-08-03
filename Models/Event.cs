using System.ComponentModel.DataAnnotations.Schema;

namespace techmeet.Models
{
    public class Event{
        public int EventId { get; set;}

        public string Title { get; set;}

        public string Description { get; set;}
        public DateTime StartTime { get; set;}

        public DateTime EndTime { get; set;}

        public string Location { get; set;}

        public string? ImagePath { get; set;}

        public string MaxParticipants { get; set;}

        [NotMapped]
        public string UserId { get; set;}
    }
}