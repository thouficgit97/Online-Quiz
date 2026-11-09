using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using OnlineQuiz.Core.Entities;
public class QuestionMapping : ClassMapping<Question>
{
    public QuestionMapping()
    {
        Table(nameof(Question).ToLower());
        Id(x => x.Id, m => m.Generator(Generators.Identity));
        Property(x => x.QuestionText, m => m.Column("QuestionText"));
        ManyToOne(x => x.Quiz, m =>
        {
            m.Column("QuizId");
            m.Cascade(Cascade.None);
            m.NotNullable(true);
        });
        Property(x => x.QuestionOrder, m => m.Column("QuestionOrder"));
    }
}