using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GamesLibrary.Data
{
    public class Repository
    {
        private readonly Database database;

        public Repository()
        {
            database = new Database(App.DatabaseLocation);
        }

        public int Create(object entry)
        {
            using var connection = database.Connection();
            return connection.Insert(entry);
        }

        public List<T> GetAll<T>() where T : new()
        {
            using var connection = database.Connection();
            return connection.Table<T>().ToList();
        }

        public List<T> OrderBy<T>(Expression<Func<T, dynamic>> criteria) where T : new()
        {
            using var connection = database.Connection();
            return connection.Table<T>().OrderBy(criteria).ToList();
        }

        public int Delete(object entry)
        {
            using var connection = database.Connection();
            return connection.Delete(entry);
        }

        public int Update(object entry)
        {
            using var connection = database.Connection();
            return connection.Update(entry);
        }
    }
}
