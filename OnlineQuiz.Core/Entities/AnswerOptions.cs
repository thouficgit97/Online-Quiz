namespace OnlineQuiz.Core.Entities;
public class AnswerOptions
{
    public virtual int Id { get; set; }
    public virtual Question Question { get; set; }
    public virtual string OptionText { get; set; }
    public virtual bool IsCorrect { get; set; }
    public virtual int OptionOrder { get; set; }
}