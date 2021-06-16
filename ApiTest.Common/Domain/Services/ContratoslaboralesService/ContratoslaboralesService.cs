using ApiTest.Common.Domain.Entity;
using ApiTest.Common.Domain.Repository;
using ApiTest.Common.Domain.Services.Base;
using ApiTest.Common.Domain.Specifications;
using ApiTest.Common.Domain.Specifications.Base;
using ApiTest.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.Common.Domain.Services
{
    public class ContratoslaboralesService : IContratoslaboralesService
    {

        private readonly IContratoslaboralesRepository contratoslaboralesRepository;

        public ContratoslaboralesService(
            IContratoslaboralesRepository contratoslaboralesRepository
        )
        {
            this.contratoslaboralesRepository = contratoslaboralesRepository;
        }

        public async Task<ServiceResult> GetDocumentoAsync(decimal nodocumento)
        {
            ServiceResult response = new ServiceResult();
            ContratoslaboralesModel documentoModel = await contratoslaboralesRepository.GetDocumentoAsync(nodocumento);

            if (documentoModel != null)
            {
                response.Correcto = true;
                response.Extras = documentoModel;
            }
            else
            {
                response.Correcto = false;
                response.Errores.Add($"No se ha encontrado segmentos con la compañia {nodocumento}");
            }

            return response;

        }


    }
}
