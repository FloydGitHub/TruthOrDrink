using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class QuestionPage : ContentPage
{
    public Game currentGame { get; set; }
    public Question? questionToAsk { get; set; }
    public Player playerToAsk { get; set; }
    // guvenQuestion en pickedPlayer worden alleen gebruikt nadat een twistcard is gespeeld.
    public QuestionPage(Game game, Question? givenQuestion = null, Player? pickedPlayer = null)
    {
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
            Navigation.PushAsync(new EndOfTheGamePage("Het spel is afgelopen omadat alle vragen gesteld zijn.", currentGame));
        }
        else
        {
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
            QuestionLabel.Text = $"Vraag voor {playerToAsk.Name},\n\n{questionToAsk.Text}.";
            TwistCardLabel.Text = $"Doorschuivers over: {playerToAsk.TwistCard}";
        }

    }
	private void TwistCardButton_Clicked(object sender, EventArgs e)
    {
        if (playerToAsk.TwistCard > 0)
        {
            Navigation.PushAsync(new TwistCardPage(currentGame, questionToAsk, playerToAsk));
        }

    }
	private void TruthButton_Clicked(object sender, EventArgs e)
    {
        playerToAsk.Answers += 1;
        currentGame.UpdatePlayerScore(playerToAsk);
        Navigation.PushAsync(new QuestionPage(currentGame));
    }

    private void DrinkButton_Clicked(object sender, EventArgs e)
    {
        playerToAsk.Drinks += 1;
        currentGame.UpdatePlayerScore(playerToAsk);
        Navigation.PushAsync(new QuestionPage(currentGame));
    }
    private void StandingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StandingsPage(currentGame));
    }
    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to InstructiePage
        return true;
    }
}