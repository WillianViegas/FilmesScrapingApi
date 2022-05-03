using FilmesScrappingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesScrappingApi.Service
{
    public interface IFilmesService
    {
        public IList<Filmes> GetFilmes();
        public Filmes GetFilmeById(string id);
        public Filmes GetMelhorNota();
        public string GetCapaFilme();
    }
}
