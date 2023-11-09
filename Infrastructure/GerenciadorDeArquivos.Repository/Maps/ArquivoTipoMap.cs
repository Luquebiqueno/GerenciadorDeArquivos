using GerenciadorDeArquivos.Common.Infrastructure.Map;
using GerenciadorDeArquivos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Repository.Maps
{
    public class ArquivoTipoMap : EntityBaseMap<ArquivoTipo, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<ArquivoTipo> builder)
        {
            builder.ToTable("ArquivoTipo", "dbo");
            builder.Property(x => x.Id).HasColumnName("ArquivoTipoId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(30).IsRequired();

            builder.Ignore(x => x.UsuarioCadastro);
            builder.Ignore(x => x.UsuarioAlteracao);
            builder.Ignore(x => x.DataCadastro);
            builder.Ignore(x => x.DataAlteracao);
            builder.Ignore(x => x.Ativo);
        }
    }
}
