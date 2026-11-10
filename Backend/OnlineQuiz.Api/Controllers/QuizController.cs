namespace OnlineQuiz.Api;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly QuizService _quizService;
    public QuizController(QuizService quizService)
    {
        _quizService = quizService;
    }
    [HttpPost("quiz")]
    public void Create()
    {
        
    }
}