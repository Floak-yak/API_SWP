using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomerById(string id);
        Customer GetCustomerByName(string name);
        Customer GetCustomerByEmail(string email);
        string Encrypt(string toEncrypt, string customerid);
        Customer CheckLoginForCustomer(string customerEmail, string password);
        bool CustomerExits(string id);
        bool CreateCustomer(Customer customer);
        bool RemoveCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool Save();
    }
}
