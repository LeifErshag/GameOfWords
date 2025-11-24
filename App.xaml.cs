using GameOfWords.Views;
using Microsoft.Maui.Controls;

namespace GameOfWords;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new MainPage();
    }
}
