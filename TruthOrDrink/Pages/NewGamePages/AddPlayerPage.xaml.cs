using TruthOrDrink.Models;
using TruthOrDrink.Pages.GamePlayPages;
using Microsoft.Maui.Controls;

namespace TruthOrDrink.Pages.NewGamePages;

public partial class AddPlayerPage : ContentPage
{

    public User CurrentUser { get; set; }
    public Game NewGame { get; set; }
    public List<Player> Players { get; set; }
    public AddPlayerPage(User user, Game game)
	{
        CurrentUser = user;
        NewGame = game;
        InitializeComponent();
        Player Host = new Player
        {
            Name = CurrentUser.Username,
            UserId = CurrentUser.Id,
            IsHost = true,
            Answers = 0,
            Drinks = 0,
            TwistCard = 3
        };

        Players = new List<Player>
        {
            Host
        };
        PlayerListView.ItemsSource = Players;
    }

	private void StartGameButton_Clicked(object sender, EventArgs e)
    {
        NewGame.SetPlayers(Players);
        NewGame.SetStartingMoment();

        Navigation.PushAsync(new QuestionPage(NewGame, CurrentUser));

    }
    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void AddPlayerButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(PlayerNameEntry.Text))
        {
            PlayerNameEntry.Placeholder = "Naam mag niet leeg zijn";
            return;
        }
        else if (PlayerNameEntry.Text.Length > 20)
        {
            PlayerNameEntry.Text = "";
            PlayerNameEntry.Placeholder = "Naam mag niet langer zijn dan 20 karakters";
            return;
        }
        else
        {
            Player player = new Player
            {
                Name = PlayerNameEntry.Text,
                IsHost = false,
                Answers = 0,
                Drinks = 0,
                TwistCard = 3
            };
            Players.Add(player);
            PlayerListView.ItemsSource = null; // Herbind de lijst om de UI bij te werken
            PlayerListView.ItemsSource = Players;

            PlayerNameEntry.Text = "";
            if (Players.Count == 4)
            {
                AddPlayerButton.IsEnabled = false;
                AddPlayerButton.Text = "Maximaal aantal spelers zijn toegevoegd";
                AddPlayerButton.BackgroundColor = Color.FromHex("#808080");
            }
        }
    }
}