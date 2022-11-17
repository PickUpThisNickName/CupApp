using CupApplication.Data.Models;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.Threading.Tasks;

namespace CupApplication.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string AdminName = "CupAdmin";
            string Adminpassword = "_Aa123456";
            string WorkerName = "Worker";
            string Workerpassword = "_Aa123456";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
                Log.Debug("Инициализирована Роль admin");

            }
            if (await roleManager.FindByNameAsync("worker") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("worker"));
                Log.Debug("Инициализирована Роль worker");

            }
            //создаем Админа если в БД его нет
            if (await userManager.FindByNameAsync(AdminName) == null)
            {
                User admin = new User { UserName = AdminName };
                IdentityResult result = await userManager.CreateAsync(admin, Adminpassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                    Log.Debug("Инициализирован Пользователь с ролью admin");
                }
            }
            //создаем Работника если в БД его нет
            if (await userManager.FindByNameAsync(WorkerName) == null)
            {
                User worker = new User { UserName = WorkerName };
                IdentityResult result = await userManager.CreateAsync(worker, Workerpassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(worker, "worker");
                    Log.Debug("Инициализирован Пользователь с ролью worker");
                }
            }
        }
    }
}