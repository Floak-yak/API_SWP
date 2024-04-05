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

        public bool CreateStaff(Model.Staff staff)
        {
            _context.Add(staff);
            return Save();
        }
        public ICollection<Model.Staff> GetStaffs()
        {
            return _context.Staff.OrderBy(p => p.StaffSId).ToList();
        }

        public Model.Staff GetStaff(string staffid)
        {
            return _context.Staff.Where(p => p.StaffSId == staffid).FirstOrDefault();
        }


        public bool RemoveStaff(Model.Staff staff)
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

        public bool UpdateStaff(Model.Staff staff)
        {
            _context.Update(staff);
            return Save();
        }

        public Model.Staff CheckLoginForStaff(string staffEmail, string staffPassword)
        {
                return _context.Staff.SingleOrDefault(p => p.StaffSEmail == staffEmail && p.StaffPassword == staffPassword);
        }
        public bool CheckLoginForStaffB(string staffEmail, string staffPassword)
        {
            return _context.Staff.Any(p => p.StaffSEmail == staffEmail && p.StaffPassword == staffPassword);
        }

        public List<Model.Staff> GetStaffByName(string staffName)
        {
            return _context.Staff.Where(p => p.StaffSName.Contains(staffName)).ToList();
        }

        public Model.Staff GetStaffByEmail(string staffEmail)
        {
            return _context.Staff.SingleOrDefault(p => p.StaffSEmail == staffEmail);
        }
    }
}
