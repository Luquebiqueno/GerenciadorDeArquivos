using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Common.Domain.Service;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Helpers;
using GerenciadorDeArquivos.Domain.Interfaces.Repository;
using GerenciadorDeArquivos.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Services
{
    public class ArquivoService<TContext> : ServiceBase<TContext, Arquivo, int>, IArquivoService<TContext>
                           where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IArquivoRepository<TContext> _repository;

        private readonly IUsuarioLogado _usuarioLogado;

        #endregion

        #region [ Construtor ]

        public ArquivoService(IArquivoRepository<TContext> repository,
                              IUsuarioLogado usuarioLogado) : base(repository)
        {
            _repository = repository;
            _usuarioLogado = usuarioLogado;
        }

        #endregion

        #region [ Métodos ]

        public override async Task<Arquivo> CreateAsync(Arquivo entity)
        {
            entity.AtualizarUsuarioCadastro(_usuarioLogado.Usuario.Id);
            return await base.CreateAsync(entity);
        }

        public async Task DeleteArquivoAsync(int id)
        {
            var arquivo = await _repository.GetByIdAsync(id);

            arquivo.Inativar();
            arquivo.AtualizarDataAlteracao(DateTime.Now);
            arquivo.AtualizarUsuarioAlteracao(_usuarioLogado.Usuario.Id);

            base.Update(arquivo);
        }

        public async Task<(List<ArquivoDto>, int)> GetArquivoAsync(DateTime dataInicial, DateTime dataFinal, int arquivoTipoId, string nome, string alias, int pagina, bool exportar = false)
            => await _repository.GetArquivoAsync(_usuarioLogado.Usuario.Id, dataInicial, dataFinal, arquivoTipoId, nome, alias, pagina, exportar);

        public async Task<Arquivo> UpdateArquivoAsync(int id, Arquivo entity)
        {
            var arquivo = await _repository.GetByIdAsync(id);

            arquivo.AtualizarDataAlteracao(DateTime.Now);
            arquivo.AtualizarUsuarioAlteracao(_usuarioLogado.Usuario.Id);
            arquivo.AtualizarAlias(entity.Alias);

            return _repository.Update(arquivo);
        }

        public async Task<UploadArquivoDto> UploadArquivo(IFormFile file)
            => await _repository.UploadArquivo(file);

        #endregion
    }
}
