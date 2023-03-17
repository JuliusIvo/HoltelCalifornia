using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models
{
    public class ApplicationUser
    {
        [Display(Name ="Name")]
        public string? Name { get; set; }
    }
}
