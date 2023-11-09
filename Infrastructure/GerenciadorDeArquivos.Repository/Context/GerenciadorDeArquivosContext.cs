using GerenciadorDeArquivos.Common.Infrastructure.Context;
using GerenciadorDeArquivos.Repository.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Repository.Context
{
    public class GerenciadorDeArquivosContext : ContextBase<GerenciadorDeArquivosContext>
    {
        public GerenciadorDeArquivosContext(DbContextOptions<GerenciadorDeArquivosContext> options) : base(options) { }

        public new int Commit() => this.SaveChanges();
        public new async Task<int> CommitAsync() => await this.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new SistemaMenuMap());
            modelBuilder.ApplyConfiguration(new ArquivoMap());
            modelBuilder.ApplyConfiguration(new ArquivoTipoMap());
        }
    }
}
