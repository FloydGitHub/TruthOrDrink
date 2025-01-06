using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.DatabaseInfo;

namespace TruthOrDrink.Models
{
    [Table("Games")]
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        public DateTime StartingMoment { get; set; }
        public bool CustomQuestionsAllowed { get; set; }
        public bool StandardQuestionsAllowed { get; set; }
        public bool LevelOneAllowed { get; set; }
        public bool LevelTwoAllowed { get; set; }
        public bool LevelThreeAllowed { get; set; }
        public bool LevelFourAllowed { get; set; }
        public bool LevelFiveAllowed { get; set; }
        public bool IsSaved { get; set; }
        [Ignore]
        public virtual ICollection<Player>? Players { get; set; }
        [Ignore]
        public virtual ICollection<Category>? Categories { get; set; }
        [Ignore]
        public virtual ICollection<Question>? QuestionsToAsk { get; set; }
        [Ignore]
        public string PlayerNames
        {
            get
            {
                return string.Join(" + ", Players.Select(p => p.Name));
            }
        }


        public Question GetNextQuestion()
        {
            Random rng = new Random();
            var randomQuestion = QuestionsToAsk.Any() ? QuestionsToAsk.OrderBy(x => rng.Next()).FirstOrDefault() : null;
            if (randomQuestion != null)
            {
                QuestionsToAsk.Remove(randomQuestion);
            }
            return randomQuestion;

        }
        public Player GetPlayerToAskQuestion()
        {
            Player? playerToAsk = Players.OrderBy(player => player.Drinks + player.Answers)
                .FirstOrDefault();
            return playerToAsk;
        }
        public void UpdatePlayerScore(Player playerToUpdate)
        {
            Players.Remove(Players.FirstOrDefault(p => p.Id == playerToUpdate.Id));
            Players.Add(playerToUpdate);
        }



        // Filter van levels en custom/standard
        // vragen moeten uit DB komen
        public void FilterQuestions()
        {
            Question.FillStandardQuestion();


            List<Question> questions = Question.GetQuestions();
            //Standaard/Custom filter
            questions = questions.Where(q =>
                (q.CustomQuestion && CustomQuestionsAllowed) ||
                (!q.CustomQuestion && StandardQuestionsAllowed)
            ).ToList();

            //Categorie filter
            questions = questions.Where(q =>
                Categories == null || Categories.Any(c => c.Id == q.CategoryId)
            ).ToList();

            //Level Filter
                questions = questions.Where(q =>
                (q.Level == 1 && LevelOneAllowed) ||
                (q.Level == 2 && LevelTwoAllowed) ||
                (q.Level == 3 && LevelThreeAllowed) ||
                (q.Level == 4 && LevelFourAllowed) ||
                (q.Level == 5 && LevelFiveAllowed)
            ).ToList();

            QuestionsToAsk = questions;
            return;
            
        }
        public void SetPlayers(List<Player> players)
        {
            Players = players;
        }
        public void SetStartingMoment()
        {
            StartingMoment = DateTime.Now;
        }

        public void AddorUpdateGame()
        {
            App.DBRepository.AddorUpdateGame(this);
        }

        public void DeleteGame()
        {
            App.DBRepository.DeleteGame(this);
        }
        public static List<Game> GetGamesFromUser(User user)
        {
            return App.DBRepository.GetGamesFromUser(user);
        }
    }
}
