using System;
using Microsoft.Extensions.DependencyInjection;
using CleanSuporte.Aplication.Mappings;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanSuporte.Mvc.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), 
                typeof(ViewModelToDomainMappingProfile));
        }
    }
}
