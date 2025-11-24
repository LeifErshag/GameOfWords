# GameOfWords

A starter framework for a Game of Words mobile game built with .NET MAUI. The project provides a lightweight game loop, word bank handling, and a simple UI you can run on Android, iOS, or Mac Catalyst once the MAUI workload is available.

## Project layout
- `GameOfWords.csproj`: MAUI single-project configuration targeting Android, iOS, and Mac Catalyst.
- `MauiProgram.cs`: configures dependency injection and registers game services.
- `App.xaml` / `App.xaml.cs`: application-level resources and startup page selection.
- `Views/MainPage.xaml`: simple UI showing loop controls, next word, and score.
- `Services/`: contains `IGameLoop`, `GameLoop`, `IGameStateService`, and `GameStateService` to manage ticks, state changes, and scoring.
- `Models/`: basic `GameState` and `GameStatus` definitions.
- `Platforms/`: platform-specific startup classes for Android, iOS, and Mac Catalyst.

## Getting started
1. Install the .NET 8 SDK and the .NET MAUI workload on your machine.
2. Restore and build the solution for your desired target (example for Android):
   ```bash
   dotnet restore
   dotnet build -t:Run -f net8.0-android
   ```
3. Extend the `GameLoop` and `GameStateService` with your own word sources, timing rules, and scoring.
4. Replace `Views/MainPage` with richer navigation, game scenes, and visual assets as you iterate.
