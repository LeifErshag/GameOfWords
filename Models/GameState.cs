namespace GameOfWords.Models;

public enum GameStatus
{
    Idle,
    Running,
    Paused,
    Completed
}

public class GameState
{
    public GameStatus Status { get; set; } = GameStatus.Idle;
    public int Score { get; set; }
    public string CurrentWord { get; set; } = string.Empty;
    public Queue<string> UpcomingWords { get; set; } = new();

    public void Reset()
    {
        Status = GameStatus.Idle;
        Score = 0;
        CurrentWord = string.Empty;
        UpcomingWords.Clear();
    }
}
