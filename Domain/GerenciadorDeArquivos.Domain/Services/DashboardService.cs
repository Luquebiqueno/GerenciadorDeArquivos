using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Common.Domain.Service;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Helpers;
using GerenciadorDeArquivos.Domain.Interfaces.Repository;
using GerenciadorDeArquivos.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Services
{
    public class DashboardService<TContext> : ServiceBase<TContext, Arquivo, int>, IDashboardService<TContext>
                             where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IDashboardRepository<TContext> _repository;
        private readonly IUsuarioLogado _usuarioLogado;

        #endregion

        #region [ Construtor ]

        public DashboardService(IDashboardRepository<TContext> repository,
                                IUsuarioLogado usuarioLogado) : base(repository)
        {
            _repository = repository;
            _usuarioLogado = usuarioLogado;
        }

        #endregion

        #region [ Métodos ]

        public async Task<IEnumerable<DashboardDto>> GetDashboard(DateTime dataInicial, DateTime dataFinal)
            => await _repository.GetDashboard(_usuarioLogado.Usuario.Id, dataInicial, dataFinal);

        #endregion
    }
}
