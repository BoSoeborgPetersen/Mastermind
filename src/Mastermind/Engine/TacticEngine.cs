using Mastermind.ViewModel;

namespace Mastermind.Engine;

public class TacticEngine
{
    readonly AppConfig appConfig;
    readonly Random rand = new();

    public TacticEngine(AppConfig _appConfig, Random _rand)
    {
        appConfig = _appConfig;
        rand = _rand;
    }

    public void CreateSolution(GameBoardVM _gameBoard) => _gameBoard.Solution.Fields.ForEach(f => f.Value = rand.Next(appConfig.FieldColors.Count));

    public void SolveRow(GameBoardVM _gameBoard)
    {
        int fieldColorCount = appConfig.ColorCount;
        List<int> usedPositions = new();
        int c = 0;
        foreach (FieldVM f in _gameBoard.ActiveBid.Fields.Where(x => _gameBoard.Solution.Fields.ElementAt(x.Index).Value == x.Value))
        {
            _gameBoard.ActiveAnswer.Fields.ElementAt(c++).Value = 2;
            usedPositions.Add(f.Index);
        }

        FieldVM i;
        foreach (FieldVM f in _gameBoard.ActiveBid.Fields.Where(x => _gameBoard.Solution.Fields.ElementAt(x.Index).Value != x.Value))
        {
            i = _gameBoard.Solution.Fields.Where(y => !usedPositions.Contains(y.Index)).Where(y => y.Value == f.Value).FirstOrDefault();
            if (i != null)
            {
                _gameBoard.ActiveAnswer.Fields.ElementAt(c++).Value = 1;
                usedPositions.Add(i.Index);
            }
        }
        if (_gameBoard.ActiveAnswer.Fields.All(x => x.Value == 2)) _gameBoard.Solved();
        if (_gameBoard.ActiveBidIndex == 0) _gameBoard. Failed();
    }
}
