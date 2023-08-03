
using MAUISQLGameApp.Models;
using SQLite;

namespace MAUISQLGameApp.Data
{
    public class GameRepository
    {
        string _dbPath;
        private SQLiteConnection _connection;
        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;
            _connection = new SQLiteConnection(_dbPath);
            CreateTableIfNotExists();
        }
        private void CreateTableIfNotExists() 
        {
            _connection.CreateTable<GameModel>();
        
        }
        public List<GameModel> GetAllData()
        {
           var games = _connection.Table<GameModel>().ToList();
            return games;
        }
        public void DeleteGame(int id)
        {
            _connection.Delete<GameModel>(id);
        }
        public void AddGame(GameModel game)
        {
            _connection.Insert(game);
        }
    }
}
