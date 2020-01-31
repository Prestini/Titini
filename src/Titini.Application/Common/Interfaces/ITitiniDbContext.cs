using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Titini.Domain.Entities;

namespace Titini.Application.Common.Interfaces
{
    public interface ITitiniDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
