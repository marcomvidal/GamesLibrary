using GamesLibrary.Models;
using GamesLibrary.Services;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GamesLibrary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private readonly GameService _service;
        public Game Game { get; set; }
        private string _selectedImagePath;

        public GameWindow()
        {
            InitializeComponent();
            _service = new GameService();
            Game = new Game();
            Title += "Novo jogo";
        }

        public GameWindow(Game game)
        {
            InitializeComponent();
            _service = new GameService();
            Game = game;
            Title += game.Name;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Game.Id != 0)
            {
                NameTextBox.Text = Game.Name;
                ReleaseYearTextBox.Text = Game.ReleaseYear.ToString();
                CoverImage.Source = Game.CoverImage;
            }
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Selecione uma imagem",
                Filter = "Arquivos de imagens (*.gif, *.jpeg, *.jpg, *.png)|*.gif;*.jpeg;*.jpg;*.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (dialog.ShowDialog() == false) { return; }

            Game.CoverFile = _service.GenerateCoverName(dialog.SafeFileName);
            _selectedImagePath = dialog.FileName;
            CoverImage.Source = new BitmapImage(new Uri(dialog.FileName));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ReleaseYearTextBox.Text, out int releaseYear))
            {
                MessageBox.Show(
                    "Ano de lançamento deve ser um número inteiro.",
                    "Erro",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return;
            }

            Game.Name = NameTextBox.Text;
            Game.ReleaseYear = releaseYear;
            _service.Save(Game, _selectedImagePath);
            Close();
        }
    }
}
