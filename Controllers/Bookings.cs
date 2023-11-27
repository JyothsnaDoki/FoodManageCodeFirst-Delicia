using FoodManageCodeFirst.Models.Models;
using FoodManageCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FoodManageCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bookings : ControllerBase
    {

        private readonly FoodManagementContext foodManagementContext;
        public Bookings(FoodManagementContext foodManagementContext)
        {
            this.foodManagementContext = foodManagementContext;
        }
        //get all Items
        [HttpGet]
        //[Route("GetItems")]
        public List<Booking> GetBookings()
        {
            return foodManagementContext.Booking.ToList();
        }

        //get by id
        [HttpGet]
        [Route("{Cid}")]
        public Booking GetBooking(int Cid)
        {
            return foodManagementContext.Booking.Where(x => x.CId == Cid).FirstOrDefault();

        }

        //[HttpGet]
        //[Route("ById/{Userid}")]
        //public Booking GetBookingById(int Userid)
        //{
        //    return foodManagementContext.Booking.Where(x => x.UserId == Userid).FirstOrDefault();

        //}
        [HttpGet]
        [Route("ById/{UserId}")]
        public IEnumerable<Booking> GetBookingsByUserId(int UserId)
        {
            return foodManagementContext.Booking.Where(x => x.UserId == UserId).ToList();
        }




        [HttpPost]
        // [Route("AddItem")]
        public string AddBooking(Booking booking)
        {
            string response = string.Empty;
            foodManagementContext.Booking.Add(booking);
            foodManagementContext.SaveChanges();
            return "Booking added";
        }
        [HttpPut]
        // [Route("UpdateItem")]
        public string UpdateBooking(Booking booking)
        {
            foodManagementContext.Entry(booking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            foodManagementContext.SaveChanges();
            return "Booking Updated";
        }




        [HttpDelete("{Cid}")]
        // [Route("DeleteItem")]
        public string DeleteBooking(int Cid)
        {
            Booking booking = foodManagementContext.Booking.Where((x) => x.CId == Cid).FirstOrDefault();
            if (booking != null)
            {
                foodManagementContext.Booking.Remove(booking);
                foodManagementContext.SaveChanges();
                return "Booking Deleted";
            }
            else
            {
                return "No BookingFound";
            }

        }
    }
}






