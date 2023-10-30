namespace Mastermind.Engine;

public class TacticEngine(AppConfig _appConfig, Random _rand)
{
    public int ActiveBidIndex { get; set; }

    public void ProcessRow(GameBoardVM gb)
    {
        BidVM ActiveBid = gb.Bids.ElementAtOrDefault(ActiveBidIndex);
        AnswerVM ActiveAnswer = gb.Answers.ElementAtOrDefault(ActiveBidIndex);

        int fieldColorCount = _appConfig.ColorCount;
        List<int> usedPositions = [];
        int c = 0;
        foreach (var f in ActiveBid.Fields.Where(x => gb.Solution.Fields[x.Index].Value == x.Value))
        {
            ActiveAnswer.Fields[c++].Value = 2;
            usedPositions.Add(f.Index);
        }

        BidFieldVM i;
        foreach (var f in ActiveBid.Fields.Where(x => gb.Solution.Fields[x.Index].Value != x.Value))
        {
            i = gb.Solution.Fields.Find(y => !usedPositions.Contains(y.Index) && y.Value == f.Value);
            if (i != null)
            {
                ActiveAnswer.Fields[c++].Value = 1;
                usedPositions.Add(i.Index);
            }
        }

        if (ActiveAnswer.Fields.All(x => x.Value == 2)) gb.IsSolved = true;
        if (ActiveBidIndex == 0) gb.IsFailed = true;

        ActiveBidIndex--;
        ActiveBid = gb.Bids.ElementAtOrDefault(ActiveBidIndex);
        if (ActiveBid != null) ActiveBid.IsCurrent = true;
    }

    public void New(GameBoardVM gb)
    {
        gb.Solution ??= new BidVM(_appConfig, false, -1);
        gb.Bids = Enumerable.Range(0, _appConfig.RowCount).Select(i => new BidVM(_appConfig, i == _appConfig.RowCount - 1, _appConfig.RowCount - i)).ToList();
        gb.Answers = Enumerable.Range(0, _appConfig.RowCount).Select(_ => new AnswerVM(_appConfig)).ToList();
        ActiveBidIndex = _appConfig.RowCount - 1;
        gb.IsSolved = gb.IsFailed = false;
        gb.Solution.Fields.ForEach(f => f.Value = _rand.Next(_appConfig.FieldColors.Count));
    }
}
