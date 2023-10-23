using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Common.Infrastructure.Repository;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Repository.Repositories
{
    public class UsuarioRepository<TContext> : RepositoryBase<TContext, Usuario, int>, IUsuarioRepository<TContext>
                              where TContext : IUnitOfWork<TContext>
    {
        public UsuarioRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }

        public override async Task<IEnumerable<Usuario>> GetAllAsync()
            => await _dbSet.Where(x => x.Ativo).ToListAsync();
        public override async Task<Usuario> GetByIdAsync(int id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Ativo);
        public async Task<Usuario> GetUsuarioByLoginSenhaAsync(string login, string senha)
            => await _dbSet.FirstOrDefaultAsync(x => x.Email.Equals(login) && x.Senha.Equals(senha) && x.Ativo);
        public Usuario UpdateUsuario(Usuario entity)
        {
            try
            {
                if (entity != null)
                {
                    var result = _dbSet.Attach(entity);
                    result.State = EntityState.Modified;
                    result.Property(x => x.DataCadastro).IsModified = false;

                    return entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
