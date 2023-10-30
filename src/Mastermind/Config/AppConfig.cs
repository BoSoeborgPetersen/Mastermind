namespace Mastermind.Config;

public class AppConfig
{
    private readonly IConfigurationRoot _configurationRoot;

    public AppConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Package.Current.InstalledLocation.Path)
            .AddJsonFile("appsettings.json", optional: false);

        _configurationRoot = builder.Build();
    }

    public int FieldCount => GetInt(nameof(FieldCount));
    public int ColorCount => FieldColors.Count;
    public int RowCount => GetInt(nameof(RowCount));
    public List<Color> FieldColors => GetSectionOfColors(nameof(FieldColors));
    public List<Color> FieldBorderColors => GetSectionOfColors(nameof(FieldBorderColors));
    public List<Color> AnswerFieldColors => GetSectionOfColors(nameof(AnswerFieldColors));

    private List<Color> GetSectionOfColors(string key) => _configurationRoot.GetSection(key).Get<List<string>>().Select(c => c.ToColor()).ToList();
    private int GetInt(string key) => _configurationRoot.GetValue<int>(key);
}