namespace Mastermind.Model;

public partial class AnswerField : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FieldAsColor))]
    [NotifyPropertyChangedFor(nameof(FieldAsBorderColor))]
    private int value;

    public Answer Answer { get; init; }

    public Color FieldAsColor => Answer.GameBoard.AnswerFieldColors.ElementAt(Value);
    public Color FieldAsBorderColor => Answer.GameBoard.FieldBorderColors.ElementAt(Value);

    public AnswerField(Answer _answer, int _value)
    {
        Answer = _answer;
        Value = _value;
    }
}
