﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartingMoment { get; set; }
        public bool Finnished { get; set; }
        public bool Saved { get; set; }
        public bool CustomQuestionsAllowed { get; set; }
        public bool StandardQuestionsAllowed { get; set; }
        public bool LevelOneAllowed { get; set; }
        public bool LevelTwoAllowed { get; set; }
        public bool LevelThreeAllowed { get; set; }
        public bool LevelFourAllowed { get; set; }
        public bool LevelFiveAllowed { get; set; }

        public virtual ICollection<Player>? Players { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<Question>? QuestionsToAsked { get; set; }
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
            var randomQuestion = QuestionsToAsked.Any() ? QuestionsToAsked.OrderBy(x => rng.Next()).FirstOrDefault() : null;
            if (randomQuestion != null)
            {
                QuestionsToAsked.Remove(randomQuestion);
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
    }
}
