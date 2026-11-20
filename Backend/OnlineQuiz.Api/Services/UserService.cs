namespace OnlineQuiz.Api;

using NHibernate.Criterion;
using OnlineQuiz.Core.Entities;
public class UserService
{
    private readonly DBService _dbService;
    public (bool, string) Register(string username, string password)
    {
        var user = _dbService.Get<AppUser>(Restrictions.Eq(nameof(AppUser.Username), username));
        if (user != null)
        {
            return (false, "Username already exists");
        }
        else
        {
            var newUser = new AppUser
            {
                Username = username,
                Password = password,
                CreatedAt = DateTime.UtcNow
                // In a real application, make sure to hash the password before storing it
            };
            try
            {
                _dbService.Save<AppUser>(newUser);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        return (true, "User registered successfully");
    }
    public (bool, string) Login(string username, string password)
    {
        var user = _dbService.Get<AppUser>(Restrictions.Eq(nameof(AppUser.Username), username));
        if (user == null || user.Password != BCrypt.Net.BCrypt.Verify(password))
        {
            return (false, "Invalid username or password");
        }
        // Implement session management logic here
        var session = new Session()
        {
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddHours(24),
            User = user
        };
        _dbService.Save<Session>(session);
        return (true, "Login successful");
    }
}