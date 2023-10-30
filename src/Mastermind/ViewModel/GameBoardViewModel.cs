using Mastermind.Engine;
using System.Windows.Input;

namespace Mastermind.ViewModel;

public class GameBoardViewModel : BaseViewModel
{
    private MainViewModel _mainViewModel;
    private GameBoard _gameBoard;
    private TacticEngine _tacticEngine = new();
    public Row Solution => _gameBoard.Solution;
    public bool IsSolved => _gameBoard.IsSolved;
    public bool IsFailed => _gameBoard.IsFailed;
    public List<Answer> Answers => _gameBoard.Answers;
    public List<Row> Bids => _gameBoard.Bids;
    public bool GameInProgress => _gameBoard.GameInProgress;


    public ICommand NewCommand { get; private set; }

    public GameBoardViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;

        NewCommand = new RelayCommand(New);
        New();
    }

    public void New()
    {
        _gameBoard = new GameBoard(FieldCount, FieldColorCount, RowCount, FieldColors, FieldBorderColors, AnswerFieldColors);
        _tacticEngine.CreateSolution(_gameBoard);
        OnPropertyChanged(nameof(GameBoard));
    }
}
