namespace Mastermind.ViewModel;

public class GameBoardVM : ObservableObject
{
    public MainVM MainVM { get; private set; }
    private readonly TacticEngine tacticEngine;

    // ---------------------------------------

    public RowVM Solution { get; init; }
    public List<RowVM> Bids { get; init; } = new();
    public List<AnswerVM> Answers { get; init; } = new();

    // ---------------------------------------

    public int ActiveBidIndex { get; private set; }
    public bool IsSolved { get; private set; }
    public bool IsFailed { get; private set; }
    public bool GameInProgress => false; //!IsSolved && !IsFailed;

    public RowVM ActiveBid => Bids.ElementAtOrDefault(ActiveBidIndex);
    public AnswerVM ActiveAnswer => Answers.ElementAtOrDefault(ActiveBidIndex);

    // ---------------------------------------

    public ICommand NewCommand { get; private set; }

    public GameBoardVM(AppConfig appConfig, MainVM mainViewModel, TacticEngine engine)
    {
        MainVM = mainViewModel;
        tacticEngine = engine;
        NewCommand = new RelayCommand(New);

        Solution = new RowVM(appConfig, this, -1);
        for (int i = 0; i < appConfig.RowCount; i++) Bids.Add(new RowVM(appConfig, this, appConfig.RowCount - i));
        for (int i = 0; i < appConfig.RowCount; i++) Answers.Add(new AnswerVM(appConfig, this));
        ActiveBidIndex = appConfig.RowCount - 1;

        tacticEngine.CreateSolution(this);
    }

    public bool AmIActive(RowVM _bid) => Bids.ElementAtOrDefault(ActiveBidIndex) == _bid;
    public void NextBid() { ActiveBidIndex -= 1; }
    public void Solved() { IsSolved = true; ActiveBidIndex = -1; }
    public void Failed() { IsFailed = true; ActiveBidIndex = -1; }

    public void NPC(string propertyName) => OnPropertyChanged(propertyName);

    public void New()
    {
        //  TODO: Reset state, by using a data model that can also be serialized.
        MainVM.New();
        //OnPropertyChanged(nameof(GameBoard));
    }

    public void BidConfirmed(RowVM _row)
    {
        tacticEngine.SolveRow(this);
        NextBid();
        _row.NPC("IsActive");
        ActiveBid?.NPC("IsActive");
        NPC(nameof(GameInProgress));
        NPC(nameof(IsSolved));
        NPC(nameof(IsFailed));
    }
}
