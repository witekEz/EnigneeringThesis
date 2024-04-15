using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.Model.DTOs.Read;
using UA.Model.DTOs.Update;
using UA.Services.Interfaces;

namespace UA.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) { _userService = userService; }
        [HttpGet]
        public ActionResult<List<UserDetailsDTO>> Get()
        {
            var users=_userService.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult<UserDetailsDTO> Get([FromRoute] int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _userService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateUserDetailsDTO dto)
        {
            _userService.Update(id,dto);
            return NoContent();
        }
    }
}
