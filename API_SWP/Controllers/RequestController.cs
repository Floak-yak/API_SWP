using AutoMapper;
using API_SWP.Dto;
using API_SWP.Interface;
using API_SWP.Model;
using API_SWP.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API_SWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public RequestController(IRequestRepository requestRepository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Request>))]
        public IActionResult GetRequests()
        {
            var request = _mapper.Map<List<RequestDto>>(_requestRepository.GetRequests());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(request);
        }
        [HttpGet("RequestId")]
        [ProducesResponseType(200, Type = typeof(Request))]
        [ProducesResponseType(400)]
        public IActionResult GetRequest(string RequestId)
        {
            if (!_requestRepository.RequestExists(RequestId))
            {
                return NotFound();
            }
            var request = _mapper.Map<RequestDto>(_requestRepository.GetRequestById(RequestId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(request);
        }
        [HttpDelete("RequestId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleterRequest(string requestId)
        {
            if (!_requestRepository.RequestExists(requestId))
            {
                return NotFound();
            }

            var requestToDelete = _requestRepository.GetRequestById(requestId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_requestRepository.RemoveRequest(requestToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting request");
            }

            return NoContent();
        }
        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromQuery] string CustomerId, [FromBody] RequestDto Request)
        {
            if (Request == null) return BadRequest(ModelState);

            var request = _requestRepository.GetRequests().Where(p => p.RequestId == Request.RequestId).FirstOrDefault();
            
            if (request != null)
            {
                ModelState.AddModelError("", "Request already exists");
                return StatusCode(442, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var RequestMap = _mapper.Map<Request>(Request);
            RequestMap.Customer = _customerRepository.GetCustomerById(CustomerId);

            if (!_requestRepository.CreateRequest(RequestMap))
            {
                ModelState.AddModelError("", "Something went wrong when saving");
                return StatusCode(500, ModelState);
            }
            
            return Ok("Successfully created");
        }

        [HttpPut("RequestId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRequest(string RequestId, [FromBody] RequestDto UpdateRequest)
        {
            if (UpdateRequest == null) return BadRequest(ModelState);
            if (RequestId != UpdateRequest.RequestId) return BadRequest(ModelState);
            if (_requestRepository.RequestExists(RequestId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            var requestMap = _mapper.Map<Request>(UpdateRequest);
            
            if (!_requestRepository.UpdateRequest(requestMap))
            {
                ModelState.AddModelError("", "Something went wrong went update.");
                return StatusCode(500, ModelState);
            }
            return Ok("Update Successfully");
        }
    }
}
