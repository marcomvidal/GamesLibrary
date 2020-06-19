using GamesLibrary.Commands;
using GamesLibrary.Data;
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
        private Repository _repository;
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
            _repository = new Repository();
            
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
            _repository.Create(_game);
            MessageBox.Show("Saved!");
        }
    }
}
