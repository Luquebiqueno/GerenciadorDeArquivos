using AutoMapper;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Interfaces.Application;
using GerenciadorDeArquivos.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciadorDeArquivos.Repository.Context;

namespace GerenciadorDeArquivos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IUsuarioApplication<GerenciadorDeArquivosContext> _application;
        private readonly IMapper _mapper;

        #endregion

        #region [ Contrutores ]

        public UsuarioController(IUsuarioApplication<GerenciadorDeArquivosContext> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetUsuario()
            => Ok(_mapper.Map<IEnumerable<UsuarioDto>>(await _application.GetAllAsync()));


        [HttpGet]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetUsuarioByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _application.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(_mapper.Map<UsuarioDto>(usuario));
        }

        [HttpGet]
        [Route("UsuarioLogado")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetUsuarioLogadoAsync()
        {
            var usuario = await _application.GetUsuarioLogadoAsync();
            if (usuario == null)
                return NotFound();

            return Ok(_mapper.Map<UsuarioDto>(usuario));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUsuarioAsync([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            var usuario = model.Model();

            await _application.CreateAsync(usuario);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> UpdateUsuarioAsync([FromRoute] int id, [FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = model.Model();

            await _application.UpdateUsuarioAsync(id, usuario);
            return Ok();

        }

        [HttpPut]
        [Route("DeleteUsuario")]
        [Authorize("Bearer")]
        public async Task<IActionResult> DeleteUsuarioAsync()
        {
            await _application.DeleteUsuarioAsync();
            return Ok();
        }

        [HttpPut]
        [Route("AlterarSenha")]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarSenhaAsync(AlterarSenhaViewModel model)
        {
            await _application.AlterarSenhaAsync(model.Senha);
            return Ok();
        }

        #endregion
    }
}
