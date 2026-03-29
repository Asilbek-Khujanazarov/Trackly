namespace Trackly.Application.DTOs.Auth
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
