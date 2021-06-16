using ApiTest.Common.Domain.Entity;
using ApiTest.Common.Domain.Repository.Base;
using ApiTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiTest.Common.Domain.Services.Base;

namespace ApiTest.Common.Domain.Repository
{
    public interface IContratoslaboralesRepository : IRepositoryAsync<Contratoslaborales>
    {
        Task<ContratoslaboralesModel> GetDocumentoAsync(decimal nodocumento);
    }
}
