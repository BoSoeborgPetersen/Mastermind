namespace Mastermind.ViewModel;

[DebuggerDisplay("Value = {Value}")]
public partial class BidFieldVM(AppConfig _appConfig, int _index) : ObservableRecipient
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Color))]
    [NotifyPropertyChangedFor(nameof(BorderColor))]
    int value;

    public SolidColorBrush Color => new(_appConfig.FieldColors[Value]);
    public SolidColorBrush BorderColor => new(_appConfig.BorderColors[Value]);
    public int Index => _index;

    public void Selected() => Messenger.Send(new ShowColorPicker(this));
}