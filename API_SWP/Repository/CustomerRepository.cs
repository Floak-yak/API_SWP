using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;

namespace API_SWP.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SWPContext _context;

        public CustomerRepository(SWPContext context)
        {
            _context = context;
        }

        public bool CheckLoginForCustomer(string email, string password)
        {
            try
            {
                var temp = _context.Customers.SingleOrDefault(p => p.CustomerEmail == email && p.Password == password);
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
        public string Encrypt(string toEncrypt, string customerid)
        {
            var a = _context.Customers.Where(p => p.CustomerSId == customerid);
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
 
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(a.ToString()));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(a.ToString());

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string Decrypt(string toDecrypt, string customerid)
        {
            var a = _context.Customers.Where(p => p.CustomerSId == customerid);
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(a.ToString()));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(a.ToString());

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
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
