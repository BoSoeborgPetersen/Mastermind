namespace Mastermind.Engine;

public class TacticEngine(AppConfig _appConfig, Random _rand)
{
    public int ActiveBidIndex { get; set; }

    public void ProcessRow(GameBoardVM gb)
    {
        BidVM ActiveBid = gb.Bids.ElementAtOrDefault(ActiveBidIndex);
        AnswerVM ActiveAnswer = gb.Answers.ElementAtOrDefault(ActiveBidIndex);

        List<BidFieldVM> exactIntersect = ActiveBid.Fields.IntersectBy(gb.Solution.Fields.Select(f => new { f.Value, f.Index }), f => new { f.Value, f.Index }).ToList();
        // TODO: Fix bug with duplicate colors being removed during key selection.
        //List<BidFieldVM> intersect = ActiveBid.Fields.Except(exactIntersect).IntersectBy(gb.Solution.Fields.Select(f => f.Value), f => f.Value).ToList();
        var t1 = ActiveBid.Fields.Except(exactIntersect).Select(f => f.Value);
        var t2 = gb.Solution.Fields.Except(exactIntersect).Select(f => f.Value);
        //var intersect = ActiveBid.Fields.Except(exactIntersect).Select(f => f.Value).Union(gb.Solution.Fields.Select(f => f.Value));
        var intersect = t1.Supersect(t2.ToList());
        var answer = exactIntersect.Select(_ => 2).Concat(intersect.Select(_ => 1));
        var i = 0;
        answer.ToList().ForEach(v => ActiveAnswer.Fields[i++].Value = v);

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
