namespace Mastermind.ViewModel;

public partial class BidVM(AppConfig appConfig, bool _isCurrent, int _number) : ObservableRecipient
{
    public List<BidFieldVM> Fields { get; init; } = Enumerable.Range(0, appConfig.FieldCount).Select(i => new BidFieldVM(appConfig, i) { IsActive = true }).ToList();
    public int Number { get; init; } = _number;
    [ObservableProperty]
    private bool isCurrent = _isCurrent;

    public void BidConfirmed()
    {
        IsCurrent = false;
        Messenger.Send(new BidConfirmed());
    }
}
