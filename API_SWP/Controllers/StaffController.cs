﻿using AutoMapper;
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
    public class StaffController : Controller
    {
        private readonly IStaffRepository _staffrepository;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAdminRepository _adminRepository;

        public StaffController(IAdminRepository adminRepository, IMapper mapper, ICustomerRepository customerRepository, IStaffRepository staffRepository)
        {
            _customerRepository = customerRepository;
            _adminRepository = adminRepository;
            _staffrepository = staffRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllStaff")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StaffDto>))]
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
        [ProducesResponseType(200, Type = typeof(StaffDto))]
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
        [HttpGet("GetStaffByName")]
        [ProducesResponseType(200, Type = typeof(StaffDto))]
        [ProducesResponseType(400)]
        public IActionResult GetAdminByEmail(string staffName)
        {
            var staff = _mapper.Map<List<StaffDto>>(_staffrepository.GetStaffByName(staffName));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //return Ok(Json(result).Value);
            return Ok(staff);
        }
        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateStaff([FromBody] StaffDto staffCreate)
        {
            if (staffCreate == null)
                return BadRequest(ModelState);

            if (_staffrepository.GetStaffs()
                .Where(c => c.StaffSId.Trim().ToUpper() == staffCreate.StaffSId.TrimEnd().ToUpper())
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Id already exists");
                return StatusCode(422, "Staff already exists");
            }

            if (_adminRepository.GetAdminByEmail(staffCreate.StaffSEmail) != null || _customerRepository.GetCustomerByEmail(staffCreate.StaffSEmail) != null || _staffrepository.GetStaffByEmail(staffCreate.StaffSEmail) != null)
            {
                ModelState.AddModelError("", "Email already exists");
                return StatusCode(422, ModelState);
            }

            if (_staffrepository.GetStaffs()
                .Where(c => c.StaffSEmail.Trim().ToUpper() == staffCreate.StaffSEmail.TrimEnd().ToUpper())
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Email already exists");
                return StatusCode(422, "Staff already exists");
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
        public IActionResult UpdateStaff(string staffId, [FromBody] StaffUpdateModel updatedStaff)
        {
            if (updatedStaff == null)
                return BadRequest(ModelState);

            if (!_staffrepository.StaffExist(staffId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var staffMap = _mapper.Map<Staff>(updatedStaff);
            staffMap.StaffSId = staffId;
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
        [ProducesResponseType(200, Type = typeof(Staff))]
        [ProducesResponseType(400)]
        public IActionResult CheckLoginStaff([FromQuery] string staffEmail, [FromQuery] string staffPassword)
        {
            var staff = _mapper.Map<StaffDto>(_staffrepository.CheckLoginForStaff(staffEmail, staffPassword));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(staff);
        }
    }
}
