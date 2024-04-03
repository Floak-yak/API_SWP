using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IAdminRepository
    {
        ICollection<Admin> GetAdmins();
        List<Admin> GetAdminByName(string adminMail);
        Admin GetAdmin(string id);
        bool CheckLoginForAdminB(string adminMail, string adminPassword);
        Admin CheckLoginForAdmin(string adminMail, string adminPassword);
        Admin GetAdminByEmail(string email);
        bool CreateAdmin (Admin admin);
        bool AdminExits(string id);
        bool UpdateAdmin(Admin admin);
        bool Save();
    }
}
