using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Interfaces.Repository
{
    public interface IDashboardRepository<TContext> : IRepositoryBase<TContext, Arquivo, int>
                                     where TContext : IUnitOfWork<TContext>
    {
        Task<IEnumerable<DashboardDto>> GetDashboard(int usuarioId, DateTime dataInicial, DateTime dataFinal);
    }
}
