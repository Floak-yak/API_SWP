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
    public class StaffController : Controller
    {
        private readonly IStaffRepository _staffrepository;
        private readonly IMapper _mapper;

        public StaffController(IStaffRepository StaffRepository, IMapper mapper)
        {
            _staffrepository = StaffRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllStaff")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Staff>))]
        public IActionResult GetStaffs()
        {
            var staff = _mapper.Map<List<StaffDto>>(_staffrepository.GetStaffs());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(staff);
        }
        [HttpGet("GetStaffById")]
        [ProducesResponseType(200, Type = typeof(Staff))]
        [ProducesResponseType(400)]
        public IActionResult GetStaff(string StaffId)
        {
            if(!_staffrepository.StaffExist(StaffId))
            {
                return NotFound();
            }
            var staff = _mapper.Map<StaffDto>(_staffrepository.GetStaff(StaffId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(staff);
        }

        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateStaff([FromBody] StaffDto staffCreate)
        {
            if (staffCreate == null)
                return BadRequest(ModelState);

            var staffs = _staffrepository.GetStaffs()
                .Where(c => c.StaffSName.Trim().ToUpper() == staffCreate.StaffSName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (staffs != null)
            {
                ModelState.AddModelError("", "Staff already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var staffMap = _mapper.Map<Staff>(staffCreate);
            if (!_staffrepository.CreateStaff(staffMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("StaffId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateStaff(string staffId, [FromBody] StaffDto updatedStaff)
        {
            if (updatedStaff == null)
                return BadRequest(ModelState);

            if (staffId != updatedStaff.StaffSId)
                return BadRequest(ModelState);

            if (!_staffrepository.StaffExist(staffId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var staffMap = _mapper.Map<Staff>(updatedStaff);

            if (!_staffrepository.UpdateStaff(staffMap))
            {
                ModelState.AddModelError("", "Something went wrong updating staff");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("StaffId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStaff(string staffId)
        {
            if (!_staffrepository.StaffExist(staffId))
            {
                return NotFound();
            }

            var staffToDelete = _staffrepository.GetStaff(staffId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_staffrepository.RemoveStaff(staffToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting staff");
            }

            return NoContent();
        }
        [HttpGet("CheckLoginStaff")]
        [ProducesResponseType(200, Type = typeof(Admin))]
        [ProducesResponseType(400)]
        public IActionResult CheckLoginStaff([FromQuery] string staffEmail, [FromQuery] string staffPassword)
        {
            var staff = _staffrepository.CheckLoginForStaff(staffEmail, staffPassword);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(staff);
        }
    }
}
