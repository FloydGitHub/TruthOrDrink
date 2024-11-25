namespace TruthOrDrink;

public partial class QuestionCreatePage : ContentPage
{
	public QuestionCreatePage()
	{
		InitializeComponent();
	}

	public void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}