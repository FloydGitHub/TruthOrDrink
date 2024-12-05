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
    private async void BackToMainMenuButton_Clicked(object sender, EventArgs e)
    {
        //Gaat nu naar inlogscherm. moet naar hoofdmenu
        await Navigation.PopToRootAsync();
        /*
        var homePage = Navigation.NavigationStack.First(p => p.GetType() == typeof(HomePage));
        if (homePage != null)
        {
            await Navigation.PushAsync(homePage);
            return;
        }
        else
        {
            await Navigation.PopToRootAsync();
            return;
        }
        */
    }
}
