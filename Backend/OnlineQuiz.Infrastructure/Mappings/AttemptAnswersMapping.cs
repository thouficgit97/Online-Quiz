using OnlineQuiz.Core.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

public class AttemptAnswersMapping : ClassMapping<AttemptAnswers>
{
    public AttemptAnswersMapping()
    {
        Table(nameof(AttemptAnswers).ToLower());
        Id(x => x.Id,m => m.Generator(Generators.Identity));
        ManyToOne(x => x.QuizAttempt,m =>
        {
            m.Column("QuizAttempt");
            m.NotNullable(true);
        });
        ManyToOne(x => x.Question,m =>
        {
            m.Column("Questioin");
            m.NotNullable(true);
        });
        ManyToOne(x => x.AnswerOptions,m =>
        {
            m.Column("AnswerOption");
            m.NotNullable(true);
        });
    }
}