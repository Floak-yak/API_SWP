using AutoMapper;
using API_SWP.Dto;
using API_SWP.Interface;
using API_SWP.Model;
using API_SWP.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_SWP.ViewModel;

namespace API_SWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionPriceQuotationController : Controller
    {
        private readonly IConstructionPriceQuotationRepository _constructionPriceQuotationRepository;
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly IStaffRepository _staffRepository;

        public ConstructionPriceQuotationController(IConstructionPriceQuotationRepository constructionPriceQuotationRepository, IMapper mapper, IRequestRepository requestRepository, IStaffRepository staffRepository)
        {
            _constructionPriceQuotationRepository = constructionPriceQuotationRepository;
            _mapper = mapper;
            _requestRepository = requestRepository;
            _staffRepository = staffRepository;
        }
        [HttpGet("GetAllQuotation")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ConstructionPriceQuotationDto>))]
        public IActionResult GetConstructionPriceQuotations()
        {
            var constructionPriceQuotation = _mapper.Map<List<ConstructionPriceQuotationDto>>(_constructionPriceQuotationRepository.GetConstructionPriceQuotations());

            List<RequestDto> request = _mapper.Map<List<RequestDto>>(_requestRepository.GetRequests());

            foreach (var item in constructionPriceQuotation)
            {
                foreach (var req in request)
                {
                    if (item.QuotationId.Equals(req.QuotationId))
                    {
                        item.Requests.Add(req);
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(constructionPriceQuotation);
        }
        [HttpGet("GetConstructionPriceQuotationById")]
        [ProducesResponseType(200, Type = typeof(ConstructionPriceQuotationDto))]
        [ProducesResponseType(400)]
        public IActionResult GetConstructionPriceQuotation(string id)
        {
            if (!_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(id))
            {
                return NotFound();
            }

            var constructionPriceQuotation = _mapper.Map<ConstructionPriceQuotationDto>(_constructionPriceQuotationRepository.GetConstructionPriceQuotation(id));

            List<RequestDto> request = _mapper.Map<List<RequestDto>>(_requestRepository.GetRequests());
            foreach (var req in request)
            {
                if (constructionPriceQuotation.QuotationId.Equals(req.QuotationId))
                {
                    constructionPriceQuotation.Requests.Add(req);
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(constructionPriceQuotation);
        }
        [HttpDelete("ConstructionPriceQuotatonId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteQuotation(string ConstructionPriceQuotatonId)
        {
            if (!_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(ConstructionPriceQuotatonId))
            {
                return NotFound();
            }

            var constructionReceivedToDelete = _constructionPriceQuotationRepository.GetConstructionPriceQuotation(ConstructionPriceQuotatonId);
            var request = _requestRepository.GetRequests();
            foreach (var req in request)
            {
                if (req.QuotationId == ConstructionPriceQuotatonId)
                {
                    _requestRepository.RemoveRequest(req);
                }
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_constructionPriceQuotationRepository.RemoveCostructionPriceQuotation(constructionReceivedToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting construction received");
            }

            return NoContent();
        }
        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] ConstructionPriceQuotationCreateModel ConstructionPriceQuotationCreate)
        {
            if (ConstructionPriceQuotationCreate == null) return BadRequest(ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var QuotationMap = _mapper.Map<ConstructionPriceQuotation>(ConstructionPriceQuotationCreate);
            QuotationMap.Staff = _staffRepository.GetStaff("1");
            QuotationMap.StaffId = "1";
            //QuotationMap.CustomerId = customerId;
            QuotationMap.Status = "Still on going";
            QuotationMap.QuotationDate = DateTime.Now;
            Random rnd = new();
            do
            {
                rnd = new();
                QuotationMap.QuotationId = rnd.Next(1, 1000000).ToString();

            } while (_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(QuotationMap.QuotationId) == true);

            var RequestMap = _mapper.Map<List<RequestDto>>(ConstructionPriceQuotationCreate.Requests);
            string currentDay = DateTime.Now.Day.ToString();
            string currentMonth = DateTime.Now.Month.ToString();
            string currentYear = DateTime.Now.Year.ToString();
            foreach (var Request in RequestMap)
            {
                Request.QuotationId = rnd.ToString();
                do
                {
                    Request.RequestId = currentDay + "." + currentMonth + "." + currentYear + ".ID." + rnd.Next(1, 1000000).ToString();

                } while (_requestRepository.RequestExists(Request.RequestId) == true);
            }
            QuotationMap.Requests = _mapper.Map<List<Request>>(RequestMap);
            if (!_constructionPriceQuotationRepository.CreateCostructionPriceQuotation(QuotationMap))
            {
                ModelState.AddModelError("", "Something went wrong when saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("QuotationId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateConstructionRecieved(string quotationId, [FromBody] ConstructionPriceQuotationUpdateModel quotationUpdate)
        {
            if (quotationUpdate == null) return BadRequest(ModelState);
            if (!_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(quotationId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var quotationMap = _mapper.Map<ConstructionPriceQuotation>(quotationUpdate);
            quotationMap.QuotationId = quotationId;
            quotationMap.StaffId = _constructionPriceQuotationRepository.GetConstructionPriceQuotation(quotationId).StaffId;
            
            if (!_constructionPriceQuotationRepository.UpdateCostructionPriceQuotation(quotationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Update Successfully");
        }
    }
}
