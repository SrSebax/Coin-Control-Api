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

        public AuthController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyUser([FromBody] VerifyUserModel model)
        {
            AuthModel user = await _firebaseService.GetUserInfoAsync(model.Uid);
            if (user != null)
            {
                return Ok(new 
                {
                    message = "User verified successfully",
                    user
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
