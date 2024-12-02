using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.QuestionCrudPages;

public partial class QuestionEditPage : ContentPage
{
    private Question selectedQuestion;

    public QuestionEditPage(Question question)
    {
        InitializeComponent();
        selectedQuestion = question;
        QuestionEntry.Text = selectedQuestion.Text;
    }

    public void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    public void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(QuestionEntry.Text) || LevelPicker.SelectedIndex == -1 || CategoryPicker.SelectedIndex == -1)
        {
            return;
        }
        Navigation.PopAsync();
    }
}