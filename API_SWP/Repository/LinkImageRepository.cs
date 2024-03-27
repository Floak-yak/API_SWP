using API_SWP.Data;
using API_SWP.Interface;
using API_SWP.Model;

namespace API_SWP.Repository
{
    public class LinkImageRepository : ILinkImageRepository
    {
        private readonly SWPContext _context;

        public LinkImageRepository(SWPContext context)
        {
            _context = context;
        }
        ICollection<PostImg> GetLinkImageByPostId(string PostId)
        {
            return _context.PostImgs.Where(p => p.PostId == PostId).OrderBy(p => p.PostId).ToList();
        }

        ICollection<PostImg> ILinkImageRepository.GetLinkImageByPostId(string PostId)
        {
            throw new NotImplementedException();
        }

        ICollection<PostImg> ILinkImageRepository.GetLinkImages()
        {
            throw new NotImplementedException();
        }
    }
}
