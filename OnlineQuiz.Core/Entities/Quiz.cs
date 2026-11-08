namespace OnlineQuiz.Core.Entities;
public class Quiz
{
    public virtual int Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Description { get; set; }
    public virtual DateTime CreatedAt { get; set; }
    public virtual User CreatedBy { get; set; }
}