using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class QuestionPage : ContentPage
{
    public Game currentGame { get; set; }
    public Question? questionToAsk { get; set; }
    public Player playerToAsk { get; set; }
    public QuestionPage(Game game)
	{
		InitializeComponent();
        currentGame = game;
        questionToAsk = currentGame.GetNextQuestion();
        if (questionToAsk == null)
        {
            Navigation.PushAsync(new EndOfTheGamePage());
        }
        else
        {
            playerToAsk = game.GetPlayerToAskQuestion();
            QuestionLabel.Text = $"Vraag voor {playerToAsk.Name},\n\n{questionToAsk.Text}.";
            TwistCardLabel.Text = $"Doorschuivers over: {playerToAsk.TwistCard}";
        }

    }
	private void TwistCardButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TwistCardPage());
    }
	private void TruthButton_Clicked(object sender, EventArgs e)
    {
        playerToAsk.Answers = +1;
        currentGame.UpdatePlayerScore(playerToAsk);
        Navigation.PushAsync(new QuestionPage(currentGame));
    }

    private void DrinkButton_Clicked(object sender, EventArgs e)
    {
        playerToAsk.Drinks = +1;
        currentGame.UpdatePlayerScore(playerToAsk);
        Navigation.PushAsync(new QuestionPage(currentGame));
    }
    private void StandingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StandingsPage(currentGame));
    }
}