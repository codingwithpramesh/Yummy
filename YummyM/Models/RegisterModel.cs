namespace YummyM.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string? ProfilePicture { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string passwordConfirm { get; set; }
        public string? Role { get; set; }
    }
}
