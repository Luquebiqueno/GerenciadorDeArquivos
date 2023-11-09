using GerenciadorDeArquivos.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Entities
{
    public class ArquivoTipo : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Descricao { get; protected set; }

        #endregion

        #region [ Construtor ]

        public ArquivoTipo()
        {

        }

        public ArquivoTipo(int id, string descricao)
        {
            AtualizarId(id);
            AtualizarDescricao(descricao);
        }

        #endregion

        #region [ Métodos ]
        public void AtualizarDescricao(string descricao) => this.Descricao = descricao;

        #endregion
    }
}
