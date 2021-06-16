using ApiTest.Common.Domain.Services.Base;
using ApiTest.Common.Models;
using Microsoft.AspNetCore.Mvc;
using SharedAuditRequestResponseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        /// <summary>
        /// Crea un bad request en caso que algún servicio devuelva errores
        /// </summary>
        /// <param name="serviceResult">Resultado del servicio</param>
        /// <returns>Invocación de BadRequest con los errores mapeados</returns>
        protected ActionResult BadRequestFromService(ServiceResult serviceResult)
        {
            serviceResult.Errores.ForEach(err =>
            {
                ModelState.AddModelError("errors", err);
            });

            return BadRequest(ModelState);
        }

    }
}
