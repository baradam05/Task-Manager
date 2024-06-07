namespace TaskManager.Models.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Assigment { get; set; }
        public string Assignedby { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public TaskDto(int id, string name, string assigment, string assignedBy, DateTime from, DateTime to)
        {
            this.Id = id;
            this.Name = name;
            this.Assigment = assigment;
            this.Assignedby = assignedBy;
            this.From = from;
            this.To = to;
        }
    }
}
