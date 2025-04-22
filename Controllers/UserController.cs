using Microsoft.AspNetCore.Mvc;
using CoinControl.Api.Models;
using CoinControl.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public ActionResult<List<UserModel>> Get()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        // GET: api/user/{uid}
        [HttpGet("{uid}")]
        public async Task<ActionResult<UserModel>> GetByUid(string uid)
        {
            var user = await _userService.GetUserByUidAsync(uid);
            if (user == null)
            {
                return NotFound($"User with UID {uid} not found.");
            }
            return Ok(user);
        }

        // PUT: api/user/{uid}
        [HttpPut("{uid}")]
        public async Task<ActionResult<UserModel>> Put(string uid, [FromBody] UserModel userModel)
        {
            var updatedUser = await _userService.UpdateUserAsync(uid, userModel);
            if (updatedUser == null)
            {
                return NotFound($"User with UID {uid} not found.");
            }
            return Ok(updatedUser);
        }

        // DELETE: api/user/{uid}
        [HttpDelete("{uid}")]
        public async Task<ActionResult> Delete(string uid)
        {
            var result = await _userService.DeleteUserAsync(uid);
            if (!result)
            {
                return NotFound($"User with UID {uid} not found.");
            }
            return NoContent();
        }
    }
}
