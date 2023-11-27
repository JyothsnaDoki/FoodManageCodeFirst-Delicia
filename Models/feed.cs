
using System.ComponentModel.DataAnnotations;
using FoodManageCodeFirst.Models;
namespace FoodManageCodeFirst.Models
{


    public class feed
    {
        [Key]
        public int feedId { get; set; }
        [Required]
        public string ItemName { get; set; }



        public string Text { get; set; }
        [Required]


        public int Rating { get; set; }
    }
}
