using GameOfWords.Services;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace GameOfWords.Views;

public partial class MainPage : ContentPage
{
    private readonly IGameLoop _gameLoop;
    private readonly IGameStateService _gameStateService;

    public MainPage()
    {
        InitializeComponent();
        _gameStateService = ServiceHelper.GetService<IGameStateService>();
        _gameLoop = ServiceHelper.GetService<IGameLoop>();

        _gameLoop.OnTick += HandleGameTick;
        _gameLoop.OnStateChanged += HandleStateChanged;
    }

    private void OnStartClicked(object sender, EventArgs e)
    {
        _gameLoop.Start();
    }

    private void OnPauseClicked(object sender, EventArgs e)
    {
        _gameLoop.Pause();
    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        _gameLoop.Reset();
    }

    private void HandleGameTick(object? sender, GameTickEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            NextWordLabel.Text = e.NextWord;
            ScoreLabel.Text = _gameStateService.State.Score.ToString();
        });
    }

    private void HandleStateChanged(object? sender, GameStateChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            LoopStatus.Text = e.State.ToString();
            StatusLabel.Text = e.Message;
        });
    }
}
