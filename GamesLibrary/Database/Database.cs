using GamesLibrary.Models;
using SQLite;
using System;
using System.IO;

namespace GamesLibrary.Data
{
    public class Database
    {
        private readonly string _path;

        public Database(string path)
        {
            _path = path;
        }

        public SQLiteConnection Connection()
        {
            return new SQLiteConnection(_path);
        }

        public void Setup()
        {
            using SQLiteConnection connection = Connection();
            connection.CreateTable<Game>();
        }
    }
}
