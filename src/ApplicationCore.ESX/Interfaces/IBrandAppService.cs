using ApplicationCore.ESX.ViewModels;
using System.Collections.Generic;

namespace ApplicationCore.ESX.Interfaces
{
    public interface IBrandAppService : AppService<CreateBrandViewModel, BrandViewModel>
    {
        IList<AssetsViewModel> GetAllAssetsByBrandId(int id);
    }
}
