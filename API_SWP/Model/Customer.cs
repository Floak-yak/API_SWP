using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace API_SWP.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Requests = new HashSet<Request>();
        }

        public string CustomerSId { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public string CustomerSName { get; set; } = null!;
        public string LoginName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; }
        public string ToString()  => Password;
    }
}
