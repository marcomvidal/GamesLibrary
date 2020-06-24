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
        public string CoverFile { get; set; }

        [Ignore]
        public string CoverPath
        {
            get
            {
                return Path.Combine(App.ImagesLocation, CoverFile);
            }
        }

        [Ignore]
        public BitmapImage CoverImage
        {
            get
            {
                if (CoverPath == null) { return new BitmapImage(); }

                return new BitmapImage(
                    new Uri(Path.Combine(App.ImagesLocation, CoverPath)));
            }
        }
    }
}
