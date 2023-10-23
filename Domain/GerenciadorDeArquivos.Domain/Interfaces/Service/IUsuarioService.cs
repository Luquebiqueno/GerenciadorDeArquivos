using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Interfaces.Service
{
    public interface IUsuarioService<TContext> : IServiceBase<TContext, Usuario, int>
                                where TContext : IUnitOfWork<TContext>
    {
        Task<Usuario> UpdateUsuarioAsync(int id, Usuario entity);
        Task DeleteUsuarioAsync();
        Task AlterarSenhaAsync(string senha);
        Task<Usuario> GetUsuarioByLoginSenhaAsync(string login, string senha);
        Task<Usuario> GetUsuarioLogadoAsync();
    }
}
