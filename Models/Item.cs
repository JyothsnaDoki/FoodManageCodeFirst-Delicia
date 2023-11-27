using System.ComponentModel.DataAnnotations;

namespace FoodManageCodeFirst.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string ItemAvailability { get; set; }
    }
}
