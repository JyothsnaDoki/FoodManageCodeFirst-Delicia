using FoodManageCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;






namespace FoodManageCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class feeds : ControllerBase
    {

        private readonly FoodManagementContext _context;

        public feeds(FoodManagementContext context)
        {
            _context = context;
        }

        // GET: api/feeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<feed>>> GetFeed()
        {
            return await _context.Feed.ToListAsync();
        }

        // GET: api/feeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<feed>> Getfeed(int id)
        {
            var feed = await _context.Feed.FindAsync(id);

            if (feed == null)
            {
                return NotFound();
            }

            return feed;
        }

        // PUT: api/feeds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfeed(int id, feed feed)
        {
            if (id != feed.feedId)
            {
                return BadRequest();
            }

            _context.Entry(feed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!feedExists(id))
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

        private bool feedExists(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/feeds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<feed>> Postfeed(feed feed)
        {
            _context.Feed.Add(feed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfeed", new { id = feed.feedId }, feed);
        }

        // DELETE: api/feeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<feed>> Deletefeed(int id)
        {
            var feed = await _context.Feed.FindAsync(id);
            if (feed == null)
            {
                return NotFound();
            }

            _context.Feed.Remove(feed);
            await _context.SaveChangesAsync();

            return feed;
        }

        
    }
}