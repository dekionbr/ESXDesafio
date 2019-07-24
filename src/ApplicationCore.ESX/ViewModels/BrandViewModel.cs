using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ESX.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
