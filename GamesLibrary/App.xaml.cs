using GamesLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                   "games-library.db");
            }
        }

        public static string ImagesLocation
        {
            get
            { 
                return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
        }

        public App()
        {
            _database = new Database(DatabaseLocation);
            _database.Setup();
        }
    }
}
