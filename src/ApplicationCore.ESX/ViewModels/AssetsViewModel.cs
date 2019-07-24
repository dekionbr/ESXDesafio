using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ESX.ViewModels
{
    public class AssetsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public int BrandId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "NumberAssets")]
        public int NumberAssets { get; set; }
    }
}
