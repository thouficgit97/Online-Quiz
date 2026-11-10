using OnlineQuiz.Core.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
public class AnswerOptionMapping : ClassMapping<AnswerOptions>
{
    public AnswerOptionMapping()
    {
        Table(nameof(AnswerOptions));
        Id(x => x.Id,m => m.Generator(Generators.Identity));
        Property(x => x.OptionText,m =>
        {
            m.Column("OptionText");
            m.NotNullable(true);
        });
        Property(x => x.OptionOrder, m =>
        {
            m.Column("OptionOrder");
            m.NotNullable(true);
        });
        Property(x => x.IsCorrect, m =>
        {
            m.Column("IsCorrect");
            m.NotNullable(true);
        });
    }
}