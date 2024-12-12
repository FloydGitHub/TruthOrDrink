using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Models;

namespace TruthOrDrink.DatabaseInfo
{
    public class DBRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public DBRepository()
        {
            connection = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            connection.CreateTable<User>();
            connection.CreateTable<Question>();
        }

        public User GetOrAddUser(string username, string password)
        {
            try
            {

                User user = connection.Table<User>().FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user == null)
                {
                    user = new User
                    {
                        Username = username,
                        Password = password
                    };
                    connection.Insert(user);
                }
                return user;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add user: {ex.Message}";
                return new User();
            }
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
                List<Question> questions = GetQuestions();
                return questions.Where(q => q.CreatorId == UserId).ToList();
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
