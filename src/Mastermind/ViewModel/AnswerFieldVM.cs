﻿namespace Mastermind.ViewModel;

[DebuggerDisplay("Value = {Value}")]
public partial class AnswerFieldVM(AppConfig _appConfig) : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Color))]
    [NotifyPropertyChangedFor(nameof(BorderColor))]
    int value;

    public SolidColorBrush Color => new(_appConfig.AnswerColors[Value]);
    public SolidColorBrush BorderColor => new(_appConfig.BorderColors[Value]);
}
