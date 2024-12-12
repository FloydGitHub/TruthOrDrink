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
        Category category = new Category()
        {
            Id = 1,
            Name = "Standaard",
            Description = "Standaard vragen",
        };
        Player player = new Player()
        {
            Id = 1,
            Name = "Player 1",
            TwistCard = 2,
            Drinks = 1,
            Answers = 0,
        };
        Player player2 = new Player()
        {
            Id = 2,
            Name = "Player 2",
            TwistCard = 3,
            Drinks = 0,
            Answers = 1,
        };
        Game game = new Game()
        {
            Id = 1,
            Categories = new List<Category> { category },
            Players = new List<Player> { player, player2 },
            StartingMoment = DateTime.Now,
            LevelOneAllowed = false,
            LevelTwoAllowed = true,
            CustomQuestionsAllowed = true,
        };
        List<Game> games = new List<Game> { game };
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
            selectedGame.FilterQuestions();
            Navigation.PushAsync(new QuestionPage(selectedGame, CurrentUser));
        }
    }

}