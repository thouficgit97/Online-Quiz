using NHibernate.Criterion;
using OnlineQuiz.Api.DTO;
using OnlineQuiz.Core.Entities;

namespace OnlineQuiz.Api;
public class QuizService
{
    private readonly DBService _dBService;
    public void CreateQuiz(QuizDTO quizDTO)
    {
        AppUser createdBy = _dBService.GetById<AppUser>(quizDTO.CreatedById);
        string quizCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();

        Quiz quiz = new Quiz()
        {
            Title = quizDTO.Title,
            Description = quizDTO.Description,
            CreatedBy = createdBy,
            CreatedAt = quizDTO.CreatedAt,
            QuizCode = quizCode
        };
        _dBService.Save<Quiz>(quiz);
    }
    public QuizDTO GetQuizDTO(string quizCode)
    {
        var getByCode = Projections.ProjectionList()
            .Add(Projections.Property<Quiz>(q => q.QuizCode));
        Quiz quiz = _dBService.GetByProjection<Quiz>(getByCode);
        if (quiz == null)
        {
            return null;
        }
        QuizDTO quizDTO = new QuizDTO()
        {
            Title = quiz.Title,
            Description = quiz.Description,
            CreatedById = quiz.CreatedBy.Id,
            CreatedAt = quiz.CreatedAt
        };
        // var questions = _dbService.G
        // quizDTO.Questions = questions.Select(q => new QuestionDTO();
        return quizDTO;
    }
}