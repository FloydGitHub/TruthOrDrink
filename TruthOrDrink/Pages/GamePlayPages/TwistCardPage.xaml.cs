namespace TruthOrDrink.Pages.GamePlayPages;

public partial class TwistCardPage : ContentPage
{
	public TwistCardPage()
	{
		InitializeComponent();
	}
	public void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}