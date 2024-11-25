namespace TruthOrDrink.Pages.GamePlayPages;

public partial class EditRulesPage : ContentPage
{
	public EditRulesPage()
	{
		InitializeComponent();
	}
	public void SafeButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}