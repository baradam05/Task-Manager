using Microsoft.EntityFrameworkCore;
using TaskManager.Models.dbModel;

namespace TaskManager.Models.Contexts
{
    public interface IContext
    {
        public DbSet<dbModel.Task> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserTask> UserTask { get; set; }

        public void SaveContext();
    }
}
