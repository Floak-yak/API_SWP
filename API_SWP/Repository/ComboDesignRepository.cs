using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;
using Microsoft.EntityFrameworkCore;

namespace API_SWP.Repository
{
    public class ComboDesignRepository : IComboDesignRepository
    {
        private readonly SWPContext _context;

        public ComboDesignRepository(SWPContext context)
        {
            _context = context;
        }
        public bool ComboDesignExits(string id)
        {
            return _context.ComboDesigns.Any(p => p.ComboId == id);
        }

        public bool CreateComboDesign(ComboDesign comboDesign)
        {
            _context.Add(comboDesign);
            return Save();
        }

        public List<ComboDesign> GetComboDesigns()
        {
            return _context.ComboDesigns.ToList();
        }

        public ComboDesign GetComboDesignById(string id)
        {
            return _context.ComboDesigns.Where(p => p.ComboId == id).SingleOrDefault();
        }

        public bool RemoveComboDesign(ComboDesign comboDesign)
        {
            _context.Remove(comboDesign);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateComboDesign(ComboDesign comboDesign)
        {
            _context.Update(comboDesign);
            return Save();
        }
    }
}
