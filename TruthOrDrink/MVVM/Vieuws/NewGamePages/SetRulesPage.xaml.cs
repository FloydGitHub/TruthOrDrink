using TruthOrDrink.Models;

namespace TruthOrDrink.Pages.NewGamePages;

public partial class SetRulesPage : ContentPage
{
    public User CurrentUser { get; set; }
    public SetRulesPage(User user)
    {
        CurrentUser = user;
        InitializeComponent();
        CheckBoxLevel1.IsChecked = true;
        CheckBoxCategoryStandaard.IsChecked = true;
        CheckBoxCustom.IsChecked = true;
    }
    private void BackButton_Clicked(object sender, EventArgs e)
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
    private void BackkButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void ContinueButton_Clicked(object sender, EventArgs e)
    {
        Game Newgame = new Game
        {
            Id = 0,
            Categories = new List<Category>(),
        };
        if (CheckBoxCustom.IsChecked)
        {
            Newgame.CustomQuestionsAllowed = true;
        }
        if (CheckBoxStandard.IsChecked)
        {
            Newgame.StandardQuestionsAllowed = true;
        }
        if (CheckBoxLevel1.IsChecked)
        {
            Newgame.LevelOneAllowed = true;
        }
        if (CheckBoxLevel2.IsChecked)
        {
            Newgame.LevelTwoAllowed = true;
        }
        if (CheckBoxLevel3.IsChecked)
        {
            Newgame.LevelThreeAllowed = true;
        }
        if (CheckBoxLevel4.IsChecked)
        {
            Newgame.LevelFourAllowed = true;
        }
        if (CheckBoxLevel5.IsChecked)
        {
            Newgame.LevelFiveAllowed = true;
        }
        List<Category> Categories = Category.GetCategories();
        if (CheckBoxCategoryStandaard.IsChecked)
        {
            Newgame.Categories.Add(Categories[0]);
        }
        if (CheckBoxCategorySpicy.IsChecked)
        {
            Newgame.Categories.Add(Categories[1]);
        }
        if (CheckBoxCategorySpecial.IsChecked)
        {
            Newgame.Categories.Add(Categories[2]);
        }
        Newgame.FilterQuestions();
        Navigation.PushAsync(new AddPlayerPage(CurrentUser, Newgame));

    }

}