namespace techmeet.Models
{
    public class Event{

        public Event(){
            Title = string.Empty;
            Description = string.Empty;
            Comments = new List<Comment>();
            User = new User();
        }
        public int EventId { get; set;}

        public string Title { get; set;}

        public string Description { get; set;}
        public DateTime EventDate { get; set;}
        public int UserId { get; set;}

        // navigation properties
        public User User { get; set;}
        public ICollection<Comment> Comments { get; set;}
    }
}