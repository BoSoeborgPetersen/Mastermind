namespace Mastermind.ViewModel;

public partial class GameBoardVM : ObservableRecipient, IRecipient<BidConfirmed>
{
    private readonly TacticEngine tacticEngine;

    [ObservableProperty]
    private BidVM solution;
    [ObservableProperty]
    private List<AnswerVM> answers;
    [ObservableProperty]
    private List<BidVM> bids;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GameInProgress))]
    private bool isSolved;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GameInProgress))]
    private bool isFailed;
    public bool GameInProgress => !IsSolved && !IsFailed;

    public GameBoardVM(TacticEngine _tacticEngine)
    {
        tacticEngine = _tacticEngine;

        New();

        IsActive = true;
    }

    public void New() => tacticEngine.New(this);

    public void Receive(BidConfirmed message) => tacticEngine.ProcessRow(this);
}
