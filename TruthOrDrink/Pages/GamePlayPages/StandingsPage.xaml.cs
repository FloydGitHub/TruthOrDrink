using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class StandingsPage : ContentPage
{
    public User CurrentUser { get; set; }
    Game CurrentGame { get; set; }
    public StandingsPage(Game currentGame, User currentUser)
	{
        CurrentUser = currentUser;
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
        Navigation.PushAsync(new EndOfTheGamePage("Het spel is afgelopen omadat het handmatig is beëindigd.", CurrentGame, CurrentUser));
    }
    private void EditRulesButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditRulesPage(CurrentGame, CurrentUser));
    }
    private void SaveGameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage(CurrentUser));
    }
}