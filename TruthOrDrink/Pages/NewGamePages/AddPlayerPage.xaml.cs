using TruthOrDrink.Pages.GamePlayPages;

namespace TruthOrDrink.Pages.NewGamePages;

public partial class AddPlayerPage : ContentPage
{
	public AddPlayerPage()
	{
		InitializeComponent();
	}

	private void StartGameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QuestionPage());
    }
}