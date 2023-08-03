using SQLite;

namespace MAUISQLGameApp.Models
{
    public enum GameOperation
    {
        Addition,
        Substraction,
        Multyplication,
        Division

    }
    [Table("game")]
    public class GameModel
    {
        [PrimaryKey,AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public GameOperation Type { get; set; }
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }
    }
}
