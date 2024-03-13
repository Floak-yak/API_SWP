namespace API_SWP.Dto
{
    public class CustomerRegisterDto
    {
        public string? CustomerEmail { get; set; }
        public string CustomerSName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
