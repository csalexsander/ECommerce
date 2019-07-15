using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Depence_Injector.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void ConfigureMappers (IServiceCollection service)
        {
            service.AddAutoMapper(typeof(EntityToModel), typeof(ModelToEntity));
        }
    }
}
