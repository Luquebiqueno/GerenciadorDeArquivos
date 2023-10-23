using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Interfaces.Service
{
    public interface ISistemaMenuService<TContext> : IServiceBase<TContext, SistemaMenu, int>
                                    where TContext : IUnitOfWork<TContext>
    {
        Task<List<SistemaMenuDto>> GetMenu();
    }
}
