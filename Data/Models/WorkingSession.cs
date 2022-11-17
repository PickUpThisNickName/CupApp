using System.Security.Policy;

namespace CupApplication.Data.Models
{
    public class WorkingSession
    {
        public int Id { get; set; }
        public string OpenDate { get; set; }
        public string OpenTime { get; set; }
        public string CloseDate { get; set; }
        public string CloseTime{ get; set; }
        public int WorkerID { get; set; }
        public string Name { get; set; }
    }
}
