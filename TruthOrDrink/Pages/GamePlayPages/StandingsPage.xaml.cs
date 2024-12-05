using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class StandingsPage : ContentPage
{
    Game CurrentGame { get; set; }
    public StandingsPage(Game currentGame)
	{
		InitializeComponent();
        CurrentGame = currentGame;
        BindingContext = CurrentGame;
    }
    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void EndGameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EndOfTheGamePage());
    }
    private void EditRulesButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditRulesPage());
    }
}