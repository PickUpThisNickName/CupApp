using CupApplication.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CupApplication.Data.Interfaces
{
    public interface IUsers
    {
        IQueryable<User> GetAllUsersContent();
        User getObject(string Id);
    }
}
