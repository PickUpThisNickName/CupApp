using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CupApplication.Data.Repository
{
    public class RepositoryUsers : IUsers
    {
        private readonly UsersContext content;
        private readonly UserManager<User> _userManager;
        public RepositoryUsers(UsersContext appDBContent, UserManager<User> userManager)
        {
            this.content = appDBContent;
            _userManager = userManager;
        }

        public IQueryable<User> GetAllUsersContent()
        {
            IQueryable<User> allusers = _userManager.Users.Where(User => !User.UserName.Equals("CupAdmin"));
            return allusers;
        }
    }
}
