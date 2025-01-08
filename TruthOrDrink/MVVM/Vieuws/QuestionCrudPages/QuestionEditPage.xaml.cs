using AndroidX.Lifecycle;
using TruthOrDrink.Models;
using TruthOrDrink.MVVM.VieuwModels;

namespace TruthOrDrink.Pages.QuestionCrudPages;

public partial class QuestionEditPage : ContentPage
{
    private Question SelectedQuestion;
    public User CurrentUser { get; set; }
    public QuestionIndexViewModel ViewModelToEdit { get; set; }
    public QuestionEditPage(Question question, User currentUser, QuestionIndexViewModel viewModel)
    {
        InitializeComponent();
        SelectedQuestion = question;
        QuestionEntry.Text = SelectedQuestion.Text;
        CurrentUser = currentUser;
        ViewModelToEdit = viewModel;
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
        int indexToEdit = ViewModelToEdit._questions.IndexOf(SelectedQuestion);
        SelectedQuestion.Text = QuestionEntry.Text;
        SelectedQuestion.Level = LevelPicker.SelectedIndex + 1;
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
        SelectedQuestion.Category = chosenCategory;
        SelectedQuestion.CategoryId = chosenCategory.Id;
        SelectedQuestion.AddOrUpdateQuestion();
        ViewModelToEdit._questions[indexToEdit] = SelectedQuestion;
        Navigation.PopAsync();
    }
}