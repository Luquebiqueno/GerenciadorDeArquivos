using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Interfaces.Service
{
    public interface IAutenticacaoService<TContext> where TContext : IUnitOfWork<TContext>
    {
        Task<TokenDto> GetAutenticacao(string login, string senha);
    }
}
