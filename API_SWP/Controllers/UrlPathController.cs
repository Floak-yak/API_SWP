using API_SWP.Dto;
using API_SWP.Interface;
using API_SWP.Model;
using API_SWP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_SWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlPathController : Controller
    {
        private readonly IUrlPathRepository _urlPathRepository;

        public UrlPathController(IUrlPathRepository urlPathRepository)
        {
            _urlPathRepository = urlPathRepository;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UrlPath>))]
        public IActionResult GetUrls()
        {
            var path = _urlPathRepository.GetUrlPath();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(path);
        }

        [HttpGet("GetUrlByTitle")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(400)]
        public IActionResult GetUrlByTitle(string title)
        {
            var customers = _urlPathRepository.GetUrlPathByTitle(title);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customers);
        }

        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromBody] UrlPath createUrl)
        {
            if (createUrl == null) return BadRequest(ModelState);
            var url = _urlPathRepository.GetUrlPath().Where(p => p.Url.Trim() == createUrl.Url.Trim()).FirstOrDefault();

            if (url != null)
            {
                ModelState.AddModelError("", "This url is already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_urlPathRepository.CreateUrlPath(createUrl))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Create Successfully");
        }

        [HttpDelete("UrlId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUrl(string UrlId)
        {
            if (!_urlPathRepository.UrlPathExist(UrlId))
            {
                return NotFound();
            }

            var urlToDelete = _urlPathRepository.GetUrlById(UrlId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_urlPathRepository.RemoveUrlPath(urlToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting url");
            }

            return NoContent();
        }
    }
}
