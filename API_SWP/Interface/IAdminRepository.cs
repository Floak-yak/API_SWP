using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IAdminRepository
    {
        ICollection<Admin> GetAdmins();
        Admin GetAdmin(string id);
        Admin CheckLoginForAdmin(string adminMail, string adminPassword);
        bool CreateAdmin (Admin admin);
        bool AdminExits(string id);
        bool UpdateAdmin(Admin admin);
        bool Save();
    }
}
