namespace Mastermind;

public partial class App : Application
{
    public App()
    {
        IoC();
        InitializeComponent();
    }

    private static void IoC() => Ioc.Default.ConfigureServices(
            new ServiceCollection()
                .AddSingleton<AppConfig>()
                .AddSingleton<Random>()
                .AddSingleton<TacticEngine>()
                .AddTransient<MainVM>()
                .AddTransient<GameBoardVM>()
                .AddTransient<BidVM>()
                .AddTransient<BidFieldVM>()
                .AddTransient<AnswerVM>()
                .AddTransient<AnswerFieldVM>()
                .AddTransient<ColorPickerVM>()
                .AddTransient<ColorPickerFieldVM>()
                .BuildServiceProvider());

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow()
        {
            VM = Ioc.Default.GetService<MainVM>()
        };
        m_window.Activate();
    }

    private Window m_window;
}
