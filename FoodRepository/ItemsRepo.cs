using FoodManageCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodManageCodeFirst.FoodRepository
{
    public class ItemsRepo:IItem
    {
        private readonly FoodManagementContext _context;

        public ItemsRepo(FoodManagementContext context)
        {
            _context = context;
        }
        //GET:api/Items

        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            return await _context.Item.ToListAsync();
        }
        //GET:api/Items/2
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Item.FindAsync(id);


            if (item == null)
            {
                throw new NullReferenceException("Sorry,no item found with the given id" + id);
            }
            else {
                return item;
            }

           
        }
        //PUT:api/Items/2
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            //if (id != item.ItemId)
            //{
            //    return BadRequest();
            //}

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (IActionResult)item;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    IActionResult NotFound()
            //    {
            //        throw new NotImplementedException();
            //    }
            //    if (!ItemExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

       
        //POST:api/Items
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Item.Add(item);
            await _context.SaveChangesAsync();
            return item;

            //return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

       //DELETE/api/Items/2
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                throw new NullReferenceException("Sorry,unable to delete the item" + id);
            }
            else
            {
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();

                return item;
            }
        }
    }
}
