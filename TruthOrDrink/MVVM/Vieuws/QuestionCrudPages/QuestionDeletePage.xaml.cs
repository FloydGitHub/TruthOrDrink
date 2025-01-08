using TruthOrDrink.Models;
using TruthOrDrink.MVVM.VieuwModels;

namespace TruthOrDrink.Pages.QuestionCrudPages;

public partial class QuestionDeletePage : ContentPage
{
    public Question SelectedQuestion { get; set; }
    public QuestionIndexViewModel ViewModel { get; set; }

    public QuestionDeletePage(Question question, QuestionIndexViewModel viewModel)
    {
        InitializeComponent();
        SelectedQuestion = question;

        // Use SelectedQuestion to populate your UI or perform other logic
        DeleteQuestionLabel.Text = $"Weet je zeker dat je de vraag '{SelectedQuestion.Text}' wilt verwijderen?";
        ViewModel = viewModel;
    }
    public void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    //logica van database nog nodig
	public void DeleteButton_Clicked(object sender, EventArgs e)
    {
        SelectedQuestion.DeleteQuestion();
        ViewModel._questions.Remove(SelectedQuestion);
        Navigation.PopAsync();
    }
}