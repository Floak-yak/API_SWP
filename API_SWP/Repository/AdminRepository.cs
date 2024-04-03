using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

namespace API_SWP.Repository

{
    public class AdminRepository : IAdminRepository
    {
        private readonly SWPContext _context;
        public AdminRepository(SWPContext context)
        {
            _context = context;
        }
        public bool AdminExits(string id)
        {
            return _context.Admins.Any(p => p.AdminSId == id);
        }

        public Admin CheckLoginForAdmin(string adminMail, string adminPassword)
        {
            return _context.Admins.Where(p => p.AdminSMail == adminMail && p.AdminSPassword == adminPassword).SingleOrDefault();
        }
        public bool CheckLoginForAdminB(string adminMail, string adminPassword)
        {
            return _context.Admins.Any(p => p.AdminSMail == adminMail && p.AdminSPassword == adminPassword);
        }

        public bool CreateAdmin(Admin admin)
        {
            _context.Add(admin);
            return Save();
        }

        public Admin GetAdmin(string id)
        {
            var add = _context.Admins.Where(p => p.AdminSId.Equals(id)).FirstOrDefault();
            Admin admin = new () { AdminSPassword = add.AdminSPassword, AdminSMail = add.AdminSMail };
            //return _context.Admins.Where(p => p.AdminSId.Equals(id)).FirstOrDefault();
            return admin;
        }

        public Admin GetAdminByEmail(string email)
        {
            return _context.Admins.SingleOrDefault(p => p.AdminSMail == email);
        }

        public List<Admin> GetAdminByName(string adminMail)
        {
            return _context.Admins.Where(p => p.AdminSMail.Contains(adminMail)).ToList();
        }

        public ICollection<Admin> GetAdmins()
        {
            return _context.Admins.OrderBy(p => p.AdminSId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAdmin(Admin admin)
        {
            _context.Update(admin);
            return Save();
        }
    }
}
