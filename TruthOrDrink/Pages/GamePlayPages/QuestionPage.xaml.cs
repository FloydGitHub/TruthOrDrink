namespace TruthOrDrink.Pages.GamePlayPages;

public partial class QuestionPage : ContentPage
{
	public QuestionPage()
	{
		InitializeComponent();
	}
	private void TwistCardButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TwistCardPage());
    }
	private void TruthButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EndOfTheGamePage());
    }
    private void StandingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StandingsPage());
    }
}