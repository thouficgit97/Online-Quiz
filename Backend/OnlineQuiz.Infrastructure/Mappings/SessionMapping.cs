namespace OnlineQuiz.Infrastructure.Mappings;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using OnlineQuiz.Core.Entities;
public class SessionMapping : ClassMapping<Session>
{
    public SessionMapping()
    {
        Table("Sessions");
        Id(x => x.Id, m => m.Generator(Generators.Identity));
        Property(x => x.CreatedAt, m => m.NotNullable(true));
        Property(x => x.ExpiresAt, m => m.NotNullable(true));
    }
}


