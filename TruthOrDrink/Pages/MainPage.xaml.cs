using TruthOrDrink.Models;
using TruthOrDrink.Pages;

namespace TruthOrDrink
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            StatusBar.StatusBarColor = Colors.Red;
            StatusBar.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent;
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
                User user = App.DBRepository.GetUser(UsernameEntry.Text, PasswordEntry.Text);
                if (user == null)
                {
                    DisplayAlert("Fout", "Gebruikersnaam of wachtwoord is onjuist", "Ok");
                    return;
                }
                Navigation.PushAsync(new HomePage(user));
            }

        }
        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

    }

}