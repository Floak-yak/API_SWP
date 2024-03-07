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
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomer()
        {
            var customer = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }
        [HttpGet("Customerid")]
        [ProducesResponseType(200, Type=typeof(Customer))]
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
        [HttpGet("CustomerName")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerByName(string customername)
        {
            var _customer = _mapper.Map<CustomerDto>(_customerRepository.GetCustomerByName(customername));
            var customer = _customer.GetType().GetProperties().Where(p => p.PropertyType == typeof(string));
            foreach (var stringProperty in customer)
            {
                string currentValue = (string)stringProperty.GetValue(_customer, null);
                stringProperty.SetValue(_customer, currentValue.Trim(), null);
            }
            if (customer == null)
                return NotFound();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }
        [HttpGet("CustomerEmail")]
        [ProducesResponseType(200, Type = typeof(Customer))]
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
        public IActionResult CreateCustomer([FromBody] CustomerDto createCustomer)
        {
            if (createCustomer == null) return BadRequest(ModelState);
            var customer = _customerRepository.GetCustomers().Where(p => p.CustomerEmail.Trim() == createCustomer.CustomerSEmail.Trim()).FirstOrDefault();
            if (customer != null)
            {
                ModelState.AddModelError("", "This customer is already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(createCustomer);

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
        public IActionResult UpdateCustomer(string customerId ,[FromBody] CustomerDto updateCustomer)
        {
            if (updateCustomer == null) return BadRequest(ModelState);
            if (customerId != updateCustomer.CustomerSId) return BadRequest(ModelState);
            if (!_customerRepository.CustomerExits(customerId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            var customerMap = _mapper.Map<Customer>(updateCustomer);
            
            if (!_customerRepository.UpdateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Update successfully");
        }
        [HttpGet("CheckLoginCustomer")]
        [ProducesResponseType(200, Type = typeof(Admin))]
        [ProducesResponseType(400)]
        public IActionResult CheckLoginCustomer([FromQuery] string loginName, [FromQuery] string password)
        {
            var customer = _customerRepository.CheckLoginForCustomer(loginName, password);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }
    }
}
