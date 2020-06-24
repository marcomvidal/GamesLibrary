using GamesLibrary.Models;
using GamesLibrary.Services;
using System.Windows;
using System.Windows.Controls;

namespace GamesLibrary.Views
{
    /// <summary>
    /// Interaction logic for GameSelectionView.xaml
    /// </summary>
    public partial class GameSelectionView : Window
    {
        private readonly GameService _service;

        public GameSelectionView()
        {
            InitializeComponent();
            _service = new GameService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GamesListView.ItemsSource = _service.AllSortedByName();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string term = (sender as TextBox).Text.ToString();
            GamesListView.ItemsSource = _service.FindByTermInsensitive(term);
        }

        private void EditOption_Click(object sender, RoutedEventArgs e)
        {
            if (GamesListView.SelectedItem is Game game)
            {
                new GameWindow(game).ShowDialog();
                GamesListView.ItemsSource = _service.AllSortedByName();
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            new GameWindow().ShowDialog();
            GamesListView.ItemsSource = _service.AllSortedByName();
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
                _service.Delete(selectedGame);
                GamesListView.ItemsSource = _service.AllSortedByName();
            }
        }
    }
}
