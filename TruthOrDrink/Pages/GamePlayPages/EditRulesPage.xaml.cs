using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class EditRulesPage : ContentPage
{
    public Game CurrentGame;
    public EditRulesPage(Game currentGame)
	{
		InitializeComponent();
        CurrentGame = currentGame;
        CheckBoxLevel1.IsChecked = true;
        CheckBoxCategory1.IsChecked = true;
        CheckBoxCustom.IsChecked = true;
    }

    //Slaat Game settings op
    //Slaat Categorie nog niet op
    //Past de vragen nog niet aan
	public void SafeButton_Clicked(object sender, EventArgs e)
    {
        if (CheckBoxLevel1.IsChecked)
        {
            CurrentGame.LevelOneAllowed = true;
        }
        if (CheckBoxLevel2.IsChecked)
        {
            CurrentGame.LevelTwoAllowed = true;
        }
        if (CheckBoxLevel3.IsChecked)
        {
            CurrentGame.LevelThreeAllowed = true;
        }
        if (CheckBoxLevel4.IsChecked)
        {
            CurrentGame.LevelFourAllowed = true;
        }
        if (CheckBoxLevel5.IsChecked)
        {
            CurrentGame.LevelFiveAllowed = true;
        }
        if (CheckBoxCustom.IsChecked)
        {
            CurrentGame.CustomQuestionsAllowed = true;
        }
        if (CheckBoxStandard.IsChecked)
        {
            CurrentGame.StandardQuestionsAllowed = true;
        }
        //CurrentGame.FilterQuestions();
        Navigation.PushAsync(new QuestionPage(CurrentGame));
    }
	public void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void OnLevelCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        bool isAnyChecked = CheckBoxLevel1.IsChecked || CheckBoxLevel2.IsChecked ||
                            CheckBoxLevel3.IsChecked || CheckBoxLevel4.IsChecked ||
                            CheckBoxLevel5.IsChecked;

        if (!isAnyChecked && sender is CheckBox currentCheckbox)
        {
            currentCheckbox.IsChecked = true;
        }
    }

    private void OnCategoryCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        bool isAnyChecked = CheckBoxCategory1.IsChecked || CheckBoxCategory2.IsChecked ||
                            CheckBoxCategory3.IsChecked;

        if (!isAnyChecked && sender is CheckBox currentCheckbox)
        {
            currentCheckbox.IsChecked = true;
        }
    }
    private void OnCustomCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        bool isAnyChecked = CheckBoxCustom.IsChecked || CheckBoxStandard.IsChecked;

        if (!isAnyChecked && sender is CheckBox currentCheckbox)
        {
            currentCheckbox.IsChecked = true;
        }
    }
}