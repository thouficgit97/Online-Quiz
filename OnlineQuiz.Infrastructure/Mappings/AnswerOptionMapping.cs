using OnlineQuiz.Core.Entities;
using NHibernate.Mapping.ByCode;
public class AnswerOptionMapping : ClassMapping<AnswerOption>
{
    public AnswerOptionMapping()
    {
        Table(nameof(AnswerOption));
        Id(nameof(AnswerOption.Id));
        Property(x => x.OptionText,m =>
        {
            m.Column("OptionText");
            m.NotNullable(true);
        })
        Property(x => x.OptionOrder, m =>
        {
            m.Column("OptionOrder");
            m.NotNullable(true);
        })
        Property(x => x.IsCorrect, m =>
        {
            m.Column("IsCorrect");
            m.NotNullable(true);
        })
    }
}