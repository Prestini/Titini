using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Titini.Application.Common.Mappings;
using Titini.Application.Requests.Clientes.Commands.Create;
using Titini.Application.Requests.Clientes.Commands.Update;
using Titini.Domain.Entities;

namespace Titini.Application.Requests.Clientes
{
    public class ClienteMappings : IHaveCustomMapping
    {
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Cliente, CreateClienteCommandResult>();
            configuration.CreateMap<Cliente, UpdateClienteCommandResult>();
        }
    }
}
