namespace Mastermind.View;

public sealed partial class GameBoardUC : UserControl
{
    public GameBoardVM VM { get; set; }

    public GameBoardUC()
    {
        InitializeComponent();
    }
}
