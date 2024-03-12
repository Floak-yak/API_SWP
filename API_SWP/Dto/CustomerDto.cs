namespace API_SWP.Dto
{
    public class CustomerDto
    {
        public string CustomerSId { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public string CustomerSName { get; set; } = null!;
        public string LoginName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
