namespace Sheenam.MVC.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        public Status State { get; set; }
    }
}
