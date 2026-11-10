using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using OnlineQuiz.Core.Entities;

public class QuizAttemptMapping : ClassMapping<QuizAttempts>
{
    QuizAttemptMapping()
    {
        Id(x => x.Id, m => m.Generator(Generators.Identity));
        ManyToOne(x => x.AttemptedBy, m =>
        {
            m.Column("AttemptedById");
            m.Cascade(Cascade.None);
        });
        ManyToOne(x => x.Quiz, m =>
        {
            m.Column("QuizId");
            m.Cascade(Cascade.None);
        });
        Property(x => x.AttemptedAt, m => m.NotNullable(true));
        Property(x => x.CompletedAt, m => m.NotNullable(true));
        Property(x => x.Score, m => m.NotNullable(true));
    }
}