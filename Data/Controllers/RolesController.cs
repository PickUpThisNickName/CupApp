using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CupApplication.Migrations.Users;
using CupApplication.Data.Models;
using CupApplication.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private IPasswordHasher<User> passwordHasher;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IPasswordHasher<User> passwordHash)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            passwordHasher = passwordHash;
        }
        public async Task<IActionResult> UserList()
        {
            IQueryable<User> allusers = _userManager.Users.Where(User => !User.UserName.Equals("CupAdmin"));
            ChangeRoleViewModel model = new ChangeRoleViewModel();

            foreach (var item in allusers)
            {
                ChangeRoleModel rolemodel = new ChangeRoleModel
                {
                    User = item,
                    AllRoles = _roleManager.Roles.ToList(),
                };
                var userroles = await _userManager.GetRolesAsync(item);
                if (userroles.Any())
                    rolemodel.UserRoles = userroles;
                model.Add(rolemodel);

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("UserList");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return RedirectToAction("UserList");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return RedirectToAction("UserList");
        }

        public async Task<IActionResult> Update(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("UserList");
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string password)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(password))
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, password);

                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("UserList");
                    else
                        Errors(result);

                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }
    }
}
