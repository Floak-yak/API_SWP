using AutoMapper;
using API_SWP.Dto;
using API_SWP.Interface;
using API_SWP.Model;
using API_SWP.Repository;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ConstructionPriceQuotation>))]
        public IActionResult GetConstructionPriceQuotations()
        {
            var constructionPriceQuotation = _mapper.Map<List<ConstructionPriceQuotationDto>>(_constructionPriceQuotationRepository.GetConstructionPriceQuotations());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(constructionPriceQuotation);
        }
        [HttpGet("GetConstructionPriceQuotationById")]
        [ProducesResponseType(200, Type = typeof(ConstructionPriceQuotation))]
        [ProducesResponseType(400)]
        public IActionResult GetConstructionPriceQuotation(string id)
        {
            if (!_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(id))
            {
                return NotFound();
            }
            var constructionPriceQuotation = _mapper.Map<ConstructionPriceQuotationDto>(_constructionPriceQuotationRepository.GetConstructionPriceQuotation(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(constructionPriceQuotation);
        }
        [HttpGet("GetPriceById")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetHouseType(string QuotationId)
        {
            if (!_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(QuotationId))
            {
                return NotFound();
            }
            var houseType = _mapper.Map<ConstructionPriceQuotationDto>(_constructionPriceQuotationRepository.GetHouseType(QuotationId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(houseType);
        }
        [HttpGet("GetAdviseById")]
        [ProducesResponseType(200, Type = typeof(ConstructionPriceQuotation))]
        [ProducesResponseType(400)]
        public IActionResult GetAdviseById(string QuotationId)
        {
            if (!_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(QuotationId))
            {
                return NotFound();
            }
            var houseType = _mapper.Map<ConstructionPriceQuotationDto>(_constructionPriceQuotationRepository.GetAdvise(QuotationId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(houseType);
        }
        [HttpDelete("ConstructionPriceQuotatonId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStaff(string ConstructionPriceQuotatonId)
        {
            if (!_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(ConstructionPriceQuotatonId))
            {
                return NotFound();
            }

            var constructionReceivedToDelete = _constructionPriceQuotationRepository.GetConstructionPriceQuotation(ConstructionPriceQuotatonId);

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
        public IActionResult Create([FromQuery] string StaffId, [FromBody] ConstructionPriceQuotationDto ConstructionPriceQuotationCreate)
        {
            if (ConstructionPriceQuotationCreate == null) return BadRequest(ModelState);

            var Quotation = _constructionPriceQuotationRepository.GetConstructionPriceQuotations().Where(p => p.RequestId == ConstructionPriceQuotationCreate.RequestId).FirstOrDefault();

            if (Quotation != null)
            {
                ModelState.AddModelError("", "Quotation already exists");
                return StatusCode(442, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var QuotationMap = _mapper.Map<ConstructionPriceQuotation>(ConstructionPriceQuotationCreate);
            QuotationMap.Staff = _staffRepository.GetStaff(StaffId);

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
        public IActionResult UpdateConstructionRecieved(string quotationId, [FromBody] ConstructionPriceQuotationDto quotationUpdate)
        {
            if (quotationUpdate == null) return BadRequest(ModelState);
            if (quotationId != quotationUpdate.QuotationId) return BadRequest(ModelState);
            if (!_constructionPriceQuotationRepository.ConstructionPriceQuotationExist(quotationId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var quotationMap = _mapper.Map<ConstructionPriceQuotation>(quotationUpdate);

            if (!_constructionPriceQuotationRepository.UpdateCostructionPriceQuotation(quotationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Update Successfully");
        }
    }
}
