namespace techmeet.Models
{
    public class User
    {
        public User()
        {
            Username = string.Empty; // assign a non-null value to Username
            Email = string.Empty; // assign a non-null value to Email
            Password = string.Empty; // assign a non-null value to Password
            Events = new List<Event>(); // assign a non-null value to Events
            Comments = new List<Comment>(); // assign a non-null value to Comments
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}

        // navigation properties
        public ICollection<Event> Events { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}