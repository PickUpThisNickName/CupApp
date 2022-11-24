using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Policy;

namespace CupApplication.Data.Models
{
    public class WorkingSession
    {
        //private readonly AppDBContent appDBContent;
        //public WorkingSession(AppDBContent appDBContent)
        //{
        //    this.appDBContent = appDBContent;
        //}
        public int Id { get; set; }
        //public string SessionGuid { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public User GroupObj { get; set; }

        //public static WorkingSession GetWorkingSession(IServiceProvider service)
        //{
        //    ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        //    var context = service.GetService<AppDBContent>();
        //    string sessionId = session.GetString("SessionId") ?? Guid.NewGuid().ToString();
        //    session.SetString("SessionId", sessionId);
        //    return new WorkingSession(context) { SessionGuid = sessionId };
        //}
    }
}
