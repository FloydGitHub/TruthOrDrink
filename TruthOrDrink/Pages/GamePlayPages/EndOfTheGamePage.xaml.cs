using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class EndOfTheGamePage : ContentPage
{
    public User CurrentUser { get; set; }
    public EndOfTheGamePage(string endOfTheGameMessage, Game game, User currentUser)
    {
        CurrentUser = currentUser;
        InitializeComponent();
        EndGame_Label.Text = endOfTheGameMessage;
        BindingContext = game;
        CurrentUser = currentUser;
    }
    private void BackToMainMenuButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage(CurrentUser));
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}
