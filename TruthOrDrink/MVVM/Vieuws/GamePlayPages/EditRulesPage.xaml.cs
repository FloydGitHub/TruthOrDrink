using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.GamePlayPages;

public partial class EditRulesPage : ContentPage
{
    public User CurrentUser { get; set; }
    public Game CurrentGame { get; set; }
    public EditRulesPage(Game currentGame, User currentUser)
	{
        CurrentUser = currentUser;
        InitializeComponent();
        CurrentGame = currentGame;
        CheckBoxLevel1.IsChecked = true;
        CheckBoxCategoryStandaard.IsChecked = true;
        CheckBoxCustom.IsChecked = true;
    }

    //Slaat Game settings op
    //Slaat Categorie nog niet op
    //Past de vragen nog niet aan
	public void SafeButton_Clicked(object sender, EventArgs e)
    {
        //levels
        if (CheckBoxLevel1.IsChecked)
        {
            CurrentGame.LevelOneAllowed = true;
        }
        else
        {
            CurrentGame.LevelOneAllowed = false;
        }
        if (CheckBoxLevel2.IsChecked)
        {
            CurrentGame.LevelTwoAllowed = true;
        }
        else
        {
            CurrentGame.LevelTwoAllowed = false;
        }
        if (CheckBoxLevel3.IsChecked)
        {
            CurrentGame.LevelThreeAllowed = true;
        }
        else
        {
            CurrentGame.LevelThreeAllowed = false;
        }
        if (CheckBoxLevel4.IsChecked)
        {
            CurrentGame.LevelFourAllowed = true;
        }
        else
        {
            CurrentGame.LevelFourAllowed = false;
        }
        if (CheckBoxLevel5.IsChecked)
        {
            CurrentGame.LevelFiveAllowed = true;
        }
        else
        {
            CurrentGame.LevelFiveAllowed = false;
        }
        // catogorieen
        List<Category> categories = Category.GetCategories();
        if (CheckBoxCategoryStandaard.IsChecked)
        {
            CurrentGame.Categories.Add(categories[0]);
        }
        if (CheckBoxCategorySpicy.IsChecked)
        {
            CurrentGame.Categories.Add(categories[1]);
        }
        if (CheckBoxCategorySpecial.IsChecked)
        {
            CurrentGame.Categories.Add(categories[2]);
        }
        //Custom/standaard vragen
        if (CheckBoxCustom.IsChecked)
        {
            CurrentGame.CustomQuestionsAllowed = true;
        }
        else
        {
            CurrentGame.CustomQuestionsAllowed = false;
        }
        if (CheckBoxStandard.IsChecked)
        {
            CurrentGame.StandardQuestionsAllowed = true;
        }
        else
        {
            CurrentGame.StandardQuestionsAllowed = false;
        }
        CurrentGame.FilterQuestions();
        Navigation.PushAsync(new QuestionPage(CurrentGame, CurrentUser));
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
        bool isAnyChecked = CheckBoxCategoryStandaard.IsChecked || CheckBoxCategorySpicy.IsChecked ||
                            CheckBoxCategorySpecial.IsChecked;

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