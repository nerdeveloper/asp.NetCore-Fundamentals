using System.ComponentModel.DataAnnotations;
using odetofood.Entities;
namespace odetofood.ViewModel

{
    public class RestuarantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
