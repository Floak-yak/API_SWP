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
    public class ComboDesignController : Controller
    {
        private readonly IHouseTypeOptionRepository _houseTypeOptionRepository;
        private readonly IComboDesignRepository _comboRepository;
        private readonly IMapper _mapper;

        public ComboDesignController(IComboDesignRepository comboRepository, IMapper mapper, IHouseTypeOptionRepository houseTypeOptionRepository)
        {
            _houseTypeOptionRepository = houseTypeOptionRepository;
            _comboRepository = comboRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllCombo")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ComboDesignModelView>))]
        public IActionResult GetCombos()
        {
            var customer = _mapper.Map<List<ComboDesignModelView>>(_comboRepository.GetComboDesigns());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }
        [HttpGet("comboId")]
        [ProducesResponseType(200, Type = typeof(ComboDesignModelView))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerById(string comboId)
        {
            if (!_comboRepository.ComboDesignExits(comboId))
            {
                return NotFound();
            }
            var combo = _mapper.Map<ComboDesignModelView>(_comboRepository.GetComboDesignById(comboId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(combo);
        }
        [HttpDelete("ComboId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCombo(string ComboId)
        {
            if (!_comboRepository.ComboDesignExits(ComboId))
            {
                return NotFound();
            }

            var comboToDelete = _comboRepository.GetComboDesignById(ComboId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            foreach (var item in _houseTypeOptionRepository.GetHouseTypeOptions())
            {
                if (item.ComboDesignId == ComboId)
                {
                    _houseTypeOptionRepository.Remove(item);
                }
            }

            if (!_comboRepository.RemoveComboDesign(comboToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting combo");
            }

            return Ok("Remove successfully");
        }
        [HttpPost("CreateCombo")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCombo([FromBody] ComboDesignModelView createCombo)
        {
            if (createCombo == null) return BadRequest(ModelState);
            var combo = _comboRepository.GetComboDesigns().Where(p => p.TypeName.Trim() == createCombo.TypeName.Trim() && p.Describe == createCombo.Describe.Trim()).FirstOrDefault();
            if (combo != null)
            {
                ModelState.AddModelError("", "This combo is already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ComboMap = _mapper.Map<ComboDesign>(createCombo);

            //do
            //{
            //    Random rnd = new();
            //    customerMap.CustomerSId = rnd.Next(1, 10000).ToString();

            //} while (_customerRepository.CustomerExits(customerMap.CustomerSId) == true);


            if (!_comboRepository.CreateComboDesign(ComboMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Create Successfully");
        }
        [HttpPut("ComboId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCombo(string comboId, [FromBody] ComboDesignModelView updateCombo)
        {
            if (updateCombo == null) return BadRequest(ModelState);
            if (!_comboRepository.ComboDesignExits(comboId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            var comboMap = _mapper.Map<ComboDesign>(updateCombo);
            comboMap.ComboId = comboId;
            if (!_comboRepository.UpdateComboDesign(comboMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Update successfully");
        }
    }
}
