using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTest.Common.Models
{
    public class ContratoslaboralesModel
    {
        public string TipoDocumento { get; set; }
        public decimal? NumeroDocumento { get; set; }
        public string Primerapellido { get; set; }
        public string Segundoapellido { get; set; }
        public string Primernombre { get; set; }
        public string ContratoLaboral { get; set; }
        public string Cargo { get; set; }
        public string RiesgoLaboral { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
    }
}
