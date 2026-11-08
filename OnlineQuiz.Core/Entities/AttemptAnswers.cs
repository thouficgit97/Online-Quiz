namespace OnlineQuiz.Core.Entities;
public class AttemptAnswers
{
    public virtual int Id { get; set; }
    public virtual QuizAttempts QuizAttempt { get; set; }
    public virtual Question Question { get; set; }
    public virtual AnswerOptions SelectedOption { get; set; }
}