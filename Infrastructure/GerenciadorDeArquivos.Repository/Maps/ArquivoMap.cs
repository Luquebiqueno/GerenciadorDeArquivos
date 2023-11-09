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
    public class ArquivoMap : EntityBaseMap<Arquivo, int>
    {
        protected override void ConfigurarMapeamento(EntityTypeBuilder<Arquivo> builder)
        {
            builder.ToTable("Arquivo", "dbo");
            builder.Property(x => x.Id).HasColumnName("ArquivoId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Alias).HasColumnName("Alias").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Caminho).HasColumnName("Caminho").HasColumnType("varchar").HasMaxLength(400).IsRequired();
            builder.Property(x => x.ArquivoTipoId).HasColumnName("ArquivoTipoId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.UsuarioCadastro).HasColumnName("UsuarioCadastro").HasColumnType("int").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnName("DataAlteracao").HasColumnType("datetime");
            builder.Property(x => x.UsuarioAlteracao).HasColumnName("UsuarioAlteracao").HasColumnType("int");
            builder.Property(x => x.Ativo).HasColumnName("Ativo").HasColumnType("bit").IsRequired();
        }
    }
}
