using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace OnlineQuiz.Api.DTO;
public static class NHibernateConfiguration
{
    public static Configuration CreateSessionFactory(string connectionString)
    {
        var configuration = new Configuration();
        configuration.DataBaseIntegration(db =>
        {
            db.ConnectionString = connectionString;
            db.Dialect<PostgreSQL82Dialect>();
            db.Driver<NpgsqlDriver>();
        });
        var mapper = new ModelMapper();
        var mappingTypes = typeof(NHibernateConfiguration)
            .Assembly
            .GetExportedTypes();
            // .Where(t => !t.IsAbstract &&
            //             !t.IsGenericTypeDefinition &&
            //             t.BaseType?.IsGenericType == true &&
            //             t.BaseType.GetGenericTypeDefinition() ==
            //                 typeof(ClassMapping<>));

        mapper.AddMappings(mappingTypes);
        configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

        return configuration;
    }
}