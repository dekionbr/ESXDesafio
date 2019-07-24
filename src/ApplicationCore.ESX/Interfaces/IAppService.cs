using System.Collections.Generic;

namespace ApplicationCore.ESX.Interfaces
{
    public interface AppService<TCreateViewModel, TViewModel> : IBaseAppService
        where TCreateViewModel : class
        where TViewModel : class
    {
        void Register(TCreateViewModel viewModel);
        IEnumerable<TViewModel> GetAll();
        TViewModel GetById(int id);
        void Update(TViewModel viewModel);
        void Remove(int id);
    }
}
