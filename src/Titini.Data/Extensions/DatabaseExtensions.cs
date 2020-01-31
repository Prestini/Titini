using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Titini.Domain.Common;

namespace Titini.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static void ConfigureEntity<T>(this EntityTypeBuilder<T> builder) where T : Entity
        {
            builder.Property(e => e.DataCriacao).HasColumnName("data_criacao").ValueGeneratedOnAdd();

            builder.Property(e => e.UsuarioCriacao).HasColumnName("usuario_criacao").HasMaxLength(128);
            
            builder.Property(e => e.DataUltimaAlteracao).HasColumnName("data_ultima_alteracao").ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.UsuarioUltimaAlteracao).HasColumnName("usuario_ultima_alteracao").HasMaxLength(128);
        }
    }
}
