using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Api.DTO;

namespace OnlineQuiz.Api
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
        [HttpPost("register")]
        public (bool,string) Register([FromBody] RegisterRequest request)
        {
            
            string username = request.Username;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            return _userService.Register(username, hashedPassword);
            
        }

        [HttpPost("login")]
        public (bool,string) Login([FromBody] RegisterRequest request)
        {
            string username = request.Username;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            return _userService.Login(username, hashedPassword);
        }
    }
}