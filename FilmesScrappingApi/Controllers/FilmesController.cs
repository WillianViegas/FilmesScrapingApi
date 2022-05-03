using FilmesScrappingApi.Data.Repository;
using FilmesScrappingApi.Model;
using FilmesScrappingApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesScrappingApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FilmesController : ControllerBase
    {
        private ILogger<Filmes> _log;
        private IFilmesService _filmesService;
        private IFilmesRepository _filmesRepository;

        public FilmesController(ILogger<Filmes> log, IFilmesService filmesService, IFilmesRepository filmesRepository)
        {
            _log = log;
            _filmesService = filmesService;
            _filmesRepository = filmesRepository;
        }

        [HttpGet]
        public IActionResult Teste()
        {
            return Ok("Teste");
        }
    }
}
