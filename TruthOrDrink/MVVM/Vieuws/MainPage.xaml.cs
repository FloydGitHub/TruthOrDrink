using TruthOrDrink.Models;
using TruthOrDrink.Pages;
using CommunityToolkit.Maui.Core;

namespace TruthOrDrink
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            StatusBar.StatusBarColor = Colors.Red;
            StatusBar.StatusBarStyle = StatusBarStyle.LightContent;
            User? LoggedInUser = User.GetLoggedInUser();
            if (LoggedInUser != null)
            {
                Navigation.PushAsync(new HomePage(LoggedInUser));
            }
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isUserEmpthy = string.IsNullOrEmpty(UsernameEntry.Text);
            bool isPasswordEmpthy = string.IsNullOrEmpty(PasswordEntry.Text);

            if (isUserEmpthy)
            { UsernameEntry.Placeholder = "Vul iets in!"; }
            else if (isPasswordEmpthy)
            { PasswordEntry.Placeholder = "Vul iets in!"; }
            else
            {
                User user = User.GetUser(UsernameEntry.Text, PasswordEntry.Text);
                if (user == null)
                {
                    DisplayAlert("Fout", "Gebruikersnaam of wachtwoord is onjuist", "Ok");
                    return;
                }
                user.IsLoggedInUser = true;
                user.AddOrUpdateUser();
                Navigation.PushAsync(new HomePage(user));
            }

        }
        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

    }

}