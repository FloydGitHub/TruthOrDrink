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
                CameraButton.IsVisible = true;
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

        return true;
    }
    private async void AddJoke()
    {
        // Controleer op internetverbinding
        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            var joke = await JokeLogic.GetRandomJoke();
            BindingContext = joke;
        }
        else
        {
            JokeFrame.IsVisible = false;
        }
    }


    private async void CameraButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Controleer de machtigingen voor toegang tot de camera. Vraagt erom als deze er nog niet is
            PermissionStatus cameraStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (Permissions.ShouldShowRationale<Permissions.Camera>())
            {
                cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
                if (cameraStatus != PermissionStatus.Granted)
                {
                    await DisplayAlert("Toestemming vereist", "Deze app heeft toegang tot de camera nodig om een foto te maken.", "OK");
                    return;
                }
            }

            // Controleer de machtigingen voor toegang tot externe opslag. Vraagt erom als deze er nog niet is
            PermissionStatus storageStatus = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (Permissions.ShouldShowRationale<Permissions.StorageWrite>())
            {
                storageStatus = await Permissions.RequestAsync<Permissions.StorageWrite>();
                if (storageStatus != PermissionStatus.Granted)
                {
                    await DisplayAlert("Toestemming vereist", "Deze app heeft toegang tot externe opslag nodig om de foto op te slaan.", "OK");
                    return;
                }
            }

            // Controleer of de camera beschikbaar is
            if (MediaPicker.Default.IsCaptureSupported)
            {
                // Open de camera om een foto te maken
                var photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();

                    // Zet de stream om naar een ImageSource om weer te geven
                    var imageSource = ImageSource.FromStream(() => stream);

                    MadeImage.IsVisible = true;
                    MadeImage.Source = imageSource;
                }
            }
            else
            {
                await DisplayAlert("Fout", "Camera niet beschikbaar op dit apparaat.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", $"Er is iets misgegaan: {ex.Message}", "OK");
        }
    }


}
