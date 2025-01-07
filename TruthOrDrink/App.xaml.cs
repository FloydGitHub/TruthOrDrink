using TruthOrDrink.DatabaseInfo;

namespace TruthOrDrink
{
    public partial class App : Application
    {
        public static UserRepository UserRepo{get; private set;}
        public static QuestionRepository QuestionRepo{get; private set;}
        public static GameRepository GameRepo{get; private set;}
        public App(UserRepository userRepo, QuestionRepository questionRepo, GameRepository gameRepo)
        {
            InitializeComponent();

            UserRepo = userRepo;
            QuestionRepo = questionRepo;
            GameRepo = gameRepo;

            MainPage = new NavigationPage(new MainPage());

        }
    }
}
