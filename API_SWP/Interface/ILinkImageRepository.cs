using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface ILinkImageRepository
    {
        ICollection<PostImg> GetLinkImages();
        ICollection<PostImg> GetLinkImageByPostId(string PostId);
    }
}
