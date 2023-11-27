using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodManageCodeFirst.Models;
using FoodManageCodeFirst.FoodRepository;

namespace FoodManageCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly FoodManagementContext _context;
        private readonly IItem _iitem;

        public ItemsController(FoodManagementContext context,IItem ItemRepo)
        {
            _context = context;
            _iitem = ItemRepo;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            return await _context.Item.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            //var item = await _context.Item.FindAsync(id);

            //if (item == null)
            //{
            //    return NotFound();
            //}

            //return item;
            try
            {
                return await _iitem.GetItem(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            //_context.Item.Add(item);
            //await _context.SaveChangesAsync();
            await _iitem.PostItem(item);

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            //var item = await _context.Item.FindAsync(id);
            //if (item == null)
            //{
            //    return NotFound();
            //}

            //_context.Item.Remove(item);
            //await _context.SaveChangesAsync();

            //return item;
            try
            {
               return  await _iitem.DeleteItem(id);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemId == id);
        }
    }
}
