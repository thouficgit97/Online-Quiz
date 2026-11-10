using Microsoft.Extensions.DependencyInjection; // IServiceCollection
using OnlineQuiz.Api.DTO; 
using NHibernate.Cfg;
public static class ServiceCollectionExtension
{
    public static void AddInfranstructure(this IServiceCollection services,IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("DefaultConnection");
      var sessionFactory = NHibernateConfiguration.CreateSessionFactory(connectionString);
      services.AddSingleton(sessionFactory);
    } 
}