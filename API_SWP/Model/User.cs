namespace API_SWP.Model
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string UserName {  get; set; } = string.Empty;
        public string ?Password { get; set; }
        public string Role { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
