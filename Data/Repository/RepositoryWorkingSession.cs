using System;
using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CupApplication.Data.Repository
{
    public class RepositoryWorkingSession : IWorkingSession
    {
        private readonly AppDBContent content;
        private readonly UsersContext _usersContext;
        private readonly IUsers _user;
        public RepositoryWorkingSession(AppDBContent appDBContent, UsersContext usersContext, IUsers user)
        {
            this.content = appDBContent;
            _usersContext = usersContext;
            _user = user;
        }

        public List<WorkingSession> GetAllWorkingSessionsContent()
        {
            return (from p in content.DB_WorkingSession
                    select new WorkingSession
                    {
                        Id = p.Id,
                        OpenTime = p.OpenTime,
                        CloseTime = p.CloseTime,
                        GroupObj = p.GroupObj,
                    }).ToList();
        }

        WorkingSession IWorkingSession.getObject(int Id)
        {
            return content.DB_WorkingSession.FirstOrDefault(p => p.Id == Id);
        }
        public WorkingSession GetLastSession(string userId)
        {
            WorkingSession session = new WorkingSession();
            if (userId != null)
            {
                User user = _user.getObject(userId);
                session = user.Sessions.Last();
            }
            return session;
        }
    }
}
