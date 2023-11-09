using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Common.Infrastructure.Repository;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Repository.Repositories
{
    public class ArquivoRepository<TContext> : RepositoryBase<TContext, Arquivo, int>, IArquivoRepository<TContext>
                                where TContext : IUnitOfWork<TContext>
    {
        protected DbContext _context;
        private readonly string _basePath;
        public ArquivoRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) 
        {
            _context = ((DbContext)unitOfWork);
            _basePath = Path.GetDirectoryName(@"C:\\Arquivos\\");
        }

        public async Task<(List<ArquivoDto>, int)> GetArquivoAsync(int usuarioId, DateTime dataInicial, DateTime dataFinal, int arquivoTipoId, string nome, string alias, int pagina, bool exportar = false)
        {
            var query = _dbSet.Where(x => x.Ativo && x.UsuarioCadastro.Equals(usuarioId) && (x.DataCadastro >= dataInicial && x.DataCadastro <= dataFinal)
                            && x.ArquivoTipoId.Equals(arquivoTipoId) && (x.Nome.Contains(nome) || nome == null) && (x.Alias.Contains(alias) || alias == null)).
                         Select(y => new ArquivoDto
                         {
                             Id = y.Id,
                             Nome = y.Nome,
                             Alias = y.Alias,
                             DataCadastro = (DateTime)y.DataCadastro
                         });

            if (!exportar)
            {
                return (await query.OrderByDescending(x => x.Id).Skip(pagina).Take(5).ToListAsync(), await query.CountAsync());
            }
            else
            {
                return (await query.OrderByDescending(x => x.Id).ToListAsync(), await query.CountAsync());
            }
        }
        public async Task<UploadArquivoDto> UploadArquivo(IFormFile file)
        {
            var dadosArquivo = new UploadArquivoDto();
            var docName = Path.GetFileName(file.FileName);

            if (file != null && file.Length > 0)
            {
                var caminho = Path.Combine(_basePath, "", docName);
                dadosArquivo.ArquivoNome = docName;
                dadosArquivo.Caminho = caminho;

                using var stream = new FileStream(caminho, FileMode.Create);
                await file.CopyToAsync(stream);
            }

            return dadosArquivo;    
        }
    }
}
