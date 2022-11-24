using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CupApplication.Data.Models
{
    public class User:IdentityUser
    {
        public string StartDate { get; set; }
        public float HoursWorked { get; set; }
        public bool IsSessionSterted { get; set; } = default;
        public List<WorkingSession> Sessions { get; set; }

    }
}
