using TruthOrDrink.Pages.GamePlayPages;

namespace TruthOrDrink.Pages.NewGamePages;

public partial class AddPlayerPage : ContentPage
{
	public AddPlayerPage()
	{
		InitializeComponent();
	}
	private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

	private void StartGameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QuestionPage());
    }
}