using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

namespace API_SWP.Repository
{
    public class HouseTypeOptionRepository : IHouseTypeOptionRepository
    {
        private readonly SWPContext _context;

        public HouseTypeOptionRepository(SWPContext SWPContext)
        {
            _context = SWPContext;
        }
        public bool Create(HouseTypeOption houseTypeOption)
        {
            _context.Add(houseTypeOption);
            return Save();
        }

        public bool Exist(string id)
        {
            return _context.HouseTypeOptions.Any(p => p.houseTypeId == id);
        }

        public HouseTypeOption GetHouseTypeOptionById(string id)
        {
            return _context.HouseTypeOptions.Where(p => p.houseTypeId == id).SingleOrDefault();
        }

        public List<HouseTypeOption> GetHouseTypeOptions()
        {
            return _context.HouseTypeOptions.ToList();
        }

        public bool Remove(HouseTypeOption houseTypeOption)
        {
            _context.Remove(houseTypeOption);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(HouseTypeOption houseTypeOption)
        {
            _context.Update(houseTypeOption);
            return Save();
        }
    }
}
