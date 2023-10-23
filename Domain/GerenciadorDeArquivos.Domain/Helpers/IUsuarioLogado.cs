using GerenciadorDeArquivos.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Helpers
{
    public interface IUsuarioLogado
    {
        UsuarioIdentity Usuario { get; }
    }
}
