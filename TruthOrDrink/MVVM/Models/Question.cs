using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    [Table("Questions")]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string? Text {  get; set; }
        [NotNull]
        public int Level { get; set; }
        public bool CustomQuestion { get; set; }
        public bool PhotoQuestion { get; set; }
        //foreign key
        [Column("CreatorId")]
        public int? CreatorId { get; set; }
        [Ignore]
        public virtual User? Creator { get; set; }
        //foreign key
        public int CategoryId { get; set; }
        [Ignore]
        public virtual Category? Category { get; set; }



        public static void FillStandardQuestion()
        {
           
            List<Question> AllCurrentQuestions = Question.GetQuestions();
            List<Question> AllCurrentStandardQuestions = AllCurrentQuestions.Where(q => q.CustomQuestion == false).ToList();
            if (AllCurrentStandardQuestions.Count < 45)
            {

                List<Question> questions = new List<Question>
                {
                // Categorie 1: Standaard
                new Question { Text = "Wat is je favoriete kleur en waarom?", Level = 1, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Wat is het lekkerste wat je vandaag hebt gegeten?", Level = 1, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Wat doe je het liefst op een vrije dag?", Level = 1, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },

                new Question { Text = "Wat is de mooiste herinnering uit je kindertijd?", Level = 2, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Met wie zou je een dag willen ruilen en waarom?", Level = 2, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Wat is een eigenschap van jezelf waar je trots op bent?", Level = 2, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },

                new Question { Text = "Vertel over een moment waarop je jezelf hebt verrast.", Level = 3, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Welk boek of film heeft jouw kijk op het leven veranderd?", Level = 3, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Hoe ziet jouw ideale dag eruit?", Level = 3, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },

                new Question { Text = "Wat is het moeilijkste wat je ooit hebt moeten doen?", Level = 4, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Hoe ga je om met stressvolle situaties?", Level = 4, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Wat is de beste raad die je ooit hebt gekregen?", Level = 4, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },

                new Question { Text = "Vertel over een persoonlijke overwinning waar je trots op bent.", Level = 5, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Wat zou je in je leven veranderen als je de kans kreeg?", Level = 5, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },
                new Question { Text = "Wat is je grootste levensles tot nu toe?", Level = 5, CustomQuestion = false, PhotoQuestion = false, CategoryId = 1 },

                // Categorie 2: Spicy
                new Question { Text = "Wat is het gekste wat je ooit hebt gedaan?", Level = 1, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Heb je ooit stiekem iets gedaan wat niemand weet?", Level = 1, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Wat was je meest ongemakkelijke moment in het openbaar?", Level = 1, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },

                new Question { Text = "Wat is je grootste guilty pleasure?", Level = 2, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Wat zou je doen als je één dag onzichtbaar kon zijn?", Level = 2, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Met wie zou je een verboden avontuur willen beleven?", Level = 2, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },

                new Question { Text = "Wat is het meest gewaagde wat je ooit hebt gedaan?", Level = 3, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Wat is je vreemdste gewoonte?", Level = 3, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Wat zou je doen als je wist dat je nooit betrapt zou worden?", Level = 3, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },

                new Question { Text = "Wat is het meest gênante dat je ooit tegen iemand hebt gezegd?", Level = 4, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Wat is je spannendste date ooit geweest?", Level = 4, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Met welke beroemdheid zou je het liefst een avondje uit willen?", Level = 4, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },

                new Question { Text = "Wat is het meest riskante wat je ooit hebt gedaan voor plezier?", Level = 5, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Wat is een geheime fantasie die je nog nooit hebt verteld?", Level = 5, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },
                new Question { Text = "Wat is het meest gedurfde wat je ooit hebt geprobeerd?", Level = 5, CustomQuestion = false, PhotoQuestion = false, CategoryId = 2 },

                // Categorie 3: Special (Opdrachten)
                new Question { Text = "Maak een foto waarop je een gekke gezichtsuitdrukking hebt.", Level = 1, CustomQuestion = false, PhotoQuestion = true, CategoryId = 3 },
                new Question { Text = "Doe een handstand tegen de muur en hou het vol voor 5 seconden.", Level = 1, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },
                new Question { Text = "Probeer een tongtwister drie keer achter elkaar foutloos te zeggen.", Level = 1, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },

                new Question { Text = "Maak een selfie met iets blauws in de kamer.", Level = 2, CustomQuestion = false, PhotoQuestion = true, CategoryId = 3 },
                new Question { Text = "Zing 10 seconden luidop je favoriete liedje.", Level = 2, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },
                new Question { Text = "Maak een tekening van het eerste dat in je hoofd opkomt in 30 seconden.", Level = 2, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },

                new Question { Text = "Maak een foto van een random lichaamsdeel.", Level = 3, CustomQuestion = false, PhotoQuestion = true, CategoryId = 3 },
                new Question { Text = "Dans 30 seconden zonder muziek.", Level = 3, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },
                new Question { Text = "Doe 10 push-ups.", Level = 3, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },

                new Question { Text = "Maak een foto terwijl je een rare outfit draagt.", Level = 4, CustomQuestion = false, PhotoQuestion = true, CategoryId = 3 },
                new Question { Text = "Bedenk en vertel ter plekke een kort verhaal van 20 seconden.", Level = 4, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },
                new Question { Text = "Doe een grappige imitatie van iemand uit de groep.", Level = 4, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },

                new Question { Text = "Maak een foto waarop je iets geks doet met een voorwerp.", Level = 5, CustomQuestion = false, PhotoQuestion = true, CategoryId = 3 },
                new Question { Text = "Laat iemand anders je telefoon gebruiken en laat ze een willekeurige foto maken.", Level = 5, CustomQuestion = false, PhotoQuestion = true, CategoryId = 3 },
                new Question { Text = "Doe 3 uitdagingen uit de groep zonder te weigeren.", Level = 5, CustomQuestion = false, PhotoQuestion = false, CategoryId = 3 },


            };

                foreach (Question question in questions)
                {
                    question.AddOrUpdateQuestion();
                }
            }
        }
        public static List<Question> GetQuestions()
        {
            List<Question> questions = App.QuestionRepo.GetQuestions();
            return questions;
        }

        public static List<Question> GetQuestionsFromUser(int userId)
        {
            List<Question> questions = App.QuestionRepo.GetQuestionsFromUser(userId);
            return questions;
        }

        public void AddOrUpdateQuestion()
        {
            App.QuestionRepo.AddOrUpdateQuestion(this);
        }

        public void DeleteQuestion()
        {
            App.QuestionRepo.DeleteQuestion(this);
        }
    }
}
