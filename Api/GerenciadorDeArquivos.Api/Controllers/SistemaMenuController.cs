using GerenciadorDeArquivos.Domain.Interfaces.Application;
using GerenciadorDeArquivos.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeArquivos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaMenuController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly ISistemaMenuApplication<GerenciadorDeArquivosContext> _application;

        #endregion

        #region [ Contrutores ]

        public SistemaMenuController(ISistemaMenuApplication<GerenciadorDeArquivosContext> application)
        {
            _application = application;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetMenu()
        {
            var result = await _application.GetMenu();
            return Ok(result);
        }

        #endregion
    }
}
