using GamesLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GamesLibrary.ViewModels
{
    public class GameSelectionViewModel
    {
        public List<Game> Games { get; set; }

        public GameSelectionViewModel()
        {
            Games = new List<Game>
            {
                new Game { Id = 1, Name = "Sonic the Hedgehog", ReleaseYear = 1991, Cover = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "SonicTheHedgehog.jpg") },
                new Game { Id = 2, Name = "Super Mario Bros.", ReleaseYear = 1985, Cover = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "SonicTheHedgehog.jpg") },
                new Game { Id = 3, Name = "Crash Bandicoot", ReleaseYear = 1996, Cover = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "SonicTheHedgehog.jpg") }
            };
        }
    }
}
