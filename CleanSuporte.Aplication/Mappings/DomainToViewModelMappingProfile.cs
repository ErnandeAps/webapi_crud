using AutoMapper;
using CleanSuporte.Aplication.ViewModels;
using CleanSuporte.Domain.Entities;


namespace CleanSuporte.Aplication.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
       public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }

}
