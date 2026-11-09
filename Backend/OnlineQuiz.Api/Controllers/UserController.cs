namespace OnlineQuiz.Api;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    [Route("register")]
    [HttpPost]
    public void Register([FromBody] RegisterRequest request)
    {
        
        string username = request.Username;
        string password = request.Password;
        userService.Register(username, password);
        
    }

    [HttpGet("session")]
    public async Task<IActionResult> CheckSession()
    {
        // Implement session check logic
        return Ok();
    }
}