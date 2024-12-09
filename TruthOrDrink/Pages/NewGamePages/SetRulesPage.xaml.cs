namespace TruthOrDrink.Pages.NewGamePages;

public partial class SetRulesPage : ContentPage
{
    public SetRulesPage()
    {
        InitializeComponent();
        CheckBoxLevel1.IsChecked = true;
        CheckBoxCategory1.IsChecked = true;
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