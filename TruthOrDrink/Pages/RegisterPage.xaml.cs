using TruthOrDrink.Models;

namespace TruthOrDrink.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
	private void RegisterButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text))
            {
                UsernameEntry.Placeholder = "Vul iets in!";

            }
            if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                PasswordEntry.Placeholder = "Vul iets in!";
            }
            return;

        }
        else if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            DisplayAlert("Fout", "Wachtwoorden komen niet overeen", "Ok");
            return;
        }
        else
        {
            User newUser = new User
            {
                Id = 0,
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };
            newUser.AddOrUpdateUser();
            Navigation.PopAsync();
        }
    }
    private void BackToLoginButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}