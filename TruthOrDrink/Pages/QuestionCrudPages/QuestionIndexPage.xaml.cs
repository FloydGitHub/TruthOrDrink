using TruthOrDrink.Models;
using TruthOrDrink.Pages.QuestionCrudPages;
using static System.Net.Mime.MediaTypeNames;

namespace TruthOrDrink;

public partial class QuestionIndexPage : ContentPage
{
    public QuestionIndexPage()
    {
        InitializeComponent();
        List<Question> questions = new List<Question>();
        Category category = new Category()
        {
            Name = "Persoonlijk",
            Description = "Vragen die je persoonlijk raken",
        };

        Question question = new Question()
        {
            Id = 1,
            Text = "Hoe heet je?",
            Category = category,
            Level = 2,
            CustomQuestion = true,
            PhotoQuestion = false,
        };
        Question question2 = new Question()
        {
            Id = 2,
            Text = "Wat is je favoriete kleur?",
            Category = category,
            Level = 1,
            CustomQuestion = true,
            PhotoQuestion = false,
        };

        questions.Add(question);
        questions.Add(question2);
        QuestionsCollectionView.ItemsSource = questions;
    }
    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void CreateQuestionPageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QuestionCreatePage());
    }
    private void DeleteQuestionButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.CommandParameter is Question selectedQuestion)
        {
            Navigation.PushAsync(new QuestionDeletePage(selectedQuestion));
        }
    }
    private void EditQuestionButton_Clicked(object sender, EventArgs e)
    {
        // Retrieve the question object from CommandParameter
        var button = sender as Button;
        if (button?.CommandParameter is Question selectedQuestion)
        {
            
            Navigation.PushAsync(new QuestionEditPage(selectedQuestion));
        }
    }


}