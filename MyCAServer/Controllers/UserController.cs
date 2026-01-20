using BL;
using DAL;
using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCAServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<TUser>> signup([FromBody] UserSignupDTO userSignup)
        {
            try
            {
                int userId = await _userBL.AddUser(userSignup);
                if (userId == null)
                {
                    return StatusCode(500);
                }
                return CreatedAtAction(nameof(GetUserById), new { id = userId }, userSignup);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TUser>> GetUserById(int id)
        {
            TUser user = await _userBL.GetUserById(id);
            if (user == null)
                return NotFound();
            //UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ClientUserWithToken>> login([FromBody] UserLoginDTO userLogin)
        {
            try
            {
                ClientUserWithToken res = await _userBL.Login(userLogin.Email, userLogin.Password);
                if(res == null)
                    return Unauthorized();
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
