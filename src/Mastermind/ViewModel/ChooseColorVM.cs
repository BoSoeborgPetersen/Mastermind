namespace Mastermind.ViewModel;

public partial class ChooseColorVM : ObservableObject
{
    public MainVM MainVM { get; private set; }

    [ObservableProperty]
    private bool showChooseColor;
    public List<ColorFieldVM> Colors { get; private set; }

    public ChooseColorVM(AppConfig appConfig, MainVM mainViewModel)
    {
        MainVM = mainViewModel;
        Colors = Enumerable.Range(0, appConfig.ColorCount).Select(i => new ColorFieldVM(this, i, appConfig.FieldColors[i], appConfig.FieldBorderColors[i])).ToList();
    }
}
