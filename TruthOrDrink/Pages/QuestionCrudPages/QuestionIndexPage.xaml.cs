using TruthOrDrink.Models;
using TruthOrDrink.Pages.QuestionCrudPages;
using static System.Net.Mime.MediaTypeNames;

namespace TruthOrDrink;

public partial class QuestionIndexPage : ContentPage
{
    public User CurrentUser { get; set; }
    public QuestionIndexPage(User currentUser)
    {
        InitializeComponent();
        CurrentUser = currentUser;
        List<Question> questionsFromUser = App.DBRepository.GetQuestionsFromUser(CurrentUser.Id);

        QuestionsCollectionView.ItemsSource = questionsFromUser;
    }
    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void CreateQuestionPageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QuestionCreatePage(CurrentUser));
    }
    private void DeleteQuestionButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.CommandParameter is Question selectedQuestion)
        {
            Navigation.PushAsync(new QuestionDeletePage(selectedQuestion, CurrentUser));
        }
    }
    private void EditQuestionButton_Clicked(object sender, EventArgs e)
    {
        // Retrieve the question object from CommandParameter
        var button = sender as Button;
        if (button?.CommandParameter is Question selectedQuestion)
        {
            
            Navigation.PushAsync(new QuestionEditPage(selectedQuestion, CurrentUser));
        }
    }


}