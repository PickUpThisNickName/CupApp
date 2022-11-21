using System.Collections.Generic;
using CupApplication.Data.Models;

namespace CupApplication.Data.Interfaces
{
    public interface IWorkingSession
    {
        List<WorkingSession> GetAllWorkingSessionsContent();
        WorkingSession getObject(string Id);
    }
}
