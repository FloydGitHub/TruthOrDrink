namespace TruthOrDrink.Pages.NewGamePages;

public partial class SetRulesPage : ContentPage
{
	public SetRulesPage()
	{
		InitializeComponent();
	}
	private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
	private void AddPlayersPageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddPlayerPage());
    }
}