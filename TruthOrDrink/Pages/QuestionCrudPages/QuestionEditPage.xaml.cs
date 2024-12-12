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
        selectedQuestion.Text = QuestionEntry.Text;
        selectedQuestion.Level = LevelPicker.SelectedIndex + 1;
        List<Category> categories = Category.GetCategories();
        Category? chosenCategory = null;
        if (CategoryPicker.SelectedIndex == 0)
        {
            chosenCategory = categories[0];
        }
        else if (CategoryPicker.SelectedIndex == 1)
        {
            chosenCategory = categories[1];
        }
        else if (CategoryPicker.SelectedIndex == 2)
        {
            chosenCategory = categories[2];
        }
        selectedQuestion.Category = chosenCategory;
        Navigation.PopAsync();
    }
}