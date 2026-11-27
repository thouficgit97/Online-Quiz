namespace OnlineQuiz.Api.DTO;

public class QuizDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<QuestionDTO> Questions { get; set; }
}