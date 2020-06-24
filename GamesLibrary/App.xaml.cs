using GamesLibrary.Data;
using GamesLibrary.Services;
using System;
using System.IO;
using System.Windows;

namespace GamesLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Database _database;

        public static string DatabaseLocation
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "data.db");
            }
        }

        public static string ImagesLocation
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "Images");
            }
        }

        public App()
        {
            _database = new Database(DatabaseLocation);
            _database.Setup();
            SetupFiles();
        }

        private void SetupFiles()
        {
            if (!Directory.Exists(ImagesLocation))
            {
                Directory.CreateDirectory(ImagesLocation);
                return;
            }

            new GameService().CleanUnusedCovers();
        }
    }
}
