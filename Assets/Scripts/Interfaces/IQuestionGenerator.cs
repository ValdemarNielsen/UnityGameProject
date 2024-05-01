namespace Assets.Scripts.Interfaces
{
    public interface IQuestionGenerator
    {
        string GenerateQuestion();
        string CorrectAnswer {  get; }
    }
}
