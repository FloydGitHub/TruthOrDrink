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
            return;
        }
        else if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
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
            App.DBRepository.AddUser(newUser);
            Navigation.PopAsync();
        }
    }
    private void BackToLoginButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}