using GamesLibrary.Data;
using GamesLibrary.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GamesLibrary.Services
{
    public class GameService
    {
        private readonly Repository _repository;

        public GameService()
        {
            _repository = new Repository();
        }

        public IEnumerable<Game> AllSortedByName()
        {
            return _repository.OrderBy<Game>(game => game.Name);
        }

        public IEnumerable<Game> FindByTermInsensitive(string term)
        {
            return _repository
                .OrderBy<Game>(game => game.Name)
                .Where(game => game.Name.ToLower().Contains(term.ToLower()))
                .ToList();
        }

        public int Save(Game game, string selectedImagePath)
        {
            if (game.Id == 0)
            {
                File.Copy(selectedImagePath, game.CoverPath, true);
                return _repository.Create(game);
            }

            return _repository.Update(game);
        }

        public int Delete(Game game)
        {
            return _repository.Delete(game);
        }

        public void CleanUnusedCovers()
        {
            Directory.GetFiles(App.ImagesLocation)
                .Except(AllSortedByName().Select(game => game.CoverPath))
                .ToList()
                .ForEach(file => File.Delete(file));
        }

        public string GenerateCoverName(string sourceFileName)
        {
            int nextId = _repository.GetAll<Game>().LastOrDefault() is Game game ?
                (game.Id + 1) : 1;

            return $"{nextId}.{sourceFileName.Split('.')[1]}";
        }
    }
}
