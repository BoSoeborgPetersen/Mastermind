namespace Mastermind.Model;

public class GameBoard : ObservableObject
{
    public int FieldCount { get; init; }
    public int FieldColorCount { get; init; }
    public int RowCount { get; init; }
    public List<Color> FieldColors { get; init; }
    public List<Color> FieldBorderColors { get; init; }
    public List<Color> AnswerFieldColors { get; init; }

    public Row Solution { get; init; }
    public List<Row> Bids { get; init; } = new();
    public List<Answer> Answers { get; init; } = new();
    public int ActiveBidIndex { get; private set; }
    public bool IsSolved { get; private set; }
    public bool IsFailed { get; private set; }
    public bool GameInProgress => !IsSolved && !IsFailed;

    public Row ActiveBid => Bids.ElementAtOrDefault(ActiveBidIndex);
    public Answer ActiveAnswer => Answers.ElementAtOrDefault(ActiveBidIndex);

    public GameBoard(int _fieldCount, int _fieldColorCount, int _rowCount, List<Color> _fieldColors, List<Color> _fieldBorderColors, List<Color> _answerFieldColors)
    {
        FieldCount = _fieldCount;
        FieldColorCount = _fieldColorCount;
        RowCount = _rowCount;
        FieldColors = _fieldColors;
        FieldBorderColors = _fieldBorderColors;
        AnswerFieldColors = _answerFieldColors;
        Solution = new Row(this, -1);
        for (int i = 0; i < RowCount; i++) Bids.Add(new Row(this, RowCount - i));
        for (int i = 0; i < RowCount; i++) Answers.Add(new Answer(this));
        ActiveBidIndex = RowCount - 1;
    }

    public bool AmIActive(Row _bid) => Bids.ElementAtOrDefault(ActiveBidIndex) == _bid;
    public void NextBid() { ActiveBidIndex -= 1; }
    public void Solved() { IsSolved = true; ActiveBidIndex = -1; }
    public void Failed() { IsFailed = true; ActiveBidIndex = -1; }

    public void NPC(string propertyName) => OnPropertyChanged(propertyName);
}
