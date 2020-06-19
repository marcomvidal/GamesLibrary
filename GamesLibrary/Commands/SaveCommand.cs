using GamesLibrary.Models;
using GamesLibrary.ViewModels;
using System;
using System.Windows.Input;

namespace GamesLibrary.Commands
{
    public class SaveCommand : ICommand
    {
        public NewGameViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SaveCommand(NewGameViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_viewModel.Game.Name);
        }

        public void Execute(object parameter)
        {
            _viewModel.Save();
        }
    }
}
