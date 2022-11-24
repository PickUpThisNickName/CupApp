using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CupApplication.Data.Repository
{
    public class RepositoryUsers : IUsers
    {
        private readonly UsersContext _userscontent;
        private readonly UserManager<User> _userManager;
        private readonly AppDBContent _appDBContent;
        public RepositoryUsers(UsersContext userscontent, UserManager<User> userManager, AppDBContent appDBContent)
        {
            this._userscontent = userscontent;
            _userManager = userManager;
            _appDBContent = appDBContent;
        }

        public IQueryable<User> GetAllUsersContent()
        {
            IQueryable<User> allusers = _userManager.Users.Where(User => !User.UserName.Equals("CupAdmin"));
            return allusers;
        }

        public WorkingSession GetLastSession(string userId)
        {
            WorkingSession session = new WorkingSession();
            if (userId != null)
                session = _appDBContent.DB_WorkingSession.Include(b => b.GroupObj).LastOrDefault();
            return session;
        }
    }
}
