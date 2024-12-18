using TruthOrDrink.APIinfo;
using TruthOrDrink.APIInfo;
using TruthOrDrink.Models;
using TruthOrDrink.Pages.BreweryPages;

namespace TruthOrDrink;

public partial class HomePage : ContentPage
{
    public User CurrentUser { get; set; }
    public HomePage(User currenterUser)
    {
        CurrentUser = currenterUser;
        InitializeComponent();
        string WelcomeMessage = $"Welkom {CurrentUser.Username}";
        Welcome_Label.Text = WelcomeMessage;

    }
    private void QuestionIndexButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QuestionIndexPage(CurrentUser));
    }
    private void ContinuButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Pages.ContinuGamePages.OpenGamesIndexPage(CurrentUser));
    }
    private void NewGameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Pages.NewGamePages.SetRulesPage(CurrentUser));
    }

    private async void OnKaartspelButtonClicked(object sender, EventArgs e)
    {
        // Openen van de externe URL
        await Launcher.OpenAsync("https://www.bol.com/nl/nl/p/truth-or-drink-guilty-pleasures-nederlandstalig-kaartspel/9300000182707032/");
    }

    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to previous page
        return true;
    }

    private void RandomBreweryButton_Clicked(object sender, EventArgs e)
    {

          Navigation.PushAsync(new VieuwBreweryPage());
    }

    private void LogOutButton_Clicked(object sender, EventArgs e)
    {
        CurrentUser.IsLoggedInUser = false;
        App.DBRepository.AddOrUpdateUser(CurrentUser);
        Navigation.PopAsync();
    }
}