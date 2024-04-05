using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

namespace API_SWP.Repository
{
    public class UrlPathRepository : IUrlPathRepository
    {
        private readonly SWPContext _context;
        public UrlPathRepository(SWPContext context)
        {
            _context = context;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool CreateUrlPath(UrlPath urlPath)
        {
            _context.Add(urlPath);
            return Save();
        }

        public ICollection<UrlPath> GetUrlPath()
        {
            return _context.UrlPaths.ToList();
        }

        public bool RemoveUrlPath(UrlPath urlPath)
        {
            _context.Remove(urlPath);
            return Save();
        }

        public bool UrlPathExist(string id)
        {
            return _context.UrlPaths.Any(p => p.UrlId == id);
        }

        public UrlPath GetUrlById(string id)
        {
            return _context.UrlPaths.Where(p => p.UrlId == id).FirstOrDefault();
        }

        List<UrlPath> IUrlPathRepository.GetUrlPathByTitle(string title)
        {
            return _context.UrlPaths.Where(p => p.Title.Contains(title)).ToList();
        }
    }
}
