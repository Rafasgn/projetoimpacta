using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");

            builder.HasKey(t => t.IdTarefa);

            builder.Property(t => t.IdTarefa)
            .HasColumnName("IdTarefa");

            builder.Property(t => t.Titulo)
            .HasColumnName("Titulo")
            .HasMaxLength(150)
            .IsRequired();

            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.Property(t => t.IdUsuario)
              .HasColumnName("IdUsuario")
              .IsRequired();

            builder.HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefa)
                .HasForeignKey(t => t.IdUsuario);
        }
    }
}
