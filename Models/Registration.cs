using System.ComponentModel.DataAnnotations;

namespace FoodManageCodeFirst.Models
{
    public class Registration
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="password and confirm password should be same")]
        public string ConfirmPassword { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(15)]
        public string Contact { get; set; }
       
       
        [MaxLength(100)]
        public string UserType { get; set; }
    }
}
