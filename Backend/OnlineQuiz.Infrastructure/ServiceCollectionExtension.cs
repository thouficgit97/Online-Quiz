using Microsoft.Extensions.DependencyInjection; // IServiceCollection
using OnlineQuiz.Api.DTO; 
using NHibernate.Cfg;
public static class ServiceCollectionExtension
{
    public static void AddInfranstructure(this IServiceCollection services,string connectionString)
    {
        var sessionFactory = NHibernateConfiguration.CreateSessionFactory(connectionString);
        services.AddSingleton(sessionFactory);
    }
}