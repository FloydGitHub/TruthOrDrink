namespace TruthOrDrink;

public partial class HomePage : ContentPage
{
    public HomePage(Entry username)
    {
        InitializeComponent();
        String usernameText = username.Text;
        string WelcomeMessage = $"Welkom {usernameText}";
        Welcome_Label.Text = WelcomeMessage;

    }
    private void QuestionIndexButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QuestionIndexPage());
    }
}