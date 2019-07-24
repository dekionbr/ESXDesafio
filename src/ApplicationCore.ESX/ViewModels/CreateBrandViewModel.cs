using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ESX.ViewModels
{
    public class CreateBrandViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
