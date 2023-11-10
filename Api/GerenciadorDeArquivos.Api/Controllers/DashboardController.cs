using GerenciadorDeArquivos.Domain.Interfaces.Application;
using GerenciadorDeArquivos.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeArquivos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IDashboardApplication<GerenciadorDeArquivosContext> _application;

        #endregion

        #region [ Contrutores ]

        public DashboardController(IDashboardApplication<GerenciadorDeArquivosContext> application)
        {
            _application = application;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetDashboard(string dataInicial, string dataFinal)
        {
            var retorno = await _application.GetDashboard(DateTime.Parse(dataInicial), DateTime.Parse(dataFinal));
            return Ok(retorno);
        }

        #endregion
    }
}
