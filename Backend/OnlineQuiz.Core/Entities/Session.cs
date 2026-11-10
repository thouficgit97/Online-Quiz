namespace OnlineQuiz.Core.Entities;
public class Session
{
    public virtual Guid Id { get; } = new Guid();
    public virtual User User { get; set; }
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime ExpiresAt { get; set; }
}