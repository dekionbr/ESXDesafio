using ApplicationCore.ESX.Entities;
using ApplicationCore.ESX.ViewModels;
using AutoMapper;

namespace ApplicationCore.ESX.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Assets, AssetsViewModel>()
                .ForMember(a => a.NumberAssets, a => a.Ignore());

            CreateMap<Brand, BrandViewModel>();

        }
    }
}