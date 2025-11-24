using GameOfWords.Models;

namespace GameOfWords.Services;

public interface IGameLoop
{
    event EventHandler<GameTickEventArgs> OnTick;
    event EventHandler<GameStateChangedEventArgs> OnStateChanged;

    void Start();
    void Pause();
    void Reset();
}

public record GameTickEventArgs(string NextWord) : EventArgs;
public record GameStateChangedEventArgs(GameStatus State, string Message) : EventArgs;
