using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.ContinuGamePages;

public partial class DeleteGamePage : ContentPage
{
    public Game SelectedGame { get; set; }
    public DeleteGamePage(Game game)
	{
		InitializeComponent();
        SelectedGame = game;
        DeleteGameLabel.Text = $"Weet je zeker dat je het spel van {SelectedGame.StartingMoment} wilt verwijderen?";
    }
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        SelectedGame.DeleteGame();
        Navigation.PopAsync();
    }
    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}