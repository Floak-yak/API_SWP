using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IRequestRepository
    {
        ICollection<Request> GetRequests();
        Request GetRequestById(string RequestId);
        bool RequestExists(string requestId);
        bool CreateRequest(Request request);
        bool RemoveRequest(Request request);
        bool UpdateRequest(Request request);
        bool Save ();
    }
}
