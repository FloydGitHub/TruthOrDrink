namespace TruthOrDrink;

public partial class QuestionIndexPage : ContentPage
{
	public QuestionIndexPage()
	{
		InitializeComponent();
	}
    private void BackButton_Clicked (object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void CreateQuestionPageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QuestionCreatePage());
    }
}