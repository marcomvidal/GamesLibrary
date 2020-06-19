using SQLite;

namespace GamesLibrary.Models
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string Cover { get; set; }
    }
}
