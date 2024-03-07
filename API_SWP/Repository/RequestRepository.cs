using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API_SWP.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly SWPContext _context;

        public RequestRepository(SWPContext context)
        {
            _context = context;
        }

        public bool CreateRequest(Request request)
        {
            _context.Add(request);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Request> GetRequests()
        {
            return _context.Requests.OrderBy(p => p.RequestId).ToList();
        }

        public bool RequestExists(string requestId)
        {
            return _context.Requests.Any(p => p.RequestId == requestId);
        }

        public bool RemoveRequest(Request request)
        {
            _context.Remove(request);
            return Save();
        }

        public bool UpdateRequest(Request request)
        {
            _context.Update(request);
            return Save();
        }

        public Request GetRequestById(string RequestId)
        {
            return _context.Requests.Where(p => p.RequestId == RequestId).FirstOrDefault();
        }
    }
}
