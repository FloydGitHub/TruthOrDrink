using TruthOrDrink.DatabaseInfo;

namespace TruthOrDrink
{
    public partial class App : Application
    {
        public static DBRepository DBRepository{get; private set;}
        public App(DBRepository dbRepo)
        {
            InitializeComponent();

            DBRepository = dbRepo;
            MainPage = new NavigationPage(new MainPage());

        }
    }
}
