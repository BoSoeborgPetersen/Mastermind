namespace Mastermind.ViewModel;

public class MainVM(GameBoardVM _gameBoard, ColorPickerVM _colorPicker) : ObservableObject
{
    public GameBoardVM GameBoard { get; } = _gameBoard;
    public ColorPickerVM ColorPicker { get; } = _colorPicker;
}
