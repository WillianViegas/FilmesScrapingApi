using FilmesScrappingApi.Data;
using FilmesScrappingApi.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesScrappingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var dataBaseConfig = new DatabaseConfig();
            config.GetSection("DatabaseConfig").Bind(dataBaseConfig);
            

            var host = CreateHostBuilder(args).Build();


            //Seed filme
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DatabaseName);
            var seed = database.GetCollection<Filmes>(dataBaseConfig.CollectionName);

            var filme = new Filmes()
            {
                Capa = "https://m.media-amazon.com/images/M/MV5BYTZjOTAwMjktYTdkYy00ZjMzLThiZTUtNzZmNzU0N2ZmMjM5XkEyXkFqcGdeQXVyMTEzMjQ4NzEw._V1_QL75_UY281_CR17,0,190,281_.jpg",
                Descricao = "Albus Dumbledore assigns Newt and his allies with a mission related to the rising power of Grindelwald.",
                Duracao = "2 hours 22 minutes",
                Nota = "6.5",
                Titulo = "Fantastic Beasts"
            };
            seed.InsertOne(filme);


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
