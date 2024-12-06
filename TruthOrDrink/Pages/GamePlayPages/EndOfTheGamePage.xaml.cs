using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class EndOfTheGamePage : ContentPage
{
    public EndOfTheGamePage(string endOfTheGameMessage, Game game)
    {
        InitializeComponent();
        EndGame_Label.Text = endOfTheGameMessage;
        BindingContext = game;
    }
    private void BackToMainMenuButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage("Terug"));
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}
