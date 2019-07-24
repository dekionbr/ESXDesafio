using ApplicationCore.ESX.Entities;
using ApplicationCore.ESX.Interfaces;
using ApplicationCore.ESX.ViewModels;
using AutoMapper;

namespace ApplicationCore.ESX.Services
{
    public class AssetsAppService : AppService<CreateAssetsViewModel, AssetsViewModel, Assets>, IAssetsAppService
    {
        public AssetsAppService(IMapper mapper, IRepository<Assets> repository) : base(mapper, repository)
        {
        }

        public override void Register(CreateAssetsViewModel viewModel)
        {
            var assets = _mapper.Map<Assets>(viewModel);

            _repository.Add(assets);
        }

        public override void Remove(int id)
        {
            var assets = _repository.GetById(id);
            _repository.Delete(assets);
        }

        public override void Update(AssetsViewModel viewModel)
        {
            var assets = _mapper.Map<Assets>(viewModel);
            _repository.Update(assets);
        }
    }
}
