using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Interfaces.Service
{
    public interface IArquivoService<TContext> : IServiceBase<TContext, Arquivo, int>
                                where TContext : IUnitOfWork<TContext>
    {
        Task<(List<ArquivoDto>, int)> GetArquivoAsync(DateTime dataInicial, DateTime dataFinal, int arquivoTipoId, string nome, string alias, int pagina, bool exportar = false);
        Task<Arquivo> UpdateArquivoAsync(int id, Arquivo entity);
        Task DeleteArquivoAsync(int id);
        Task<UploadArquivoDto> UploadArquivo(IFormFile file);
    }
}
