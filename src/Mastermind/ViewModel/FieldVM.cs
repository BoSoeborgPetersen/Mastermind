namespace Mastermind.ViewModel;

public partial class FieldVM : ObservableObject
{
    readonly AppConfig appConfig;
    public RowVM Row { get; init; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FieldAsColor))]
    [NotifyPropertyChangedFor(nameof(FieldAsBorderColor))]
    private int value;


    public Color FieldAsColor => appConfig.FieldColors[Value];
    public Color FieldAsBorderColor => appConfig.FieldBorderColors[Value];
    public int Index => Row.MyFieldIndex(this);
    public ICommand FieldSelectedCommand { get; private set; }

    public FieldVM(AppConfig _appConfig, RowVM _row, int _value)
    {
        appConfig = _appConfig;
        Row = _row;
        Value = _value;
        FieldSelectedCommand = new RelayCommand(FieldSelected);
    }

    public void FieldSelected()
    {
        Row.GameBoard.MainVM.ChooseColor.ShowChooseColor = true;
        //AreColorsVisible = true;
        //OnPropertyChanged(nameof(AreColorsVisible));
        Row.GameBoard.MainVM.FieldBeingChanged = this;
        //FieldBeingChanged = _field;
    }
}