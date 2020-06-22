using GamesLibrary.Data;
using GamesLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GamesLibrary.Views
{
    /// <summary>
    /// Interaction logic for GameSelectionView.xaml
    /// </summary>
    public partial class GameSelectionView : Window
    {
        private readonly Repository _repository;

        public GameSelectionView()
        {
            InitializeComponent();
            _repository = new Repository();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GamesListView.ItemsSource = _repository.OrderBy<Game>(game => game.Name);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string term = (sender as TextBox).Text.ToString().ToLower();

            GamesListView.ItemsSource = _repository
                .OrderBy<Game>(game => game.Name)
                .Where(game => game.Name.ToLower().Contains(term))
                .ToList();
        }

        private void GamesListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var window = new GameWindow(GamesListView.SelectedItem as Game);
            window.ShowDialog();
            GamesListView.ItemsSource = _repository.OrderBy<Game>(game => game.Name);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow();
            window.ShowDialog();
            GamesListView.ItemsSource = _repository.OrderBy<Game>(game => game.Name);
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedGame = GamesListView.SelectedItem as Game;

            var dialog = MessageBox.Show(
                $"Tem certeza de que deseja excluir {selectedGame.Name}?",
                $"Excluir {selectedGame.Name}?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            
            if (dialog == MessageBoxResult.Yes)
            {
                _repository.Delete(GamesListView.SelectedItem as Game);
                GamesListView.ItemsSource = _repository.OrderBy<Game>(game => game.Name);
            }
        }
    }
}
