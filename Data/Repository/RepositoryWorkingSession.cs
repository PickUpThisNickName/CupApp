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
                        OpenDate = p.OpenDate,
                        OpenTime = p.OpenTime,
                        CloseDate = p.CloseDate,
                        CloseTime = p.CloseTime,
                        WorkerID = p.WorkerID,
                        Name = p.Name
                    }).ToList();
        }

        WorkingSession IWorkingSession.getObject(int Id)
        {
            return content.DB_WorkingSession.FirstOrDefault(p => p.Id == Id);
        }
    }
}
