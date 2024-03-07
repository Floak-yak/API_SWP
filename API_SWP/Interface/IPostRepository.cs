using API_SWP.Model;

namespace API_SWP.Interface
{
    public interface IPostRepository
    {
        ICollection<Post> GetPosts();
        Post GetPost(string id);
        bool PostExits(string id);
        bool CreatePost(Post post);
        bool RemovePost(Post post);
        bool UpdatePost(Post post);
        bool Save();
    }
}
