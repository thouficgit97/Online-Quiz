namespace OnlineQuiz.Api.DTO;
public class QuestionDTO
{
  public string QuestionText { get; set; }
  public int QuestionOrder { get; set; }
  List<OptionDTO> Options { get; set; }
}