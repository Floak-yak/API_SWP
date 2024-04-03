namespace API_SWP.Model
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
