namespace Mastermind.View;

public sealed partial class MainWindow : Window
{
    public MainVM VM { get; set; }

    public MainWindow()
    {
        InitializeComponent();
    }
}
