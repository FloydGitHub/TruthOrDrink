namespace TruthOrDrink.Pages.GamePlayPages;

public partial class StandingsPage : ContentPage
{
	public StandingsPage()
	{
		InitializeComponent();

	}
    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void EndGameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
    private void EditRulesButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditRulesPage());
    }
}