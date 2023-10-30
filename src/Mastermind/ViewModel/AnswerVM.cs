namespace Mastermind.ViewModel;

public class AnswerVM
{
    public GameBoardVM GameBoard { get; init; }
    public List<AnswerFieldVM> Fields { get; init; }

    public AnswerVM(AppConfig _appConfig, GameBoardVM _gameBoard)
    {
        GameBoard = _gameBoard;
        Fields = Enumerable.Range(0, _appConfig.FieldCount).Select(i => new AnswerFieldVM(_appConfig, this, 0)).ToList();
    }
}
