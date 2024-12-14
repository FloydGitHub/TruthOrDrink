using TruthOrDrink.DatabaseInfo;
using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class EndOfTheGamePage : ContentPage
{
    public User CurrentUser { get; set; }
    public Game Game { get; set; }
    public EndOfTheGamePage(string endOfTheGameMessage, Game game, User currentUser)
    {
        Game = game;
        CurrentUser = currentUser;
        InitializeComponent();
        EndGame_Label.Text = endOfTheGameMessage;
        BindingContext = game;
        CurrentUser = currentUser;
    }
    private void BackToMainMenuButton_Clicked(object sender, EventArgs e)
    {
        App.DBRepository.DeleteGame(Game);
        Navigation.PushAsync(new HomePage(CurrentUser));

    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}
