namespace techmeet.Models
{
    public class Comment{

        public Comment(){
            Content = string.Empty;
            CreatedAt = System.DateTime.Now;
            User = new User();
            Event = new Event();
        }
        
        public int CommentId { get; set;}

        public string Content { get; set;}
        public DateTime CreatedAt { get; set;}
        public int UserId { get; set;}
        public int EventId { get; set;}

        // navigation propertiese
        public User User { get; set;}
        public Event Event { get; set;}
    }
}