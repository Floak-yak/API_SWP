using AutoMapper;
using API_SWP.Data;
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
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminController(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Admin>))]
        public IActionResult GetAdmins()
        {
            var admin = _mapper.Map<List<Admin>>(_adminRepository.GetAdmins());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(admin);
        }
        [HttpGet("GetAdminById")]
        [ProducesResponseType(200, Type = typeof(AdminModel))]
        [ProducesResponseType(400)]
        public IActionResult GetAdmin(string AdminId)
        {
            if (!_adminRepository.AdminExits(AdminId))
            {
                return NotFound();
            }
            var add = _mapper.Map<Admin>(_adminRepository.GetAdmin(AdminId));
            AdminModel admin = new () { AdminSPassword = add.AdminSPassword, AdminSMail = add.AdminSMail };
            var result = "{\"AdminSMail\": \"" + admin.AdminSMail + "\",\"AdminSMail\": \"" + admin.AdminSPassword + "\"}";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //return Ok(Json(result).Value);
            return Ok(admin);
        }

        [HttpGet("GetAdminByMail")]
        [ProducesResponseType(200, Type = typeof(Admin))]
        [ProducesResponseType(400)]
        public IActionResult GetAdminByEmail(string AdminEmail)
        {
            var admin = _mapper.Map<List<Admin>>(_adminRepository.GetAdminByName(AdminEmail));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(admin);
        }

        [HttpPut("AdminId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAdmin(string adminId, [FromBody] AdminDto updatedAdmin)
        {
            if (updatedAdmin == null)
                return BadRequest(ModelState);

            if (adminId != updatedAdmin.AdminSId)
                return BadRequest(ModelState);

            if (!_adminRepository.AdminExits(adminId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var adminMap = _mapper.Map<Admin>(updatedAdmin);

            if (!_adminRepository.UpdateAdmin(adminMap))
            {
                ModelState.AddModelError("", "Something went wrong updating admin");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAdmin([FromBody] AdminDto AdminCreate)
        {
            if (AdminCreate == null)
                return BadRequest(ModelState);

            var admin = _adminRepository.GetAdmins()
                .Where(c => c.AdminSMail.Trim().ToUpper() == AdminCreate.AdminSMail.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (admin != null)
            {
                ModelState.AddModelError("", "Admin already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var adminMap = _mapper.Map<Admin>(AdminCreate);
            if (!_adminRepository.CreateAdmin(adminMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpGet("CheckLoginAdmin")]
        [ProducesResponseType(200, Type = typeof(Admin))]
        [ProducesResponseType(400)]
        public IActionResult CheckLoginAdmin([FromQuery] string adminEmail, [FromQuery] string password)
        {
            var admin = _adminRepository.CheckLoginForAdmin(adminEmail, password);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(admin);
        }
    }
}
