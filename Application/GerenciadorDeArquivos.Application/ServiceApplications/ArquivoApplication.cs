using GerenciadorDeArquivos.Common.Application;
using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Interfaces.Application;
using GerenciadorDeArquivos.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Application.ServiceApplications
{
    public class ArquivoApplication<TContext> : ApplicationBase<TContext, Arquivo, int>, IArquivoApplication<TContext>
                               where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IArquivoService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public ArquivoApplication(IUnitOfWork<TContext> context,
                                  IArquivoService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public async Task<(List<ArquivoDto>, int)> GetArquivoAsync(DateTime dataInicial, DateTime dataFinal, int arquivoTipoId, string nome, string alias, int pagina, bool exportar = false)
            => await _service.GetArquivoAsync(dataInicial, dataFinal, arquivoTipoId, nome, alias, pagina, exportar);

        public async Task DeleteArquivoAsync(int id)
        {
            await _service.DeleteArquivoAsync(id);
            await _unitOfWork.CommitAsync();
        }
        public async Task<Arquivo> UpdateArquivoAsync(int id, Arquivo entity)
        {
            await _service.UpdateArquivoAsync(id, entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<UploadArquivoDto> UploadArquivo(IFormFile file)
            => await _service.UploadArquivo(file);

        #endregion
    }
}
