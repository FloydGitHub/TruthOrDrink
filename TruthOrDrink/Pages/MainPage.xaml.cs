using TruthOrDrink.Models;

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
                User user = App.DBRepository.GetOrAddUser(UsernameEntry.Text, PasswordEntry.Text);
                Navigation.PushAsync(new HomePage(user));
            }

        }
    }

}