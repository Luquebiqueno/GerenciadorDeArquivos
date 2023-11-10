using GerenciadorDeArquivos.Common.Application;
using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Interfaces.Application;
using GerenciadorDeArquivos.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Application.ServiceApplications
{
    public class DashboardApplication<TContext> : ApplicationBase<TContext, Arquivo, int>, IDashboardApplication<TContext>
                                 where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IDashboardService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public DashboardApplication(IUnitOfWork<TContext> context, IDashboardService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public async Task<IEnumerable<DashboardDto>> GetDashboard(DateTime dataInicial, DateTime dataFinal)
            => await _service.GetDashboard(dataInicial, dataFinal);

        #endregion
    }
}
