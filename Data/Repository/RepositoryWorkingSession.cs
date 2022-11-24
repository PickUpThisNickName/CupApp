using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;

namespace CupApplication.Data.Repository
{
    public class RepositoryWorkingSession : IWorkingSession
    {
        private readonly AppDBContent content;
        public RepositoryWorkingSession(AppDBContent appDBContent)
        {
            this.content = appDBContent;
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
    }
}
