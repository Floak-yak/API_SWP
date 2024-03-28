namespace API_SWP.ViewModel
{
    public class CustomerUpdateModel
    {
        public string? CustomerEmail { get; set; }
        public string CustomerSName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
