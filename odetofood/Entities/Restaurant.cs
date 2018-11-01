using System;
using System.ComponentModel.DataAnnotations;

namespace odetofood.Entities
{
    public enum CuisineType
    {
        None, 
        Italian,
        French,
        Japanese,
        American
    }
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        [Display(Name="Resturant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set;  }
    }
}
