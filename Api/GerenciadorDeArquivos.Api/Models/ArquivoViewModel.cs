using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Domain.Entities;

namespace GerenciadorDeArquivos.Api.Models
{
    public class ArquivoViewModel : IViewModel<Arquivo>
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public int ArquivoTipoId { get; set; }

        public Arquivo Model()
        {
            var arquivo = new Arquivo(this.Id, this.Alias, this.Nome, this.ArquivoTipoId);

            if (this.Id.Equals(0))
            {
                arquivo.AtualizarDataCadastro(DateTime.Now);
                arquivo.AtualizarCaminho(this.Caminho);
                arquivo.Ativar();
            }

            return arquivo;
        }
    }
}
