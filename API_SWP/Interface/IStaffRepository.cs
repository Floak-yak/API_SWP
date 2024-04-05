using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IStaffRepository
    {
        List<Model.Staff> GetStaffByName(string staffName);
        ICollection<Model.Staff> GetStaffs();
        Model.Staff GetStaff(string staffid);
        bool CheckLoginForStaffB(string staffEmail, string staffPassword);
        Model.Staff CheckLoginForStaff(string staffEmail, string staffPassword);
        Model.Staff GetStaffByEmail(string staffEmail);
        bool StaffExist(string staffid);
        bool CreateStaff(Model.Staff staff);
        bool RemoveStaff(Model.Staff staff);
        bool UpdateStaff(Model.Staff staff);
        bool Save();
    }
}
