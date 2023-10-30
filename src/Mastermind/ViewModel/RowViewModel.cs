namespace Mastermind.ViewModel;

public class RowViewModel : BaseViewModel
{
    public GameBoard GameBoard { get; init; }
    public List<Field> Fields { get; init; } = new();
    public int Number { get; init; }

    public bool IsActive => GameBoard.AmIActive(this);

    public int MyFieldIndex(Field _field) => Fields.IndexOf(_field);

    public Row(GameBoard _gameBoard, int _number)
    {
        GameBoard = _gameBoard;
        Number = _number;
        for (int i = 0; i < GameBoard.FieldCount; i++)
            Fields.Add(new Field(this, 0));
    }
    public void NPC(string propertyName) => OnPropertyChanged(propertyName);
}
