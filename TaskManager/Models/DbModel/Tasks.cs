namespace TaskManager.Models.DbModel
{
    public class Tasks
    {
        public int Id { get; set; }
        public int AssignedBy { get; set; }
        public string Name { get; set; }
        public string Assigment { get; set; }
        public DateTime? Finished { get; set; }
        public DateTime StartDate { get;set; }
        public DateTime EndDate { get;set; }
    }
}
