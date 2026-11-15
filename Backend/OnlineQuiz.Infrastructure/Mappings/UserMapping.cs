using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using OnlineQuiz.Core.Entities;

public class UserMapping : ClassMapping<AppUser>
{
    public UserMapping()
    {
        Table(nameof(AppUser).ToLower());

        Id(x => x.Id, m =>
        {
            m.Column(nameof(AppUser.Id).ToLower());
            m.Generator(Generators.Identity);
        });

        Property(x => x.Username, m =>
        {
            m.Column(nameof(AppUser.Username).ToLower());
            m.NotNullable(true);
            m.Length(50);
        });
        Property(x => x.Password, m =>
        {
            m.Column(nameof(AppUser.Password).ToLower());
            m.NotNullable(true);
            m.Length(100);
        });
    }
}