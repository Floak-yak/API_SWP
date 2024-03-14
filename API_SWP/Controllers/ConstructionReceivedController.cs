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
    public class ConstructionReceivedController : Controller
    {
        private readonly IConstructionReceivedRepository _constructionReceivedRepository;
        private readonly IMapper _mapper;
        private readonly IConstructionPriceQuotationRepository _constructionPriceQuotation;

        public ConstructionReceivedController(IConstructionReceivedRepository constructionReceivedRepository, IMapper mapper, IConstructionPriceQuotationRepository constructionPriceQuotationRepository)
        {
            _constructionReceivedRepository = constructionReceivedRepository;
            _mapper = mapper;
            _constructionPriceQuotation = constructionPriceQuotationRepository;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ConstructionReceived>))]
        public IActionResult GetConstructionReceiveds()
        {
            var ConstructionReceived = _mapper.Map<List<ConstructionReceivedDto>>(_constructionReceivedRepository.GetConstructionReceiveds());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ConstructionReceived);
        }
        [HttpGet("GetAConstructionReceivedById")]
        [ProducesResponseType(200, Type = typeof(ConstructionReceived))]
        [ProducesResponseType(400)]
        public IActionResult GetConstructionReceived(string constructionReceivedId)
        {
            if (!_constructionReceivedRepository.ConstructionReceivedExits(constructionReceivedId))
            {
                return NotFound();
            }
            var ConstructionReceived = _mapper.Map<List<ConstructionReceivedDto>>(_constructionReceivedRepository.ConstructionReceived(constructionReceivedId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ConstructionReceived);
        }
        [HttpDelete("ConstructionReceivedId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStaff(string ConstructionReceivedId)
        {
            if (!_constructionReceivedRepository.ConstructionReceivedExits(ConstructionReceivedId))
            {
                return NotFound();
            }

            var constructionReceivedToDelete = _constructionReceivedRepository.ConstructionReceived(ConstructionReceivedId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_constructionReceivedRepository.RemoveConstructionReceived(constructionReceivedToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting construction received");
            }

            return NoContent();
        }
        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateConstructionRecieved ([FromQuery] string quotationId, [FromBody] ConstructionReceivedDto constructionReceivedCreate)
        {
            if (constructionReceivedCreate == null) return BadRequest(ModelState);
            var ConRe = _constructionReceivedRepository.GetConstructionReceiveds().Where(p => p.QuotationId == quotationId).FirstOrDefault();
            if (ConRe != null)
            {
                ModelState.AddModelError("", "The construction received already exists");
                return StatusCode(422, ModelState);
            }

            var ConReMap = _mapper.Map<ConstructionReceived>(constructionReceivedCreate);
            ConReMap.Quotation = _constructionPriceQuotation.GetConstructionPriceQuotation(quotationId);
            if (!_constructionReceivedRepository.CreateConstructionReceived(ConReMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Created construction revecived successfully");
        }
        [HttpPut("ConstructionRecievedId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateConstructionRecieved (string constructionRecievedId, [FromBody] ConstructionReceivedUpdateModel constructionReceivedUpdate)
        {
            if (constructionReceivedUpdate == null) return BadRequest(ModelState);
            if (!_constructionReceivedRepository.ConstructionReceivedExits(constructionRecievedId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ConReMap = _mapper.Map<ConstructionReceived>(constructionReceivedUpdate);
            ConReMap.ConstructionReceivedId = constructionRecievedId;
            ConReMap.Date = _constructionReceivedRepository.ConstructionReceived(constructionRecievedId).Date;
            ConReMap.QuotationId = _constructionReceivedRepository.ConstructionReceived(constructionRecievedId).QuotationId;
            if (!_constructionReceivedRepository.UpdateConstructionReceived(ConReMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Update Successfully");
        }
    }
}
