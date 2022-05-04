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

        public FilmesController(ILogger<Filmes> log, IFilmesService filmesService)
        {
            _log = log;
            _filmesService = filmesService;
        }

        [HttpGet]
        public IActionResult Teste()
        {
            return Ok("Teste");
        }


        [HttpGet("{id}")]
        public IActionResult GetCapaFilme(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id inválido");

            var urlCapaFilme = _filmesService.GetCapaFilme(id);


            return Ok(urlCapaFilme);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id inválido");

            var filme = _filmesService.GetFilmeById(id);

            return Ok(filme);
        }

        [HttpGet]
        public IActionResult GetFilmes()
        {
            var listFilmes = _filmesService.GetFilmes();
            return Ok(listFilmes);
        }
        [HttpGet]
        public IActionResult GetMelhorNota()
        {
            var filmeMelhorNota = _filmesService.GetMelhorNota();
            return Ok(filmeMelhorNota);
        }

    }
}
