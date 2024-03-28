using AutoMapper;
using API_SWP.Dto;
using API_SWP.Interface;
using API_SWP.Model;
using API_SWP.Repository;
using Microsoft.AspNetCore.Mvc;
using API_SWP.ViewModel;

namespace API_SWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;

        public PostController(IPostRepository postRepository, IMapper mapper, IStaffRepository staffRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _staffRepository = staffRepository;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PostDto>))]
        public IActionResult GetPosts()
        {
            var post = _mapper.Map<List<PostDto>>(_postRepository.GetPosts());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(post);
        }
        [HttpGet("GetPostById")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(400)]
        public IActionResult GetPost(string PostId)
        {
            if (!_postRepository.PostExits(PostId))
            {
                return NotFound();
            }
            var post = _mapper.Map<Post>(_postRepository.GetPost(PostId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(post);
        }
        [HttpDelete("PostId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePost(string PostId)
        {
            if (!_postRepository.PostExits(PostId))
            {
                return NotFound();
            }

            var postToDelete = _postRepository.GetPost(PostId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_postRepository.RemovePost(postToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting post");
            }

            return NoContent();
        }
        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateStaff([FromQuery] string staffId,[FromBody] PostDto postCreate)
        {
            if (postCreate == null)
                return BadRequest(ModelState);

            var Posts = _postRepository.GetPosts()
                .Where(c => c.PostSId.Trim().ToUpper() == postCreate.PostSId.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (Posts != null)
            {
                ModelState.AddModelError("", "Post already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var PostMap = _mapper.Map<Post>(postCreate);
            PostMap.Staff = _staffRepository.GetStaff(staffId);
            if (!_postRepository.CreatePost(PostMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("PostId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOwner(string postId, [FromBody] PostUpdateModel updatedPost)
        {
            if (updatedPost == null)
                return BadRequest(ModelState);

            if (!_postRepository.PostExits(postId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var postMap = _mapper.Map<Post>(updatedPost);
            postMap.PostSId = postId;
            postMap.Date = _postRepository.GetPost(postId).Date;
            postMap.StaffId = _postRepository.GetPost(postId).StaffId;

            if (!_postRepository.UpdatePost(postMap))
            {
                ModelState.AddModelError("", "Something went wrong updating post");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpGet("GetPostWithImage")]
        [ProducesResponseType(200, Type = typeof(Post))]
        [ProducesResponseType(400)]
        public IActionResult getPostWithImage()
        {
            var post = _mapper.Map<List<Post>>(_postRepository.GetPosts());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(post);
        }
        [HttpGet("GetPostWithTitle")]
        [ProducesResponseType(200, Type = typeof(PostDto))]
        [ProducesResponseType(400)]
        public IActionResult getPostWithTitle(string postTitle)
        {
            var post = _mapper.Map<List<PostDto>>(_postRepository.getPostWithTitle(postTitle));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(post);
        }
    }
}
