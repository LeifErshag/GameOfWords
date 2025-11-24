using GameOfWords.Models;

namespace GameOfWords.Services;

public class GameStateService : IGameStateService
{
    private readonly Random _random = new();

    public GameState State { get; } = new();

    public void InitializeWordBank(IEnumerable<string> words)
    {
        var shuffled = words.OrderBy(_ => _random.Next()).ToList();
        foreach (var word in shuffled)
        {
            State.UpcomingWords.Enqueue(word);
        }
    }

    public string NextWord()
    {
        if (!State.UpcomingWords.TryDequeue(out var next))
        {
            State.Status = GameStatus.Completed;
            return "";
        }

        State.CurrentWord = next;
        return next;
    }

    public void IncrementScore(int delta = 1)
    {
        State.Score += delta;
    }

    public void Reset()
    {
        State.Reset();
    }
}
