using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

namespace API_SWP.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SWPContext _context;

        public CustomerRepository(SWPContext context)
        {
            _context = context;
        }

        public bool CheckLoginForCustomer(string loginName, string password)
        {
            try
            {
                var temp = _context.Customers.SingleOrDefault(p => p.LoginName == loginName && p.Password == password);
                if (temp != null) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "");
            }
        }

        public bool CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool CustomerExits(string id)
        {
            return _context.Customers.Any(p => p.CustomerSId == id);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.Where(p => p.CustomerEmail == email).FirstOrDefault();
        }

        public Customer GetCustomerById(string id)
        {
            return _context.Customers.Where(p => p.CustomerSId == id).FirstOrDefault();
        }

        public Customer GetCustomerByName(string name)
        {
            return _context.Customers.Where(p => p.CustomerSName == name).FirstOrDefault();
        }
        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(p => p.CustomerSId).ToList();
        }

        public bool RemoveCustomer(Customer customer)
        {
            _context.Remove(customer);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return Save();
        }
    }
}
