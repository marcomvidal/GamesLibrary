using SQLite;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace GamesLibrary.Models
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string CoverPath { get; set; }

        [Ignore]
        public BitmapImage Cover
        {
            get
            {
                if (CoverPath == null)
                {
                    return new BitmapImage();
                }

                return new BitmapImage(
                    new Uri(Path.Combine(App.ImagesLocation, CoverPath)));
            }
        }
    }
}
