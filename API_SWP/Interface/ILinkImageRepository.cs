using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface ILinkImageRepository
    {
        ICollection<LinkImage> GetLinkImages();
        ICollection<LinkImage> GetLinkImageByPostId(string PostId);
    }
}
