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
        public async Task<IActionResult> RegisterUser([FromBody]RegisterUserDTO dto)
        {
            await _accountService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO dto)
        {
            string token = await _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
