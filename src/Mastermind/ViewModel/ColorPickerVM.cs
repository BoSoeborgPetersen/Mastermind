namespace Mastermind.ViewModel;

public partial class ColorPickerVM : ObservableRecipient, IRecipient<ShowColorPicker>, IRecipient<ColorPicked>
{
    [ObservableProperty]
    private bool show;
    public List<ColorPickerFieldVM> ColorOptions { get; private set; }

    private BidFieldVM currentBidField;

    public ColorPickerVM(AppConfig appConfig)
    {
        ColorOptions = Enumerable.Range(0, appConfig.ColorCount).Select(i => new ColorPickerFieldVM(i, appConfig.FieldColors[i], appConfig.BorderColors[i])).ToList();

        IsActive = true;
    }

    public void Receive(ShowColorPicker msg) { Show = true; currentBidField = msg.Value; }
    public void Receive(ColorPicked message) { Show = false; currentBidField.Value = message.Value; }
}
