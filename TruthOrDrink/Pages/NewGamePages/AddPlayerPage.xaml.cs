using TruthOrDrink.Models;
using TruthOrDrink.Pages.GamePlayPages;

namespace TruthOrDrink.Pages.NewGamePages;

public partial class AddPlayerPage : ContentPage
{
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
            LevelOneAllowed = true,
        };
        //Liefste een functie zoals dit op een gegeven moment
        //game.QuestionsToAsked = game.GetQuestions();

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

        List<Question> allQuestions = new List<Question> { question, question2 };
        game.QuestionsToAsked = allQuestions;
        Navigation.PushAsync(new QuestionPage(game));
    }
}