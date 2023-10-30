namespace Mastermind.ViewModel.Messages;

public class ColorPicked(int value) : ValueChangedMessage<int>(value);
