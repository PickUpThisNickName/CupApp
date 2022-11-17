using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly IUsers _users;

        public UsersController(IUsers users)
        {
            _users = users;
        }
        [Route("Table6")]
        public ViewResult Table()
        {
            return View(_users.GetAllUsersContent());
        }
    }
}
