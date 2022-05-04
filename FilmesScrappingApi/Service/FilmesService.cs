using FilmesScrappingApi.Data.Repository;
using FilmesScrappingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesScrappingApi.Service
{
    public class FilmesService : IFilmesService
    {

        private IFilmesRepository _filmesRepository;

        public FilmesService(IFilmesRepository filmesRepository)
        {
            _filmesRepository = filmesRepository;
        }

        public string GetCapaFilme(string id)
        {
            var filme = GetFilmeById(id);

            if (filme == null)
                return null;

            return filme.Capa;
        }

        public Filmes GetFilmeById(string id)
        {
            return _filmesRepository.GetFilmeById(id);
        }

        public IList<Filmes> GetFilmes()
        {
            return _filmesRepository.GetFilmes();
        }

        public Filmes GetMelhorNota()
        {
            var listaFilmes = GetFilmes();
            var maiorNota = listaFilmes.Max(x => x.Nota);
            var filmeComMaiorNota = listaFilmes.Where(x => x.Nota == maiorNota).FirstOrDefault();

            return filmeComMaiorNota;
        }
    }
}
