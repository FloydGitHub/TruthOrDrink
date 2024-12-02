namespace TruthOrDrink.Pages.QuestionCrudPages;

public partial class QuestionDeletePage : ContentPage
{
	public QuestionDeletePage()
	{
		InitializeComponent();
	}

	public void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    //logica nog nodig
	public void DeleteButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}