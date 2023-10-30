namespace Mastermind.ViewModel;

public class MainVM : ObservableObject
{
    public AppConfig AppConfig { get; private set; }
    public GameBoardVM GameBoard { get; private set; }
    public ChooseColorVM ChooseColor { get; private set; }

    public FieldVM FieldBeingChanged { get; set; }

    public MainVM()
    {
        AppConfig = new AppConfig();
        New();
        ChooseColor = new(AppConfig, this);
    }
    public void New()
    {
        //  TODO: Reset state, by using a data model that can also be serialized.
        GameBoard = new(AppConfig, this, new(AppConfig, new()));
        OnPropertyChanged(nameof(GameBoard));
    }
}
