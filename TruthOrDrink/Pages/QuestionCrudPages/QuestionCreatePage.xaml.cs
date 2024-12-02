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

        Question newQuestion = new Question
        {
            Text = QuestionEntry.Text,
            Level = LevelPicker.SelectedIndex + 1,
            CustomQuestion = true,
            PhotoQuestion = false,
        };
        Navigation.PopAsync();
    }
}