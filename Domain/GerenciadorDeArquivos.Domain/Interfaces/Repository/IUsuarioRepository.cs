using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository<TContext> : IRepositoryBase<TContext, Usuario, int>
                                   where TContext : IUnitOfWork<TContext>
    {
        Usuario UpdateUsuario(Usuario entity);
        Task<Usuario> GetUsuarioByLoginSenhaAsync(string login, string senha);
    }
}
