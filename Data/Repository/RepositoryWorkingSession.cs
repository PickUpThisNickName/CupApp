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
                    select new WorkingSession(content)
                    {
                        SessionGuid = p.SessionGuid,
                        OpenTime = p.OpenTime,
                        CloseTime = p.CloseTime,
                        WorkerID = p.WorkerID,
                        Name = p.Name
                    }).ToList();
        }

        WorkingSession IWorkingSession.getObject(string Id)
        {
            return content.DB_WorkingSession.FirstOrDefault(p => p.SessionGuid == Id);
        }
    }
}
