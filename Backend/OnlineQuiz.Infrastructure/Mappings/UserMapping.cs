using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using OnlineQuiz.Core.Entities;

public class UserMapping : ClassMapping<User>
{
    public UserMapping()
    {
        Table(nameof(User).ToLower());

        Id(x => x.Id, m =>
        {
            m.Column(nameof(User.Id).ToLower());
            m.Generator(Generators.Identity);
        });

        Property(x => x.Username, m =>
        {
            m.Column(nameof(User.Username).ToLower());
            m.NotNullable(true);
            m.Length(50);
        });
        Property(x => x.Password, m =>
        {
            m.Column(nameof(User.Password).ToLower());
            m.NotNullable(true);
            m.Length(100);
        });
    }
}