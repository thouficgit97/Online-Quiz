using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace OnlineQuiz.Api.DTO;
public static class NHibernateConfiguration
{
    public static ISessionFactory CreateSessionFactory(string connectionString)
    {
        var configuration = new Configuration();
        configuration.DataBaseIntegration(db =>
        {
            db.ConnectionString = connectionString;
            db.Dialect<PostgreSQLDialect>();
            db.Driver<NpgsqlDriver>();
        });
        var mapper = new ModelMapper();
        var mappingTypes = typeof(UserMapping)
            .Assembly
            .GetExportedTypes()
            .Where(t => !t.IsAbstract &&
                        !t.IsGenericTypeDefinition &&
                        t.BaseType?.IsGenericType == true &&
                        t.BaseType.GetGenericTypeDefinition() ==
                            typeof(ClassMapping<>));

        mapper.AddMappings(mappingTypes);
        configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

        return configuration.BuildSessionFactory();
    }
}