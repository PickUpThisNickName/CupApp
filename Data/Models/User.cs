using Microsoft.AspNetCore.Identity;

namespace CupApplication.Data.Models
{
    public class User:IdentityUser
    {
        public string StartDate { get; set; }
        public float HoursWorked { get; set; }
    }
}
