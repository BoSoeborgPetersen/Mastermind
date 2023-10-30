namespace Mastermind.Model;

public class Answer
{
    public GameBoard GameBoard { get; init; }
    public List<AnswerField> Fields { get; init; } = new();

    public Answer(GameBoard _gameBoard)
    {
        GameBoard = _gameBoard;
        for (int i = 0; i < GameBoard.FieldCount; i++) 
            Fields.Add(new AnswerField(this, 0));
    }
}
