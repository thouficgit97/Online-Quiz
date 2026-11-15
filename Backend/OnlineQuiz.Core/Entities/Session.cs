namespace OnlineQuiz.Core.Entities;
public class Session
{
    public virtual Guid Id { get; set; }
    public virtual AppUser User { get; set; }
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime ExpiresAt { get; set; }
}