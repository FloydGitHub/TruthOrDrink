using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrink.Models;

namespace TruthOrDrink.DatabaseInfo
{
    public class QuestionRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public QuestionRepository()
        {
            connection = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            connection.CreateTable<Question>();
        }

        public List<Question> GetQuestions()
        {
            try
            {
                List<Question> questions = connection.Table<Question>().ToList();
                List<Category> categories = Category.GetCategories();
                foreach (Question question in questions)
                {
                    question.Category = categories.FirstOrDefault(c => c.Id == question.CategoryId);
                }
                return questions;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve questions: {ex.Message}";
                return new List<Question>();
            }
        }
        public List<Question> GetQuestionsFromUser(int UserId)
        {
            try
            {
                List<Question> questions = Question.GetQuestions();
                questions = questions.Where(q => q.CreatorId == UserId).ToList();
                return questions;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve questions: {ex.Message}";
                return new List<Question>();
            }

        }
        public void AddOrUpdateQuestion(Question question)
        {
            int result = 0;
            try
            {
                if (question.Id != 0)
                {
                    result = connection.Update(question);
                    StatusMessage = $"{result} question updated";
                    return;
                }
                else
                {
                    connection.Insert(question);
                    StatusMessage = "Question added";
                    return;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void DeleteQuestion(Question question)
        {
            try
            {
                connection.Delete(question);
                StatusMessage = "Question deleted";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
