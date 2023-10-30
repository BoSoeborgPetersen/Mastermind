namespace Mastermind.ViewModel;

public class ColorPickerFieldVM(int Value, Color _color, Color _borderColor) : ObservableRecipient
{
    public SolidColorBrush Color { get; set; } = new(_color);
    public SolidColorBrush BorderColor { get; set; } = new(_borderColor);

    public void Selected() => Messenger.Send(new ColorPicked(Value));
}
