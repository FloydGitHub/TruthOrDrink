using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class TwistCardPage : ContentPage
{
    public Game CurrentGame { get; set; }
    public Question QuestionToRedirect { get; set; }
    public Player TwistCardUser { get; set; }
    public User CurrentUser { get; set; }

    public TwistCardPage(Game currentGame, Question questionToRedirect, Player twistCardUser, User user)
	{
        CurrentUser = user;
        InitializeComponent();
        CurrentGame = currentGame;
        QuestionToRedirect = questionToRedirect;
        TwistCardUser = twistCardUser;
        List<Player> playersToRedirect = currentGame.Players.ToList();
        Player playerToRemove = playersToRedirect.FirstOrDefault(player => player.Id == twistCardUser.Id);
        if (playerToRemove != null)
        {
            playersToRedirect.Remove(playerToRemove);
        }
        PlayersCollectionView.ItemsSource = playersToRedirect;
    }
	public void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    public void PlayerButton_Clicked(object sender, EventArgs e)
    {
        TwistCardUser.TwistCard -= 1;
        CurrentGame.UpdatePlayerScore(TwistCardUser);
        Button button = (Button)sender;
        Player player = (Player)button.CommandParameter;
        Navigation.PushAsync(new QuestionPage(CurrentGame, CurrentUser ,QuestionToRedirect, player));
    }
}