using HotelProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required(ErrorMessage ="A room picture is required!")]
        [Display(Name="PictureUrl")]
        public string? PictureUrl { get; set; }

        [Required(ErrorMessage ="A room must have beds!")]
        [Display(Name="AmountOfBeds")]
        public int AmountOfBeds { get; set;}
        [Required(ErrorMessage ="A room must have a price!")]
       
        [Display(Name="PricePernight")]
        public double? PricePerNight { get; set; }
        [Display(Name="ReservedFrom")]
        public DateTime DateFrom { get; set; }
        [Display(Name="ReservedTo")]
        public DateTime DateTo { get; set; }
        [Required(ErrorMessage ="A room must have a name!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Name must be between 3 and 50 chars")]
        [Display(Name="Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="A room must have a type!")]
        [Display(Name="RoomType")]
        public RoomType RoomType { get; set; }

        public List<Order>? Orders { get;set; }

    }
}
