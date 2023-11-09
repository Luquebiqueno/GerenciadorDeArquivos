using AutoMapper;
using GerenciadorDeArquivos.Api.Models;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Interfaces.Application;
using GerenciadorDeArquivos.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace GerenciadorDeArquivos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IArquivoApplication<GerenciadorDeArquivosContext> _application;
        private readonly IMapper _mapper;

        #endregion

        #region [ Contrutores ]

        public ArquivoController(IArquivoApplication<GerenciadorDeArquivosContext> application, 
                                 IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetArquivo(string dataInicial, string dataFinal, int arquivoTipoId, string nome, string alias, int pagina, bool exportar = false)
        {
            var (result, qtdItens) = await _application.GetArquivoAsync(DateTime.Parse(dataInicial), DateTime.Parse(dataFinal), arquivoTipoId, nome, alias, pagina, exportar);
            return Ok(new { data = result, qtdItens });
        }


        [HttpGet]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetArquivoById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var arquivo = await _application.GetByIdAsync(id);
            if (arquivo == null)
                return NotFound();

            return Ok(arquivo);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> CreateArquivo([FromBody] ArquivoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            await _application.CreateAsync(model.Model());

            return Ok();
        }

        [HttpPost]
        [Route("UploadArquivo")]
        public async Task<IActionResult> UploadArquivo([FromForm] IFormFile file)
        {
            return Ok(await _application.UploadArquivo(file));
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> UpdateArquivo([FromRoute] int id, [FromBody] ArquivoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _application.UpdateArquivoAsync(id, model.Model());

            return Ok();

        }

        [HttpPut]
        [Route("DeleteArquivo/{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> DeleteArquivo(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _application.DeleteArquivoAsync(id);
            return Ok();
        }

        #endregion
    }
}
