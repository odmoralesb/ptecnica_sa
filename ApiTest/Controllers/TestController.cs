using ApiTest.Common.Domain.Services;
using ApiTest.Common.Domain.Services.Base;
using ApiTest.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Common.Domain.Entity;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : CustomControllerBase
    {

        private readonly IContratoslaboralesService contratoslaboralesService;
        private readonly IMapper mapper;

        public TestController(
            IContratoslaboralesService contratoslaboralesService,
            IMapper mapper
        )
        {
            this.contratoslaboralesService = contratoslaboralesService;
            this.mapper = mapper;
        }

        [HttpGet("[action]")]
        public IActionResult servicestatus()
        {
            return Ok("Ok");
        }



        [HttpGet("contratoslaborales/{nodoc}", Name = "GetDoc")]
        public async Task<ActionResult<ContratoslaboralesModel>> GetDoc(decimal nodoc)
        {

            ServiceResult response = await contratoslaboralesService.GetDocumentoAsync(nodoc);

            if (response.Correcto)
            {
                return Ok(response.Extras);
            }
            else
            {
                return BadRequestFromService(response);
            }

        }


    }
}
