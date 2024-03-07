using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IStaffRepository
    {
        ICollection<Staff> GetStaffs();
        Staff GetStaff(string staffid);
        bool CheckLoginForStaff(string staffEmail, string staffPassword);
        bool StaffExist(string staffid);
        bool CreateStaff(Staff staff);
        bool RemoveStaff(Staff staff);
        bool UpdateStaff(Staff staff);
        bool Save();
    }
}
