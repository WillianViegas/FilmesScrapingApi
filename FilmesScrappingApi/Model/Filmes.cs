using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesScrappingApi.Model
{
    public class Filmes
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Nota { get; set; }
        public string Duracao { get; set; }
        public string Capa { get; set; }
    }
}
