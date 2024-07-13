namespace Mastermind.Engine;

internal static class LinqExtensions
{
    internal static IEnumerable<T> Supersect<T>(this IEnumerable<T> a, ICollection<T> b) => a.Where(b.Remove);
}
