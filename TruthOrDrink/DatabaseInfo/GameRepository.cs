using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TruthOrDrink.Models;

namespace TruthOrDrink.DatabaseInfo
{
    public class GameRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public GameRepository()
        {
            connection = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            connection.CreateTable<Game>();
            connection.CreateTable<Player>();
            connection.CreateTable<Category>();
            connection.CreateTable<GameCategory>();
        }

        public void AddOrUpdateCategories()
        {
            int result = 0;
            List<Category> categories = Category.GetCategories();
            try
            {
                foreach (Category category in categories)
                {
                    result = connection.InsertOrReplace(category);
                }
                StatusMessage = $"{result} categories added or updated";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void AddorUpdateGame(Game game)
        {
            AddOrUpdateCategories();
            int result = 0;
            try
            {
                if (game.Id != 0)
                {
                    result = connection.Update(game);
                    StatusMessage = $"{result} game updated";
                    foreach (Player player in game.Players)
                    {
                        connection.Update(player);
                    }
                    connection.Execute($"DELETE FROM GameCategories WHERE GameId = {game.Id}");
                    foreach (Category category in game.Categories)
                    {
                        GameCategory gameCategory = new GameCategory
                        {
                            GameId = game.Id,
                            CategoryId = category.Id
                        };
                        connection.Insert(gameCategory);
                    }
                    return;
                }
                else
                {
                    connection.Insert(game);
                    StatusMessage = "Game added";
                    foreach (Player player in game.Players)
                    {
                        player.GameId = game.Id;
                        connection.Insert(player);
                    }
                    foreach (Category category in game.Categories)
                    {
                        GameCategory gameCategory = new GameCategory
                        {
                            GameId = game.Id,
                            CategoryId = category.Id
                        };
                        connection.Insert(gameCategory);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void DeleteGame(Game game)
        {
            try
            {
                if (game.Id != 0)
                {
                    connection.Delete(game);
                    StatusMessage = "Game deleted";
                    foreach (Player player in game.Players)
                    {
                        connection.Delete(player);
                    }
                    connection.Execute($"DELETE FROM GameCategories WHERE GameId = {game.Id}");
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<Player> GetPlayersFromGame(Game game)
        {
            try
            {
                List<Player> players = connection.Table<Player>().ToList();
                players = players.Where(p => p.GameId == game.Id).ToList();
                return players;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve players: {ex.Message}";
                return new List<Player>();
            }
        }

        public List<Category> GetCategoriesFromGame(Game game)
        {
            try
            {
                List<GameCategory> gameCategories = connection.Table<GameCategory>().ToList();
                List<Category> categories = Category.GetCategories();
                List<Category> gameCategoriesList = new List<Category>();
                foreach (GameCategory gameCategory in gameCategories)
                {
                    if (gameCategory.GameId == game.Id)
                    {
                        gameCategoriesList.Add(categories.FirstOrDefault(c => c.Id == gameCategory.CategoryId));
                    }
                }
                return gameCategoriesList;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve categories: {ex.Message}";
                return new List<Category>();
            }
        }

        public List<Game> GetGamesFromUser(User user)
        {
            try
            {
                List<Game> games = connection.Table<Game>().ToList();
                foreach (Game game in games)
                {
                    game.Players = GetPlayersFromGame(game);
                    game.Categories = GetCategoriesFromGame(game);
                }
                List<Category> categories = Category.GetCategories();
                games = games.Where(g => g.Players.Any(p => p.UserId == user.Id)).ToList();
                return games;

            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve games: {ex.Message}";
                return new List<Game>();
            }
        }
    }
}
