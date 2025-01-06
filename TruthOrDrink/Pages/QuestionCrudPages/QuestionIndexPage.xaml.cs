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
        List<Question> questionsFromUser = Question.GetQuestionsFromUser(CurrentUser.Id);

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
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Haal de meest recente data op van de gebruiker uit de database
        List<Question> questionsFromUser = Question.GetQuestionsFromUser(CurrentUser.Id);

        // Update de ItemsSource van de CollectionView
        QuestionsCollectionView.ItemsSource = questionsFromUser;
    }


}