using ApiTest.Common.Domain.Entity;
using ApiTest.Common.Domain.Repository.Base;
using ApiTest.Common.Models;
using ApiTest.Common.Persistence.Context;
using ApiTest.Common.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using ApiTest.Common.Domain.Services;
using ApiTest.Common.Domain.Services.Base;

namespace ApiTest.Common.Domain.Repository
{
    public class ContratoslaboralesRepository: RepositoryBaseAsync<Contratoslaborales>, IContratoslaboralesRepository
    {

        private readonly IMapper mapper;
        public ContratoslaboralesRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }


        public async Task<ContratoslaboralesModel> GetDocumentoAsync(decimal nodocumento)
        {

            Contratoslaborales documentoEntity = await (
                from d in dbcontext.Contratoslaborales
                where d.Numerodocumento == nodocumento
                select d
            )
            .Include(t => t.IdtipodocumentoNavigation)
            .FirstOrDefaultAsync();

            ContratoslaboralesModel documentoModel = new ContratoslaboralesModel
            {
                TipoDocumento = documentoEntity.IdtipodocumentoNavigation.Nombre,
                NumeroDocumento = documentoEntity.Numerodocumento,
                Primernombre = documentoEntity.Primernombre,
                Primerapellido = documentoEntity.Primerapellido,
                Segundoapellido = documentoEntity.Segundoapellido
            };

            return documentoModel;

        }



    }
}
