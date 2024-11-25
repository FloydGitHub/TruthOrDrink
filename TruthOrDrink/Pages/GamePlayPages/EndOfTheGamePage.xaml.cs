namespace TruthOrDrink.Pages.GamePlayPages;

public partial class EndOfTheGamePage : ContentPage
{
	public EndOfTheGamePage()
	{
		InitializeComponent();
	}
	private void BackToMainMenuButton_Clicked(object sender, EventArgs e)
    {
        //Gaat nu naar inlogscherm. moet naar hoofdmenu
        Navigation.PopToRootAsync();
        
    }
}