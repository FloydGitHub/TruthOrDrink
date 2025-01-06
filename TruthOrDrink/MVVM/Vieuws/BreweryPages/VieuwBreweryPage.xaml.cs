using TruthOrDrink.APIinfo;
using TruthOrDrink.APIInfo;

namespace TruthOrDrink.Pages.BreweryPages;

public partial class VieuwBreweryPage : ContentPage
{

    public VieuwBreweryPage()
    {
        InitializeComponent();
    }

    private void RandomBreweryButton_Clicked(object sender, EventArgs e)
    {
        LoadRandomBrewerie();
    }

    private async void LoadRandomBrewerie()
    {
        try
        {
            // Fetch the list of breweries asynchronously
            var breweries = await BreweryLogic.GetRandomBrewery();

            // Bind the list to the CollectionView
            BreweryCollection.ItemsSource = breweries;
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during data fetching
            await DisplayAlert("Error", $"Unable to load breweries: {ex.Message}", "OK");
        }
    }

    private async void LoadBreweriesByName(string name)
    {
        try
        {
            var breweries = await BreweryLogic.GetBreweryByName(name);
            BreweryCollection.ItemsSource = breweries;
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during data fetching
            await DisplayAlert("Error", $"Unable to load breweries: {ex.Message}", "OK");
        }
    }
    private void SearchBreweryButton_Clicked(object sender, EventArgs e)
    {
        string name = SearchBreweryEntry.Text;
        LoadBreweriesByName(name);
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}