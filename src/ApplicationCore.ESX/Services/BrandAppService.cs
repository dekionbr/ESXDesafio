using ApplicationCore.ESX.Entities;
using ApplicationCore.ESX.Interfaces;
using ApplicationCore.ESX.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.ESX.Services
{
    public class BrandAppService : AppService<CreateBrandViewModel, BrandViewModel, Brand>, IBrandAppService
    {
        private readonly IRepository<Assets> _assetsRepository;

        public BrandAppService(IRepository<Assets> assetsRepository, IMapper mapper, IRepository<Brand> repository) : base(mapper, repository)
        {
            _assetsRepository = assetsRepository;
        }

        public override void Register(CreateBrandViewModel viewModel)
        {
            var brand = _mapper.Map<Brand>(viewModel);

            _repository.Add(brand);
        }

        public override void Remove(int id)
        {
            var brand = _repository.GetById(id);
            _repository.Delete(brand);
        }

        public override void Update(BrandViewModel viewModel)
        {
            var brand = _mapper.Map<Brand>(viewModel);
            _repository.Update(brand);
        }

        public IList<AssetsViewModel> GetAllAssetsByBrandId(int id) => _assetsRepository.ListAll().Where(x => x.BrandId == id)
            .ProjectTo<AssetsViewModel>(_mapper.ConfigurationProvider).ToList();
    }
}
