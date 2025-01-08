using TruthOrDrink.Models;
using TruthOrDrink.Pages.QuestionCrudPages;
using static System.Net.Mime.MediaTypeNames;
using TruthOrDrink.MVVM.VieuwModels;
using TruthOrDrink.MVVM;
using TruthOrDrink.Pages.BreweryPages;


namespace TruthOrDrink;

public partial class QuestionIndexPage : ContentPage
{
    public User CurrentUser { get; set; }

    public QuestionIndexPage(User currentUser)
    {
        InitializeComponent();
        CurrentUser = currentUser;
        var viewModel = (QuestionIndexViewModel)BindingContext;
        viewModel.CurrentUser = currentUser;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Laad de vragen opnieuw wanneer de pagina verschijnt
        if (BindingContext is QuestionIndexViewModel viewModel)
        {
            viewModel.LoadQuestions();
        }
    }


    private void EditButtonClicked(object sender, EventArgs e)
    {
        // Retrieve the question object from CommandParameter
        var button = sender as Button;
        if (button?.CommandParameter is Question selectedQuestion)
        {

            Navigation.PushAsync(new QuestionEditPage(selectedQuestion, CurrentUser));
        }
    }

    private void DeleteQuestionButton(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.CommandParameter is Question selectedQuestion)
        {

            Navigation.PushAsync(new QuestionDeletePage (selectedQuestion, CurrentUser));
        }
    }

}

