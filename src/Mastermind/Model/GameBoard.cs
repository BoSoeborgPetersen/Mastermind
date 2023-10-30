namespace Mastermind.Model;

public record GameBoard(Solution Solution, List<Bid> Bids, List<Answer> Answers);

public abstract record Row(List<Field> Fields);
public record Solution(List<Field> Fields) : Row(Fields);
public record Bid(List<Field> Fields, int Number) : Row(Fields);
public record Answer(List<Field> Fields, int Number) : Row(Fields);

public record Field(int Value);

