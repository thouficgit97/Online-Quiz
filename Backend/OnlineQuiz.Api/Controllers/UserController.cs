using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Api.DTO;

namespace OnlineQuiz.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        [HttpPost("register")]
        public (bool,string) Register([FromBody] RegisterRequest request)
        {
            
            string username = request.Username;
            string password = request.Password;
            return _userService.Register(username, password);
            
        }

        [HttpPost("login")]
        public (bool,string) Login([FromBody] RegisterRequest request)
        {
            string username = request.Username;
            string password = request.Password;
            return _userService.Login(username, password);
        }
    }
}