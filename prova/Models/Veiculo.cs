using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prova.Models
{
    public class Veiculo
    {
        public long VeiculoId { get; set; }
        public string Modelo { get; set; }
        public string MotorizacaoId { get; set; }
        public string Fabricante { get; set; }
        public string Ano { get; set; }
        public string Valor { get; set; }
    }
}