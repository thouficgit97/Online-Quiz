namespace OnlineQuiz.Api;
using OnlineQuiz.Core.Entities;
public class userService
{
    public void Register(string username, string password)
    {
        // Implement the logic to register a new user
        // For example, you can create a new User object and save it to the database
        var user = new User
        {
            Username = username,
            Password = password,
            CreatedAt = DateTime.UtcNow
        };
        
        DBService.Save<User>(user);
        // Save the user to the database (this is just a placeholder, implement your own logic)
        // dbContext.Users.Add(user);
        // dbContext.SaveChanges();
    }
}