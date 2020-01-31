using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Titini.Application.Common.Mappings
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
