using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodManageCodeFirst.Models;
using Microsoft.Extensions.Logging;
using FoodManageCodeFirst.FoodRepository;
using System.Collections;

namespace FoodManageCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly FoodManagementContext _context;
        private readonly ILogger<RegistrationsController> _logger;
        private readonly IRegistration _iregistration;

        public RegistrationsController(FoodManagementContext context, ILogger<RegistrationsController> logger,
            IRegistration RegistrationRepo)
        {
            _context = context;
            _logger = logger;
            _iregistration =RegistrationRepo;
        }

        // GET: api/RegisterUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
            _logger.LogWarning("Getting all the users successfully.");
            //return await _context.users.ToListAsync();
            return await _iregistration.GetRegistration();
        }

        // GET: api/RegisterUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            //var registerUser = await _context.users.FindAsync(id);

            //if (registerUser == null)
            //{
            //    _logger.LogError("Sorry, no user found with this id " + id);
            //    return NotFound();
            //}

            //return registerUser;
            try
            {
                return await _iregistration.GetRegistration(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }



        // Authenticating user by their email and password
        // GET: api/RegisterUsers/alan@gmail.com/alan1
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<Registration>> GetRegisterUserByAuth(string email, string password)
        {
            //try
            //{
            //    return await _registerUsersRepository.GetRegisterUserByPwd(email, password);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);

            //    return NotFound();
            //}

            Hashtable err = new Hashtable();
            try
            {
                var authUser = await _iregistration.GetRegisterUserByAuth(email, password);
                if (authUser != null)
                {
                    return Ok(authUser);
                }
                else
                {
                    err.Add("Status", "Error");

                    err.Add("Message", "Invalid Credentials");

                    return Ok(err);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Route("Login")]
        //public ActionResult Login(string email, string pwd)//([FromBody] User user)

        //{
        //    Hashtable err = new Hashtable();

        //    try
        //    {
        //        var result = _context.users.Where(x => x.Email.Equals(email) && x.Password.Equals(pwd)).FirstOrDefault();
        //        if (result != null) return Ok(result);
        //        else

        //        {

        //            err.Add("Status", "Error");

        //            err.Add("Message", "Invalid Credentials");

        //            return Ok(err);

        //        }
        //    }

        //    catch (Exception)

        //    {
        //        throw;

        //    }

        //    return null;
        //}

        // PUT: api/RegisterUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, Registration registration)
        {
            //if (id != registerUser.UserId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(registerUser).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RegisterUserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            //_logger.LogInformation("User updated successfully.");
            //return NoContent();

            if (id != registration.UserId)
            {
                return BadRequest();
            }

            _context.Entry(registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!registrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogInformation("User updated successfully.");

            return NoContent();
        }

        private bool registrationExists(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/RegisterUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            //_context.users.Add(registerUser);
            //await _context.SaveChangesAsync();
            //_logger.LogInformation("User created successfully.");

            //return CreatedAtAction("GetRegisterUser", new { id = registerUser.UserId }, registerUser);
            await _iregistration.PostRegistration(registration);
            _logger.LogWarning("User created successfully.");
            return CreatedAtAction("GetRegisterUser", new { id = registration.UserId }, registration);
        }

        // DELETE: api/RegisterUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            try
            {
                return await _iregistration.DeleteRegistration(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }


        [HttpGet("checkDuplicateUser")]
        public IActionResult CheckDuplicateUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email cannot be empty.");
            }

            var existingUser = _context.Registration.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return Ok(new { isDuplicate = true });
            }

            return Ok(new { isDuplicate = false });
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registration.Any(e => e.UserId == id);
        }
    }
}





//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using FoodManageCodeFirst.Models;
//using Microsoft.Extensions.Logging;
//using log4net.Repository.Hierarchy;
//using FoodManageCodeFirst.FoodRepository;

//namespace FoodManageCodeFirst.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RegistrationsController : ControllerBase
//    {
//        private readonly FoodManagementContext _context;
//        //private readonly ILogger<RegistrationsController> _logger;
//        private readonly IRegistration _RegistrationRepo;

//        public RegistrationsController(FoodManagementContext context,IRegistration RegistrationRepo)
//        {
//            _context = context;
//            //_logger = logger;
//            _RegistrationRepo = RegistrationRepo;
//        }

//        //public IActionResult Index()
//        //{
//        //    _logger.LogInformation("Hey, this is an INFO message.");
//        //    _logger.LogWarning("Hey, this is a WARNING message.");
//        //    _logger.LogError("Hey, this is an ERROR message.");
//        //    _logger.LogCritical("This is acritical message");
//        //    return Ok();
//        //}

//        // GET: api/Registrations
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
//        {
//            //_logger.LogInformation("Hey, Getting user details successfully.");
//            return await _RegistrationRepo.GetRegistration();
//        }

//        // GET: api/Registrations/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Registration>> GetRegistration(int id)
//        {
//            var registration = await _context.Registration.FindAsync(id);

//            if (registration == null)
//            {
//                return NotFound();
//            }

//            return registration;
//        }

//        [HttpGet("{email}/{password}")]
//        public async Task<ActionResult<Registration>> GetRegisterUserByAuth(String email, String password)
//        {
//            var registerUser = await _context.Registration.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

//            if (registerUser == null)
//            {
//                return NotFound();
//            }

//            return registerUser;
//        }

//        // PUT: api/Registrations/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutRegistration(int id, Registration registration)
//        {
//            if (id != registration.UserId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(registration).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!RegistrationExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Registrations
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
//        {
//            _context.Registration.Add(registration);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetRegistration", new { id = registration.UserId }, registration);
//        }

//        // DELETE: api/Registrations/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
//        {
//            var registration = await _context.Registration.FindAsync(id);
//            if (registration == null)
//            {
//                return NotFound();
//            }

//            _context.Registration.Remove(registration);
//            await _context.SaveChangesAsync();

//            return registration;
//        }

//        private bool RegistrationExists(int id)
//        {
//            return _context.Registration.Any(e => e.UserId == id);
//        }
//    }
//}
