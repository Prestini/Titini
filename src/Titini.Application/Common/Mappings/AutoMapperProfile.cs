﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Titini.Application.Common.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            LoadCustomMappings();
        }
        private void LoadCustomMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}
