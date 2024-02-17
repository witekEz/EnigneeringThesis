using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Read;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDTO dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDTO dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
