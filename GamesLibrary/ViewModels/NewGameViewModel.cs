using GamesLibrary.Commands;
using GamesLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;

namespace GamesLibrary.ViewModels
{
    public class NewGameViewModel : ViewModel
    {
        private Game _game;

        public Game Game
        {
            get => _game;
            set
            {
                _game = value;
                OnPropertyChanged("Game");
            }
        }

        public SaveCommand SaveCommand { get; set; }

        public NewGameViewModel()
        {
            Game = new Game
            {
                Id = 1,
                Name = "Sonic the Hedgehog",
                ReleaseYear = 1991,
                Cover = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    "SonicTheHedgehog.jpg")
            };

            SaveCommand = new SaveCommand(this);
        }

        public void Save()
        {
            MessageBox.Show("Saved!");
        }
    }
}
