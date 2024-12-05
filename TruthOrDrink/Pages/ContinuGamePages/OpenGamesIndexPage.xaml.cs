using TruthOrDrink.Models;
using TruthOrDrink.Pages.GamePlayPages;

namespace TruthOrDrink.Pages.ContinuGamePages;

public partial class OpenGamesIndexPage : ContentPage
{
    public OpenGamesIndexPage()
    {
        InitializeComponent();
        Category category = new Category()
        {
            Id = 1,
            Name = "Category 1",
            Description = "Description 1"
        };
        Player player = new Player()
        {
            Id = 1,
            Name = "Player 1",
            TwistCard = 3,
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
            LevelOneAllowed = true,
        };
        List<Game> games = new List<Game> { game };
        GamesCollectionView.ItemsSource = games;
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
            Question question = new Question()
            {
                Id = 1,
                Text = "Question 1",
                Level = 1,
                Category = new Category()
                {
                    Id = 1,
                    Name = "Category 1",
                    Description = "Description 1"
                }
            };
            Question question2 = new Question()
            {
                Id = 2,
                Level = 2,
                Text = "Question 2",
                Category = new Category()
                {
                    Id = 1,
                    Name = "Category 1",
                    Description = "Description 1"
                }
            };

            //
            List<Question> allQuestions = new List<Question> { question, question2 };
            //filter m oet nog toegepast worden

            selectedGame.QuestionsToAsked = allQuestions;
            Navigation.PushAsync(new QuestionPage(selectedGame));
        }
    }

}