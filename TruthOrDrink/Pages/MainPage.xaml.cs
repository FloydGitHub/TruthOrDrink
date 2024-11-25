namespace TruthOrDrink
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
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
                Navigation.PushAsync(new HomePage(UsernameEntry));
            }

        }
    }

}