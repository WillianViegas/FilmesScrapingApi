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
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("Id inválido");

                var urlCapaFilme = _filmesService.GetCapaFilme(id);


                return Ok(urlCapaFilme);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro ao buscar filme!");
            }
       
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("Id inválido");

                var filme = _filmesService.GetFilmeById(id);

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar filme!");
            }
        }

        [HttpGet]
        public IActionResult GetFilmes()
        {
            try
            {
                var listFilmes = _filmesService.GetFilmes();
                return Ok(listFilmes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar a lista de filmes!");
            }
        }

        [HttpGet]
        public IActionResult GetMelhorNota()
        {

            try
            {
                var filmeMelhorNota = _filmesService.GetMelhorNota();
                return Ok(filmeMelhorNota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar o filme com a melhor nota!");
            }
            
        }

    }
}
