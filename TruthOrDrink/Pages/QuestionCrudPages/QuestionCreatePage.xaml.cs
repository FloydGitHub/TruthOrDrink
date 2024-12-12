using TruthOrDrink.Models;

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

    public void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(QuestionEntry.Text) || LevelPicker.SelectedIndex == -1 || CategoryPicker.SelectedIndex == -1)
        {
            return;
        }
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
        Question newQuestion = new Question
        {
            Id = 0,
            Text = QuestionEntry.Text,
            Category = chosenCategory,
            CategoryId = chosenCategory.Id,
            Level = LevelPicker.SelectedIndex + 1,
            CustomQuestion = true,
            PhotoQuestion = false,
        };
        Navigation.PopAsync();
    }
}