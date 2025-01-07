using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrink.Models;

namespace TruthOrDrink.DatabaseInfo
{
    public class UserRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public UserRepository()
        {
            connection = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            connection.CreateTable<User>();
        }

        public User GetUser(string username, string password)
        {
            try
            {
                User user = connection.Table<User>().FirstOrDefault(u => u.Username == username && u.Password == password);
                return user;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve user: {ex.Message}";
                return new User();
            }
        }

        public User? GetLoggedInUser()
        {
            try
            {
                User user = connection.Table<User>().FirstOrDefault(u => u.IsLoggedInUser == true);
                return user;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve user: {ex.Message}";
                return null;
            }
        }

        public void AddOrUpdateUser(User user)
        {
            try
            {
                if (user.Id != 0)
                {
                    connection.Update(user);
                    StatusMessage = "User updated";
                    return;
                }
                else
                {
                    connection.Insert(user);
                    StatusMessage = "User added";
                    return;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
