using OnlineQuiz.Core.Entities;
using NHibernate.Mapping.ByCode;    

public class QuizMapping : ClassMapping<Quiz>
{
    public QuizMapping()
    {
        Table(nameof(Quiz).ToLower());
        Id(x => x.Id, m => m.Generator(Generators.Identity));
        Property(x => x.Title, m => m.NotNullable(true));
        Property(x => x.Description, m => m.NotNullable(false));
        Property(x => x.CreatedAt, m => m.NotNullable(true));
        ManyToOne(x => x.CreatedBy, m =>
        {
            m.Column("CreatedById");
            m.Cascade(Cascade.None);
            m.NotNullable(true);
        });
    }
}