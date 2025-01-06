using TruthOrDrink.Models;
using TruthOrDrink.Pages.GamePlayPages;

namespace TruthOrDrink.Pages.ContinuGamePages;

public partial class OpenGamesIndexPage : ContentPage
{
    public User CurrentUser { get; set; }
    public OpenGamesIndexPage(User currentUser)
    {
        CurrentUser = currentUser;
        InitializeComponent();

        List<Game> games = Game.GetGamesFromUser(CurrentUser);
        GamesCollectionView.ItemsSource = games;
        CurrentUser = currentUser;
    }
    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.CommandParameter is Game selectedGame)
        {
            Navigation.PushAsync(new DeleteGamePage(selectedGame));
        }
    }

    private void ContinuButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.CommandParameter is Game selectedGame)
        {
            selectedGame.IsSaved = false;
            selectedGame.FilterQuestions();
            Navigation.PushAsync(new QuestionPage(selectedGame, CurrentUser));
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        List<Game> games = Game.GetGamesFromUser(CurrentUser);
        GamesCollectionView.ItemsSource = games;
    }

}