namespace Mastermind.Model;

public partial class Field : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FieldAsColor))]
    [NotifyPropertyChangedFor(nameof(FieldAsBorderColor))]
    private int value;

    public Row Row { get; init; }

    public Color FieldAsColor => Row.GameBoard.FieldColors.ElementAt(Value);
    public Color FieldAsBorderColor => Row.GameBoard.FieldBorderColors.ElementAt(Value);
    public int Index => Row.MyFieldIndex(this);

    public Field(Row _row, int _value)
    {
        Row = _row;
        Value = _value;
    }
}
