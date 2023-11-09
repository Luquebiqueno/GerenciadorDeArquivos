using GerenciadorDeArquivos.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Entities
{
    public class Arquivo : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Alias { get; protected set; }
        public string Nome { get; protected set; }
        public string Caminho { get; protected set; }
        public int ArquivoTipoId { get; protected set; }

        #endregion

        #region [ Construtor ]

        public Arquivo() { }
        public Arquivo(int id, string alias, string nome, int arquivoTipoId)
        {
            AtualizarId(id);
            AtualizarAlias(alias);
            AtualizarNome(nome);
            AtualizarArquivoTipoId(arquivoTipoId);
        }

        #endregion

        #region [ Métodos ]

        public void AtualizarAlias(string alias) => this.Alias = alias;
        public void AtualizarNome(string nome) => this.Nome = nome;
        public void AtualizarCaminho(string caminho) => this.Caminho = caminho;
        public void AtualizarArquivoTipoId(int arquivoTipoId) => this.ArquivoTipoId = arquivoTipoId;

        #endregion
    }
}
