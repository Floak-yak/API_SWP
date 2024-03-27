using API_SWP.Dto;
using API_SWP.Interface;
using API_SWP.Model;
using API_SWP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_SWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkImageController : Controller
    {
        private readonly ILinkImageRepository _linkImageRepository;

        public LinkImageController(ILinkImageRepository linkImageRepository)
        {
            _linkImageRepository = linkImageRepository;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PostImg>))]
        public IActionResult GetPosts(string postId)
        {
            var post = _linkImageRepository.GetLinkImageByPostId(postId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(post);
        }
    }
}
