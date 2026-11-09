public static class ServiceCollectionExtension
{
    public static void AddInfranstructure(this IserviceCollection services, IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("DefaultConnection");
      var sessionFactory = NHibernateConfiguration.CreateSessionFactory(connectionString);
      services.AddSingleton(sessionFactory);
    } 
}