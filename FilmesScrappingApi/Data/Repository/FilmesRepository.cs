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
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);
            _filmes = database.GetCollection<Filmes>("Dados");
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
