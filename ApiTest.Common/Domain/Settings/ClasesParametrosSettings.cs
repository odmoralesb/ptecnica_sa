using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTest.Common.Domain.Settings
{
    /// <summary>
    /// Representa la información mapeada en la sección de configuración del appsettings llamada ClasesParametros
    /// </summary>
    public class ClasesParametrosSettings : IClasesParametrosSettings
    {
        public string Parametro { get; set; }
        public string GetDescripcion(string clave)
        {
            switch(clave)
            {
                case "Parametro": return Parametro;
                default: return "Parametro";
            }
        }

    }

    /// <summary>
    /// Representa la información mapeada en la sección de configuración del appsettings llamada ClasesParametros
    /// </summary>

    public interface IClasesParametrosSettings
    {
        string Parametro { get; set; }
        string GetDescripcion(string clave);
    }
}
