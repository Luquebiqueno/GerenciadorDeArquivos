using GerenciadorDeArquivos.Common.Domain.Entities;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Interfaces.Repository;
using GerenciadorDeArquivos.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Repository.Repositories
{
    public class UsuarioLogadoRepository : IUsuarioLogadoRepository
    {
        #region [ Propriedades ]

        private readonly GerenciadorDeArquivosContext _context;
        private DbSet<Usuario> _dataSet;

        #endregion

        #region [ Contrutores ]

        public UsuarioLogadoRepository(GerenciadorDeArquivosContext context)
        {
            _context = context;
            _dataSet = _context.Set<Usuario>();
        }

        #endregion

        #region [ Métodos ]

        public UsuarioIdentity GetUsuarioLogado(string identity)
        {
            var usuario = _dataSet.FirstOrDefault(x => x.Email.Equals(identity) && x.Ativo);

            return new UsuarioIdentity(usuario.Id, usuario.Nome, usuario.Email, string.Empty);
        }
        public async Task<UsuarioIdentity> GetUsuarioLogadoAsync(string identity)
        {
            var usuario = await _dataSet.FirstOrDefaultAsync(x => x.Email.Equals(identity) && x.Ativo);

            return new UsuarioIdentity(usuario.Id, usuario.Nome, usuario.Email, string.Empty);
        }

        #endregion
    }
}
