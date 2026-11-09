namespace OnlineQuiz.Core.Entities;
public class Question
{
    public virtual int Id { get; set; }
    public virtual string QuestionText { get; set; }
    public virtual Quiz Quiz { get; set; }
    public virtual int QuestionOrder { get; set; }
}