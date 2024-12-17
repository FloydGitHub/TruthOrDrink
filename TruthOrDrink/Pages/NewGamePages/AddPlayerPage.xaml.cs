using TruthOrDrink.Models;
using TruthOrDrink.Pages.GamePlayPages;

namespace TruthOrDrink.Pages.NewGamePages;

public partial class AddPlayerPage : ContentPage
{
    //is gedaan omdat ik hier  nog geen waarders kan doorgeven met de tabbed ding
    User testUser = new User { Id = 1, Username = "TestUser" };
    public AddPlayerPage()
	{
        InitializeComponent();
	}

	private void StartGameButton_Clicked(object sender, EventArgs e)
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
            Drinks = 0,
            Answers = 0,
        };
        Player player2 = new Player()
        {
            Id = 2,
            Name = "Player 2",
            TwistCard = 3,
            Drinks = 0,
            Answers = 0,
        };
        Game game = new Game()
        {
            Id = 1,
            Categories = new List<Category> { category },
            Players = new List<Player> { player, player2 },
            StartingMoment = DateTime.Now,
            CustomQuestionsAllowed = true,
            LevelOneAllowed = true,
        };

        game.FilterQuestions();

        Navigation.PushAsync(new QuestionPage(game, testUser));
    }
}