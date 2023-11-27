using FoodManageCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodManageCodeFirst.FoodRepository
{
    public class RegistrationRepo : IRegistration
    {
       
            private readonly FoodManagementContext _context;


            public RegistrationRepo(FoodManagementContext context)
            {
                _context = context;

            }
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
            //_logger.LogInformation("Hey, Getting user details successfully.");
            return await _context.Registration.ToListAsync();
        }
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            var registration = await _context.Registration.FindAsync(id);

            //if (registration == null)
            //{
            //    return NotFound();
            //}

            return registration;
        }
        public async Task<ActionResult<Registration>> GetRegisterUserByAuth(String email, String password)
        {
            var registerUser = await _context.Registration.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            //if (registerUser == null)
            //{
            //    return NotFound();
            //}

            return registerUser;
        }
        public async Task<IActionResult> PutRegistration(int id, Registration registration)
        {
            //if (id != registration.UserId)
            //{
            //    return BadRequest();
            //}

            _context.Entry(registration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (IActionResult)registration;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RegistrationExists(id))
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
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRegistration", new { id = registration.UserId }, registration);
            return registration;
        }
        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            var registration = await _context.Registration.FindAsync(id);
            //if (registration == null)
            //{
            //    return NotFound();
            //}

            _context.Registration.Remove(registration);
            await _context.SaveChangesAsync();

            return registration;
        }
    }
    }

