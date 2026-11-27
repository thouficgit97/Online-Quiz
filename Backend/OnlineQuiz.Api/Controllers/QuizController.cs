namespace OnlineQuiz.Api;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Api.DTO;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly QuizService _quizService;
    public QuizController(QuizService quizService)
    {
        _quizService = quizService;
    }
    [HttpPost()]
    public void Create([FromBody] QuizDTO quizDTO)
    {
        
    }
}