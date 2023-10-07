namespace NativeTunes.API.Models.Authentication
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
