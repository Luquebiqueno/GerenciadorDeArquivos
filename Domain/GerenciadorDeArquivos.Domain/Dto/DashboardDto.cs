using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Domain.Dto
{
    public class DashboardDto
    {
        public string Mes { get; set; }
        public int Imagem { get; set; }
        public int Pdf { get; set; }
        public int Csv { get; set; }
    }
}
