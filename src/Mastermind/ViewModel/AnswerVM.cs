namespace Mastermind.ViewModel;

public class AnswerVM(AppConfig _appConfig)
{
    public List<AnswerFieldVM> Fields { get; init; } = Enumerable.Range(0, _appConfig.FieldCount).Select(_ => new AnswerFieldVM(_appConfig)).ToList();
}
