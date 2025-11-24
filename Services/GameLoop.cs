using GameOfWords.Models;
using Microsoft.Maui.Dispatching;

namespace GameOfWords.Services;

public class GameLoop : IGameLoop
{
    private readonly IDispatcherTimer _timer;
    private readonly IGameStateService _stateService;
    private readonly string[] _seedWords = new[] { "orbit", "wander", "puzzle", "quartz", "rhythm" };

    public event EventHandler<GameTickEventArgs>? OnTick;
    public event EventHandler<GameStateChangedEventArgs>? OnStateChanged;

    public GameLoop(IDispatcher dispatcher, IGameStateService stateService)
    {
        _stateService = stateService;
        _stateService.InitializeWordBank(_seedWords);
        _timer = dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(2);
        _timer.Tick += HandleTick;
    }

    public void Start()
    {
        if (_stateService.State.Status == GameStatus.Running)
        {
            return;
        }

        _stateService.State.Status = GameStatus.Running;
        _timer.Start();
        RaiseStateChanged("Game started");
    }

    public void Pause()
    {
        if (_stateService.State.Status != GameStatus.Running)
        {
            return;
        }

        _stateService.State.Status = GameStatus.Paused;
        _timer.Stop();
        RaiseStateChanged("Game paused");
    }

    public void Reset()
    {
        _timer.Stop();
        _stateService.Reset();
        _stateService.InitializeWordBank(_seedWords);
        RaiseStateChanged("Game reset. Ready to start again!");
    }

    private void HandleTick(object? sender, EventArgs e)
    {
        if (_stateService.State.Status != GameStatus.Running)
        {
            return;
        }

        var word = _stateService.NextWord();
        if (string.IsNullOrWhiteSpace(word))
        {
            _timer.Stop();
            RaiseStateChanged("All words used. Nice work!");
            return;
        }

        _stateService.IncrementScore();
        OnTick?.Invoke(this, new GameTickEventArgs(word));
    }

    private void RaiseStateChanged(string message)
    {
        OnStateChanged?.Invoke(this, new GameStateChangedEventArgs(_stateService.State.Status, message));
    }
}
