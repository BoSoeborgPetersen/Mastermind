namespace Mastermind.ViewModel;

public class BaseViewModel : ObservableObject
{
    public int FieldCount { get; } = 4;
    public int FieldColorCount { get; } = 7;
    public int RowCount { get; } = 10;

    public List<Color> FieldColors { get; } = new List<Color>() { Colors.Transparent, Colors.White, Colors.Black, Colors.Green, Colors.Blue, Colors.Red, Colors.Yellow };
    public List<Color> FieldBorderColors { get; } = new List<Color>() { Colors.Transparent, Colors.Black, Colors.White, Colors.Black, Colors.Black, Colors.Black, Colors.Black };
    public List<Color> AnswerFieldColors { get; } = new List<Color>() { Colors.Transparent, Colors.White, Colors.Black };
}
