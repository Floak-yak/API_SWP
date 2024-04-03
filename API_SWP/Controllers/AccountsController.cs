//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using API_SWP.Model;
//using API_SWP.Repositories;

//namespace API_SWP.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountsController : ControllerBase
//    {
//        private readonly IAccountRepository accountRepo;

//        public AccountsController(IAccountRepository repo)
//        {
//            accountRepo = repo;
//        }

//        [HttpPost("SignIn")]
//        public async Task<IActionResult> SignIn(SignIn signInModel)
//        {
//            var result = await accountRepo.SignInAsync(signInModel);

//            if (string.IsNullOrEmpty(result))
//            {
//                return Unauthorized();
//            }

//            return Ok(result);
//        }
//    }
//}
