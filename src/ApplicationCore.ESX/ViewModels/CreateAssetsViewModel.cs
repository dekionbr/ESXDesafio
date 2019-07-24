using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ESX.ViewModels
{
    public class CreateAssetsViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
