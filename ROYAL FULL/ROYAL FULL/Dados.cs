using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROYAL_FULL
{
    class Dados
    {

        public ObjectId _id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Plano { get; set; }
        public bool JaAtivado { get; set; }
        public string MaquinaID { get; set; }


        public static class Logado
        {
            public static string UsuarioAtual = "";

            public static string PlanoAtual = "";
        }
    }
}
