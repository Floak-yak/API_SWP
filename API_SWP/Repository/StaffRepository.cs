using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

namespace API_SWP.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly SWPContext _context;

        public StaffRepository(SWPContext context)
        {
            _context = context;
        }

        public bool CreateStaff(Staff staff)
        {
            _context.Add(staff);
            return Save();
        }
        public ICollection<Staff> GetStaffs()
        {
            return _context.Staff.OrderBy(p => p.StaffSId).ToList();
        }

        public Staff GetStaff(string staffid)
        {
            return _context.Staff.Where(p => p.StaffSId == staffid).FirstOrDefault();
        }


        public bool RemoveStaff(Staff staff)
        {
            _context.Remove(staff);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool StaffExist(string staffid)
        {
            return _context.Staff.Any(p => p.StaffSId == staffid);
        }

        public bool UpdateStaff(Staff staff)
        {
            _context.Update(staff);
            return Save();
        }

        public bool CheckLoginForStaff(string staffEmail, string staffPassword)
        {
            try
            {
                var temp = _context.Staff.SingleOrDefault(p => p.StaffSEmail == staffEmail && p.StaffPassword == staffPassword);
                if (temp != null) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "");
            }
        }
    }
}
