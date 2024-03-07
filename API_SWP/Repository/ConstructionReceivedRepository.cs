using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

namespace API_SWP.Repository
{
    public class ConstructionReceivedRepository : IConstructionReceivedRepository
    {
        private readonly SWPContext _context;

        public ConstructionReceivedRepository(SWPContext context)
        {
            _context = context;
        }

        public bool CreateConstructionReceived(ConstructionReceived constructionReceived)
        {
            _context.Add(constructionReceived);
            return Save();
        }

        public ICollection<ConstructionReceived> GetConstructionReceiveds()
        {
            return _context.ConstructionReceiveds.OrderBy(p => p.ConstructionReceivedId).ToList();
        }

        public bool RemoveConstructionReceived(ConstructionReceived constructionReceived)
        {
            _context.Remove(constructionReceived);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateConstructionReceived(ConstructionReceived constructionReceived)
        {
            _context.Update(constructionReceived);
            return Save();
        }

        public ConstructionReceived ConstructionReceived(string constructionId)
        {
            return _context.ConstructionReceiveds.Where(p => p.ConstructionReceivedId == constructionId).FirstOrDefault();
        }

        public bool ConstructionReceivedExits(string id)
        {
            return _context.ConstructionReceiveds.Any(p => p.ConstructionReceivedId == id);
        }
    }
}
