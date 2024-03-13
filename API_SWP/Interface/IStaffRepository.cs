using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IStaffRepository
    {
        List<Staff> GetStaffByName(string staffName);
        ICollection<Staff> GetStaffs();
        Staff GetStaff(string staffid);
        Staff CheckLoginForStaff(string staffEmail, string staffPassword);
        bool StaffExist(string staffid);
        bool CreateStaff(Staff staff);
        bool RemoveStaff(Staff staff);
        bool UpdateStaff(Staff staff);
        bool Save();
    }
}
