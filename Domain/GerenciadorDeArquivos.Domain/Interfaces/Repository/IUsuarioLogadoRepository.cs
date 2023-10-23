using GerenciadorDeArquivos.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Interfaces.Repository
{
    public interface IUsuarioLogadoRepository
    {
        UsuarioIdentity GetUsuarioLogado(string identity);
        Task<UsuarioIdentity> GetUsuarioLogadoAsync(string identity);
    }
}
