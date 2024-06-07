namespace TaskManager.Models.Dto
{
    public class CreateTaskDto
    {
        public int AssignedBy { get; set; }
        public string Name { get; set; }
        public string Assigment { get; set; }
        public DateTime StartDate { get; set; }
        public int StartHours { get; set; }
        public int StartMinutes { get; set; }
        public DateTime EndDate { get; set; }
        public int EndHours { get; set; }
        public int EndMinutes { get; set; }
        public int AssignedTo { get; set; }

    }
}
