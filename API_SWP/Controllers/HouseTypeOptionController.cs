using API_SWP.Dto;
using API_SWP.Interface;
using API_SWP.Model;
using API_SWP.Repository;
using API_SWP.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_SWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseTypeOptionController : Controller
    {
        private readonly IHouseTypeOptionRepository _houseTypeOptionRepository;
        private readonly IMapper _mapper;

        public HouseTypeOptionController(IHouseTypeOptionRepository houseTypeOptionRepository, IMapper mapper)
        {
            _houseTypeOptionRepository = houseTypeOptionRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllHouseTypeOption")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HouseTypeOptionDto>))]
        public IActionResult GetOptions()
        {
            var option = _mapper.Map<List<HouseTypeOptionDto>>(_houseTypeOptionRepository.GetHouseTypeOptions());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(option);
        }
        [HttpGet("OptionId")]
        [ProducesResponseType(200, Type = typeof(HouseTypeOptionDto))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerById(string optionId)
        {
            if (!_houseTypeOptionRepository.Exist(optionId))
            {
                return NotFound();
            }
            var option = _mapper.Map<HouseTypeOptionDto>(_houseTypeOptionRepository.GetHouseTypeOptionById(optionId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(option);
        }
        [HttpDelete("OptionId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOption(string optionId)
        {
            if (!_houseTypeOptionRepository.Exist(optionId))
            {
                return NotFound();
            }

            var optionToDelete = _houseTypeOptionRepository.GetHouseTypeOptionById(optionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_houseTypeOptionRepository.Remove(optionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting option");
            }

            return NoContent();
        }
        [HttpPost("CreateOption")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOption([FromBody] HouseTypeOptionDto createOption)
        {
            if (createOption == null) return BadRequest(ModelState);
            var option = _houseTypeOptionRepository.GetHouseTypeOptions().Where(p => p.houseType.Trim() == createOption.houseType.Trim()).FirstOrDefault();
            if (option != null)
            {
                ModelState.AddModelError("", "This option is already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var optionMap = _mapper.Map<HouseTypeOption>(createOption);

            //do
            //{
            //    Random rnd = new();
            //    customerMap.CustomerSId = rnd.Next(1, 10000).ToString();

            //} while (_customerRepository.CustomerExits(customerMap.CustomerSId) == true);


            if (!_houseTypeOptionRepository.Create(optionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Create Successfully");
        }
        [HttpPut("OptionId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOption(string OptionId, [FromBody] HouseTypeOptionDto updateOption)
        {
            if (updateOption == null) return BadRequest(ModelState);
            if (!_houseTypeOptionRepository.Exist(OptionId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            var optionMap = _mapper.Map<HouseTypeOption>(updateOption);
            optionMap.houseTypeId = OptionId;
            if (!_houseTypeOptionRepository.Update(optionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Update successfully");
        }
    }
}
