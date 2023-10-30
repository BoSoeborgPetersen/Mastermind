namespace Mastermind.Engine;

public class TacticEngine
{
    readonly Random rand = new();

    public void CreateSolution(GameBoard _gameBoard) => _gameBoard.Solution.Fields.ForEach(f => f.Value = rand.Next(_gameBoard.FieldColorCount));

    public void SolveRow(GameBoard _gameBoard)
    {
        int fieldColorCount = _gameBoard.FieldColorCount;
        List<int> usedPositions = new();
        int c = 0;
        foreach (Field f in _gameBoard.ActiveBid.Fields.Where(x => _gameBoard.Solution.Fields.ElementAt(x.Index).Value == x.Value))
        {
            _gameBoard.ActiveAnswer.Fields.ElementAt(c++).Value = 2;
            usedPositions.Add(f.Index);
        }

        Field i;
        foreach (Field f in _gameBoard.ActiveBid.Fields.Where(x => _gameBoard.Solution.Fields.ElementAt(x.Index).Value != x.Value))
        {
            i = _gameBoard.Solution.Fields.Where(y => !usedPositions.Contains(y.Index)).Where(y => y.Value == f.Value).FirstOrDefault();
            if (i != null)
            {
                _gameBoard.ActiveAnswer.Fields.ElementAt(c++).Value = 1;
                usedPositions.Add(i.Index);
            }
        }
        if (_gameBoard.ActiveAnswer.Fields.All(x => x.Value == 2)) _gameBoard.Solved();
        if (_gameBoard.ActiveBidIndex == 0) _gameBoard.Failed();
    }
}
