using HotelProject.Data.Enums;
using HotelProject.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Data.ViewModels
{
    public class RegisterVM
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "A name is required!")]
        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "An email is required!")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A password is required!")]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Password confirm is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "A phone number is required!")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public List<Order>? Users_Orders { get; set; }

    }
}
