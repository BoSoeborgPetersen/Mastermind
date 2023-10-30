namespace Mastermind.Config;

public class AppConfig
{
    private readonly IConfigurationRoot _configurationRoot;

    public AppConfig()
    {
        _configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Package.Current.InstalledLocation.Path)
            .AddJsonFile("appsettings.json", optional: false).Build();
    }

    public int FieldCount => GetInt();
    public int ColorCount => FieldColors.Count;
    public int RowCount => GetInt();
    public List<Color> FieldColors => GetSectionOfColors();
    public List<Color> BorderColors => GetSectionOfColors();
    public List<Color> AnswerColors => GetSectionOfColors();

    List<Color> GetSectionOfColors([CallerMemberName] string key = "") => _configurationRoot.GetSection(key).Get<List<string>>().ConvertAll(s => s.ToColor());
    int GetInt([CallerMemberName] string key = "") => _configurationRoot.GetValue<int>(key);
}