using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTest.Common.Domain.Services.Base
{
    /// <summary>
    /// Resultado al ejecutar un servicio
    /// </summary>
    public class ServiceResult
    {
        public bool Correcto { get; set; }
        public List<string> Errores { get; set; } = new List<string>();
        public object Extras { get; set; }
    }
}
