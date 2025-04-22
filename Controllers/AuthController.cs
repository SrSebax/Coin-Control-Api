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
        private readonly AuthService _authService;

        public AuthController(FirebaseService firebaseService, AuthService authService)
        {
            _firebaseService = firebaseService;
            _authService = authService;
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyUser([FromBody] VerifyUserModel model)
        {
            if (string.IsNullOrEmpty(model.Uid))
            {
                return BadRequest(new { message = "UID cannot be null or empty" });
            }

            var user = await _firebaseService.GetUserInfoAsync(model.Uid);
            if (user != null)
            {
                var savedUser = await _authService.CreateUserIfNotExistsAsync(user);

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
        public string? Uid { get; set; }
    }
}
