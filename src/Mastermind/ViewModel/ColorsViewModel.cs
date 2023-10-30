namespace Mastermind.ViewModel;

public class ColorsViewModel : BaseViewModel
{
    private MainViewModel _mainViewModel;

    public bool Visibility { get; init; }
    public List<ColorFieldViewModel> ColorFields { get; init; }

    public ColorsViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
        Visibility = true;
        ColorFields = Enumerable.Range(0, FieldColorCount).Select(x => new ColorFieldViewModel(FieldColors.ElementAt(x), FieldBorderColors.ElementAt(x))).ToList();
    }
}
