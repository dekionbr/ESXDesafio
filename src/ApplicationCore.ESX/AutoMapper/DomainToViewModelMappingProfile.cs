using ApplicationCore.ESX.Entities;
using ApplicationCore.ESX.ViewModels;
using AutoMapper;

namespace ApplicationCore.ESX.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CreateAssetsViewModel, Assets>()
                .ConstructUsing(c => new Assets(c.BrandId, c.Name, c.Description));
                        
            CreateMap<AssetsViewModel, Assets>();

            CreateMap<CreateBrandViewModel, Brand>()
                .ConstructUsing(c => new Brand(c.Name));

            CreateMap<BrandViewModel, Brand>();
        }
    }
}