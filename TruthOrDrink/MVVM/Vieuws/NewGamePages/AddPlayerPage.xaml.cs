using TruthOrDrink.Models;
using TruthOrDrink.Pages.GamePlayPages;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel.Communication;

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
        if (Players.Count < 2)
        {
            PlayerNameEntry.Placeholder = "Voeg minimaal 1 extra speler toe";
            return;
        }
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
        string newPlayerName = PlayerNameEntry.Text;

        bool isNameAlreadyUsed = Players.Any(player => player.Name == newPlayerName);

        if (isNameAlreadyUsed)
        {
            DisplayAlert("Foutmelding", "Je mag niet 2 keer dezelfde naam in een spel gebruiken", "Ok");
            return;
        }
        else if (string.IsNullOrEmpty(newPlayerName))
        {
            PlayerNameEntry.Placeholder = "Naam mag niet leeg zijn";
            return;
        }
        else if (newPlayerName.Length > 20)
        {
            PlayerNameEntry.Text = "";
            PlayerNameEntry.Placeholder = "Naam mag niet langer zijn dan 20 karakters";
            return;
        }
        else
        {
            Player player = new Player
            {
                Name = newPlayerName,
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
                AddPlayerWithContactButton.IsEnabled = false;
                AddPlayerWithContactButton.BackgroundColor = Color.FromHex("#808080");
                AddPlayerWithContactButton.Text = "Maximaal aantal spelers zijn toegevoegd";
            }
        }
    }

    private async void AddPlayerWithContact_Clicked(object sender, EventArgs e)
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();

        if (Permissions.ShouldShowRationale<Permissions.ContactsRead>())
        {
            status = await Permissions.RequestAsync<Permissions.ContactsRead>();
            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Toestemming vereist", "Deze app heeft toegang tot je contacten nodig om een speler te kunnen toevoegen op deze manier.", "OK");
                return;
            }

        }

        //speler toevoegen met contact
        string message = "";
        try
        {
            var contact = await Contacts.Default.PickContactAsync();

            if (contact == null)
            { return; }

            string givenName = contact.GivenName;

            bool isNameAlreadyUsed = Players.Any(player => player.Name == givenName);

            if (isNameAlreadyUsed)
            {
                DisplayAlert("Foutmelding", "Je mag niet 2 keer dezelfde naam in een spel gebruiken", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(givenName))
            {
                DisplayAlert("Error", "De naam van het contact mag niet leeg zijn", "OK");
                return;
            }
            else if (givenName.Length > 20)
            {
                DisplayAlert("Error", "De naam van het contact mag niet langer dan 20 tekens zijn", "OK");
                return;
            }
            else
            {
                Player player = new Player
                {
                    Name = givenName,
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
                    AddPlayerWithContactButton.IsEnabled = false;
                    AddPlayerWithContactButton.BackgroundColor = Color.FromHex("#808080");
                    AddPlayerWithContactButton.Text = "Maximaal aantal spelers zijn toegevoegd";
                }
            }


        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
    }


}