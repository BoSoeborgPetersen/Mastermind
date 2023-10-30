namespace Mastermind.ViewModel;

public class ColorFieldVM
{
    public ChooseColorVM ChooseColorVM { get; set; }

    public int Value { get; set; }
    public Color Color { get; set; }
    public Color BorderColor { get; set; }

    public ICommand FieldColorSelectedCommand { get; private set; }

    public ColorFieldVM(ChooseColorVM _chooseColorVM, int _value, Color _color, Color _borderColor)
    {
        ChooseColorVM = _chooseColorVM;
        Value = _value;
        Color = _color;
        BorderColor = _borderColor;
        FieldColorSelectedCommand = new RelayCommand(FieldColorSelected);
    }

    public void FieldColorSelected()
    {
        ChooseColorVM.MainVM.FieldBeingChanged.Value = Value;
        ChooseColorVM.MainVM.FieldBeingChanged = null;
        ChooseColorVM.ShowChooseColor = false;
    }
}


