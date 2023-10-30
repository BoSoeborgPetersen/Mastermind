namespace Mastermind.ViewModel;

public class ColorFieldViewModel
{
    public Color Color { get; set; }
    public Color BorderColor { get; set; }

    public ColorFieldViewModel(Color _color, Color _borderColor)
    {
        Color = _color;
        BorderColor = _borderColor;
    }
}


