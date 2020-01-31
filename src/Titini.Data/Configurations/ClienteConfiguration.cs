using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Titini.Data.Extensions;
using Titini.Domain.Entities;

namespace Titini.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.ConfigureEntity();

            builder.HasKey(e => e.Id);

            builder.OwnsOne(e => e.Cnpj).Property(p => p.ValorSemFormatacao).HasColumnName("cnpj").HasMaxLength(14);

            builder.HasIndex(e => e.Cnpj).HasName("Index_CNPJ").IsUnique();

            builder.Property(e => e.RazaoSocial).HasColumnName("razao_social").HasMaxLength(256);
        }
    }
}
