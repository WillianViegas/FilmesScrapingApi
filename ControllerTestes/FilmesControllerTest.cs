using FilmesScrappingApi.Controllers;
using FilmesScrappingApi.Model;
using FilmesScrappingApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace ControllerTestes
{
    [TestClass]
    public class FilmesControllerTest
    {
        public FilmesController Setup(Mock<IFilmesService> filmeService)
        {
            var logMock = new Mock<ILogger<Filmes>>();
            var controller = new FilmesController(logMock.Object, filmeService.Object);

            return controller;
        }

        public Filmes FilmeObj()
        {
            var filme = new Filmes()
            {
                Id = "1",
                Capa = "https://m.media-amazon.com/images/M/MV5BYTZjOTAwMjktYTdkYy00ZjMzLThiZTUtNzZmNzU0N2ZmMjM5XkEyXkFqcGdeQXVyMTEzMjQ4NzEw._V1_QL75_UY281_CR17,0,190,281_.jpg",
                Descricao = "Albus Dumbledore assigns Newt and his allies with a mission related to the rising power of Grindelwald.",
                Duracao = "2 hours 22 minutes",
                Nota = "6.5",
                Titulo = "Fantastic Beasts"
            };

            return filme;
        }


        [TestMethod]
        public void GetCapaFilmeTest()
        {

            var filmesService = new Mock<IFilmesService>();
            filmesService.Setup(c => c.GetCapaFilme("1")).Returns("https://m.media-amazon.com/images/M/MV5BYTZjOTAwMjktYTdkYy00ZjMzLThiZTUtNzZmNzU0N2ZmMjM5XkEyXkFqcGdeQXVyMTEzMjQ4NzEw._V1_QL75_UY281_CR17,0,190,281_.jpg");
            var controller = Setup(filmesService);


            var result = controller.GetCapaFilme("1") as ActionResult;


            Assert.IsNotNull(result);
            //Assert.AreEqual("https://m.media-amazon.com/images/M/MV5BYTZjOTAwMjktYTdkYy00ZjMzLThiZTUtNzZmNzU0N2ZmMjM5XkEyXkFqcGdeQXVyMTEzMjQ4NzEw._V1_QL75_UY281_CR17,0,190,281_.jpg", "");

        }

        [TestMethod]
        public void GetFilmeByIdTest()
        {

            var filmesService = new Mock<IFilmesService>();
            var filme = FilmeObj();
            filmesService.Setup(c => c.GetFilmeById("1")).Returns(filme);
            var controller = Setup(filmesService);


            var result = controller.GetFilmeById("1") as ActionResult;


            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetFilmesTest()
        {

            var filmesService = new Mock<IFilmesService>();
            var listaFilmes = new List<Filmes>();
            listaFilmes.Add(FilmeObj());
            listaFilmes.Add(FilmeObj());

            filmesService.Setup(c => c.GetFilmes()).Returns(listaFilmes);
            var controller = Setup(filmesService);


            var result = controller.GetFilmes() as ActionResult;


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetMelhorNotaTest()
        {

            var filmesService = new Mock<IFilmesService>();
            var filme = FilmeObj();
            filmesService.Setup(c => c.GetMelhorNota()).Returns(filme);
            var controller = Setup(filmesService);


            var result = controller.GetMelhorNota() as ActionResult;


            Assert.IsNotNull(result);
        }
    }
}
