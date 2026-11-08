namespace OnlineQuiz.Core.Entities;
public class QuizAttempts
{
    public virtual int Id { get; set; }
    public virtual User AttemptedBy { get; set; }
    public virtual Quiz Quiz { get; set; }
    public virtual DateTime AttemptedAt { get; set; }
    public virtual DateTime CompletedAt { get; set; }
    public virtual int Score { get; set; }
}