using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Dto
{
    public class ArquivoDto
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
