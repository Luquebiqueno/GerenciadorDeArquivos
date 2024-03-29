﻿using GerenciadorDeArquivos.Common.Application;
using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Interfaces.Application;
using GerenciadorDeArquivos.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Application.ServiceApplications
{
    public class UsuarioApplication<TContext> : ApplicationBase<TContext, Usuario, int>, IUsuarioApplication<TContext>
                               where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IUsuarioService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public UsuarioApplication(IUnitOfWork<TContext> context, IUsuarioService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public async Task<Usuario> GetUsuarioLogadoAsync()
            => await _service.GetUsuarioLogadoAsync();
        public async Task<Usuario> UpdateUsuarioAsync(int id, Usuario entity)
        {
            await _service.UpdateUsuarioAsync(id, entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task AlterarSenhaAsync(string senha)
        {
            await _service.AlterarSenhaAsync(senha);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteUsuarioAsync()
        {
            await _service.DeleteUsuarioAsync();
            await _unitOfWork.CommitAsync();
        }

        #endregion
    }
}
