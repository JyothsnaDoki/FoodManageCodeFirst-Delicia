using FoodManageCodeFirst.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Policy;

namespace FoodManageCodeFirst.Models.Models
{
    public class Booking
    {

        [Required]
        [Key]

        public int CId { get; set; }
        public virtual int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual int ItemId { get; set; }
        [ForeignKey("ItemId")]

        [Required(ErrorMessage = "Item Name is required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string ItemName { get; set; }



        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity should be between 1 and 100")]
        public int Quantity { get; set; }



        [Required]
        public int total { get; set; }

        public virtual Item Mobiles { get; set; }
        public virtual Registration User { get; set; }
    }
}


