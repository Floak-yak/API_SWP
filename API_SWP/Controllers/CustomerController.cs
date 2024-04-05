using AutoMapper;
using API_SWP.Dto;
using API_SWP.Interface;
using API_SWP.Model;
using API_SWP.Repository;
using Microsoft.AspNetCore.Mvc;
using API_SWP.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace API_SWP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllCustomerInformation")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDto>))]
        public IActionResult GetCustomer()
        {
            var customer = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }
        [HttpGet("Customerid"), Authorize(Roles = "Admin")]
        [ProducesResponseType(200, Type=typeof(CustomerDto))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerById(string customerid)
        {
            if(!_customerRepository.CustomerExits(customerid))
            {
                return NotFound();
            }
            var customer = _mapper.Map<CustomerDto>(_customerRepository.GetCustomerById(customerid));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }
        [HttpGet("GetCustomerByName")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerByName(string customerName)
        {
            var customers = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomerByName(customerName));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customers);
        }
        [HttpGet("GetCustomerByEmail")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerByEmail(string customeremail)
        {
            var customer = _mapper.Map<CustomerDto>(_customerRepository.GetCustomerByEmail(customeremail));
            if (customer == null)
                return NotFound();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }
        [HttpDelete("CustomerId/Delete")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCustomer(string CustomerId)
        {
            if (!_customerRepository.CustomerExits(CustomerId))
            {
                return NotFound();
            }

            var customerToDelete = _customerRepository.GetCustomerById(CustomerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_customerRepository.RemoveCustomer(customerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting customer");
            }

            return NoContent();
        }
        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromBody] CustomerRegisterDto createCustomer)
        {
            if (createCustomer == null) return BadRequest(ModelState);
            var customer = _customerRepository.GetCustomers().Where(p => p.CustomerEmail.Trim() == createCustomer.CustomerEmail.Trim()).FirstOrDefault();
            if (customer != null)
            {
                ModelState.AddModelError("", "This customer is already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(createCustomer);
            customerMap.PhoneNumber = "";

            do
            {
                Random rnd = new ();
                customerMap.CustomerSId = rnd.Next(1, 10000).ToString();
                    
            } while (_customerRepository.CustomerExits(customerMap.CustomerSId) == true);
            

            if (!_customerRepository.CreateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Create Successfully");
        }
        [HttpPut("CustomerId/Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer(string customerId ,[FromBody] CustomerUpdateModel updateCustomer)
        {
            if (updateCustomer == null) return BadRequest(ModelState);
            if (!_customerRepository.CustomerExits(customerId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            var customerMap = _mapper.Map<Customer>(updateCustomer);
            customerMap.CustomerSId = customerId;
            if (!_customerRepository.UpdateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Update successfully");
        }
        [HttpGet("CheckLoginCustomer")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public IActionResult CheckLoginCustomer([FromQuery] string EmailCustomer, [FromQuery] string password)
        {
            var customer = _mapper.Map<CustomerDto>(_customerRepository.CheckLoginForCustomer(EmailCustomer, password));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }









        //[HttpGet("Customerid/password")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //public IActionResult Getpass(string chuoimahoa ,string customerid)
        //{
        //    if (!_customerRepository.CustomerExits(customerid))
        //    {
        //        return NotFound();
        //    }
        //    var customer = _mapper.Map<CustomerDto>(_customerRepository.Encrypt(chuoimahoa, customerid));
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return Ok(customer);
        //}
    }
}
