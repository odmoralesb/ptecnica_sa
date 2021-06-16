using ApiTest.Common.Domain.Entity;
using ApiTest.Common.Domain.Services.Base;
using ApiTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.Common.Domain.Services
{
    public interface IContratoslaboralesService
    {
        Task<ServiceResult> GetDocumentoAsync(decimal nodocumento);
    }
}
