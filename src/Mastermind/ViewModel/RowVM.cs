namespace Mastermind.ViewModel;

public class RowVM : ObservableObject
{
    public GameBoardVM GameBoard { get; init; }
    public List<FieldVM> Fields { get; init; } = new();
    public int Number { get; init; }

    public bool IsActive => GameBoard.AmIActive(this);

    public int MyFieldIndex(FieldVM _field) => Fields.IndexOf(_field);


    public ICommand BidConfirmedCommand { get; private set; }

    public RowVM(AppConfig appConfig, GameBoardVM _gameBoard, int _number)
    {
        GameBoard = _gameBoard;
        Number = _number;
        for (int i = 0; i < appConfig.FieldCount; i++)
            Fields.Add(new FieldVM(appConfig, this, 0));
        BidConfirmedCommand = new RelayCommand(BidConfirmed);
    }
    public void NPC(string propertyName) => OnPropertyChanged(propertyName);

    public void BidConfirmed()
    {
        GameBoard.BidConfirmed(this);
    }
}
