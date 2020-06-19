using GamesLibrary.Models;
using SQLite;
using System;
using System.IO;

namespace GamesLibrary.Data
{
    public class Database
    {
        private const string fileName = "games-library.db";
        private readonly string filePath;

        public Database()
        {
            filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                fileName);
        }

        public SQLiteConnection Connection()
        {
            return new SQLiteConnection(filePath);
        }

        public void Setup()
        {
            using SQLiteConnection connection = Connection();
            connection.CreateTable<Game>();
        }
    }
}
