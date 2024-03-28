using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IUrlPathRepository
    {
        ICollection<UrlPath> GetUrlPath();
        UrlPath GetUrlById(string id);
        bool UrlPathExist(string id);
        bool CreateUrlPath(UrlPath urlPath);
        bool RemoveUrlPath(UrlPath urlPath);
        List<UrlPath> GetUrlPathByTitle(string title);
    }
}
