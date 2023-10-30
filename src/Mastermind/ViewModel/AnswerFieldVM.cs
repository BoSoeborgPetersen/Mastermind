namespace Mastermind.ViewModel;

public partial class AnswerFieldVM : ObservableObject
{
    readonly AppConfig appConfig;
    public AnswerVM Answer { get; init; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Color))]
    [NotifyPropertyChangedFor(nameof(BorderColor))]
    private int value;

    public AnswerFieldVM(AppConfig _appConfig, AnswerVM _answer, int _value)
    {
        appConfig = _appConfig;
        Answer = _answer;
        Value = _value;
    }

    public Color Color => appConfig.AnswerFieldColors[Value];
    public Color BorderColor => appConfig.FieldBorderColors[Value];
}