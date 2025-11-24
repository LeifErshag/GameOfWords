using GameOfWords.Models;

namespace GameOfWords.Services;

public interface IGameStateService
{
    GameState State { get; }
    void InitializeWordBank(IEnumerable<string> words);
    string NextWord();
    void IncrementScore(int delta = 1);
    void Reset();
}
