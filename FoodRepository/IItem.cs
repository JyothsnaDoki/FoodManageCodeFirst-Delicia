using FoodManageCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodManageCodeFirst.FoodRepository
{
    public interface IItem
    {
        Task<ActionResult<IEnumerable<Item>>> GetItem();
        Task<ActionResult<Item>> GetItem(int id);
        Task<IActionResult> PutItem(int id, Item item);
        Task<ActionResult<Item>> PostItem(Item item);
        Task<ActionResult<Item>> DeleteItem(int id);
    }
}
