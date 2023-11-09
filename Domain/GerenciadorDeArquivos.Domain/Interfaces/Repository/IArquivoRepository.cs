using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Interfaces.Repository
{
    public interface IArquivoRepository<TContext> : IRepositoryBase<TContext, Arquivo, int>
                                   where TContext : IUnitOfWork<TContext>
    {
        Task<(List<ArquivoDto>, int)> GetArquivoAsync(int usuarioId, DateTime dataInicial, DateTime dataFinal, int arquivoTipoId, string nome, string alias, int pagina, bool exportar = false);

        Task<UploadArquivoDto> UploadArquivo(IFormFile file);
    }
}
