using TruthOrDrink.APIInfo;
using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class QuestionPage : ContentPage
{
    public Game currentGame { get; set; }
    public Question? questionToAsk { get; set; }
    public Player playerToAsk { get; set; }
    public User CurrentUser { get; set; }
    // guvenQuestion en pickedPlayer worden alleen gebruikt nadat een twistcard is gespeeld.
    public QuestionPage(Game game, User currentUser, Question? givenQuestion = null, Player? pickedPlayer = null)
    {



        CurrentUser = currentUser;
            
        InitializeComponent();

        currentGame = game;
        if (givenQuestion == null)
        {
            questionToAsk = currentGame.GetNextQuestion();
        }
        else
        {
            questionToAsk = givenQuestion;
        }
        if (questionToAsk == null)
        {
            Navigation.PushAsync(new EndOfTheGamePage("Het spel is afgelopen omadat alle vragen gesteld zijn.", currentGame, CurrentUser));
        }
        else
        {
            if (questionToAsk.PhotoQuestion)
            {
                JokeFrame.IsVisible = false;
            }
            else
            {
                BindingContext = new Joke();
                AddJoke();
            }
            if (pickedPlayer == null)
            {
                playerToAsk = game.GetPlayerToAskQuestion();
            }
            else
            {
                playerToAsk = pickedPlayer;
            }
            if (playerToAsk.TwistCard < 1)
            {
                TwistCardButton.BackgroundColor = Color.FromHex("#808080");
            }
            if (questionToAsk.CategoryId == 3)
            {
                QuestionLabel.Text = $"Opdracht voor {playerToAsk.Name},\n\n{questionToAsk.Text}";
                TruthButton.Text = "Voltooid";
            }
            else
            {
                QuestionLabel.Text = $"Vraag voor {playerToAsk.Name},\n\n{questionToAsk.Text}";
            }
            TwistCardLabel.Text = $"Doorschuivers over: {playerToAsk.TwistCard}";
        }
        Vibration.Default.Vibrate();

    }
	private void TwistCardButton_Clicked(object sender, EventArgs e)
    {
        if (playerToAsk.TwistCard > 0)
        {
            Navigation.PushAsync(new TwistCardPage(currentGame, questionToAsk, playerToAsk, CurrentUser));
        }

    }
	private void TruthButton_Clicked(object sender, EventArgs e)
    {
        playerToAsk.Answers += 1;
        currentGame.UpdatePlayerScore(playerToAsk);
        Navigation.PushAsync(new QuestionPage(currentGame, CurrentUser));
    }

    private void DrinkButton_Clicked(object sender, EventArgs e)
    {
        playerToAsk.Drinks += 1;
        currentGame.UpdatePlayerScore(playerToAsk);
        Navigation.PushAsync(new QuestionPage(currentGame, CurrentUser));
    }
    private void StandingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StandingsPage(currentGame, CurrentUser));
    }
    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to InstructiePage
        return true;
    }
    private async void AddJoke()
    {
        // Fetch the joke asynchronously
        var joke = await JokeLogic.GetRandomJoke();

        // Update the BindingContext with the fetched joke
        BindingContext = joke;
    }
}