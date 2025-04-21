using Microsoft.AspNetCore.Mvc;
using CoinControl.Api.Services;
using System.Threading.Tasks;
using CoinControl.Api.Models;

namespace CoinControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;
        private readonly UserService _userService;

        public AuthController(FirebaseService firebaseService, UserService userService)
        {
            _firebaseService = firebaseService;
            _userService = userService;
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyUser([FromBody] VerifyUserModel model)
        {
            var user = await _firebaseService.GetUserInfoAsync(model.Uid);
            if (user != null)
            {
                var savedUser = await _userService.CreateUserIfNotExistsAsync(user);

                return Ok(new 
                {
                    message = "User verified successfully",
                    user = savedUser
                });
            }
            else
            {
                return Unauthorized(new { message = "Invalid UID" });
            }
        }
    }

    public class VerifyUserModel
    {
        public string Uid { get; set; }
    }
}
