using FilmesScrappingApi.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesScrappingApi.Data.Repository
{
    public class FilmesRepository : IFilmesRepository
    {
        private readonly IMongoCollection<Filmes> _filmes;

        public FilmesRepository(IDatabaseConfig databaseConfig)
        {
            var connectionString = databaseConfig.ConnectionString.Replace("user", databaseConfig.User).Replace("password", databaseConfig.Password);
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);
            _filmes = database.GetCollection<Filmes>(databaseConfig.CollectionName);
        }

        public Filmes GetFilmeById(string id)
        {
            return _filmes.Find(filme => filme.Id == id).FirstOrDefault();
        }

        public IList<Filmes> GetFilmes()
        {
            return _filmes.Find(filmes => true).ToList();
        }
    }
}
