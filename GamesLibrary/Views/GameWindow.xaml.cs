using GamesLibrary.Data;
using GamesLibrary.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamesLibrary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private readonly Repository _repository;
        public Game Game { get; set; }

        public GameWindow()
        {
            InitializeComponent();
            _repository = new Repository();
            Game = new Game();
        }
        
        public GameWindow(Game game)
        {
            InitializeComponent();
            _repository = new Repository();
            Game = game;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Game != null)
            {
                NameTextBox.Text = Game.Name;
                ReleaseYearTextBox.Text = Game.ReleaseYear.ToString();
                CoverImage.Source = Game.Cover;
            }
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Selecione uma imagem",
                Filter = "Arquivos de imagens (*.gif, *.jpeg, *.jpg, *.png)|*.gif;*.jpeg;*.jpg;*.png",
                InitialDirectory = App.ImagesLocation
            };

            if (fileDialog.ShowDialog() == true)
            {
                Game.CoverPath = fileDialog.FileName;
                CoverImage.Source = Game.Cover;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Game.Name = NameTextBox.Text;
            Game.ReleaseYear = int.Parse(ReleaseYearTextBox.Text);
            
            if (Game.Id == 0)
            {
                _repository.Create(Game);
            }
            else
            {
                _repository.Update(Game);
            }
            
            Close();
        }
    }
}
