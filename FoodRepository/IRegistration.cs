using System;
using FoodManageCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace FoodManageCodeFirst.FoodRepository
{
    public interface IRegistration
    {
        Task<ActionResult<IEnumerable<Registration>>> GetRegistration();
        Task<ActionResult<Registration>> GetRegistration(int id);
        Task<ActionResult<Registration>> GetRegisterUserByAuth(String email, String password);
        Task<IActionResult> PutRegistration(int id, Registration registration);
        Task<ActionResult<Registration>>PostRegistration(Registration registration);
        Task<ActionResult<Registration>> DeleteRegistration(int id);
    }
}
