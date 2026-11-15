using Microsoft.Extensions.DependencyInjection; // IServiceCollection
using OnlineQuiz.Api.DTO; 
using NHibernate.Cfg;
public static class ServiceCollectionExtension
{
    public static Configuration AddInfranstructure(this IServiceCollection services,string connectionString)
    {
        var configuration = NHibernateConfiguration.CreateSessionFactory(connectionString);
        services.AddSingleton(configuration.BuildSessionFactory());
        return configuration;
    }
}