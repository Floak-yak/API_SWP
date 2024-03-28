using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

namespace API_SWP.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly SWPContext _context;

        public PostRepository(SWPContext context)
        {
            _context = context;
        }

        public bool CreatePost(Post post)
        {
            _context.Add(post);
            return Save();
        }
        public List<Post> GetAllPostsWithImageInfo()
        {
            List<Post> posts = _context.Posts.ToList();
            return posts;
        }
        public Post GetPost(string id)
        {
            return _context.Posts.Where(p => p.PostSId == id).FirstOrDefault();
        }
        public ICollection<Post> GetPosts()
        {
            return _context.Posts.OrderBy(p => p.PostSId).ToList();
        }

        public List<Post> getPostWithTitle(string title)
        {
            return _context.Posts.Where(p => p.Title.Contains(title)).ToList();
        }

        public bool PostExits(string id)
        {
            return _context.Posts.Any(p => p.PostSId == id);
        }

        public bool RemovePost(Post post)
        {
            _context.Remove(post);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdatePost(Post post)
        {
            _context.Update(post);
            return Save();

        }
    }
}
