using Microsoft.EntityFrameworkCore;
using TaskManager.Models.DbModel;

namespace TaskManager.Models.Context
{
    public class MyContext : DbContext, IContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<UserTask> UserTask { get; set; }      
        public DbSet<Settings> Settings {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL($"server={Context.settings.DbServer};database={Context.settings.DbDatabase};user={Context.settings.DbUser};password={Context.settings.DbPassword};SslMode=none");
        }

        public void Save()
        {
            this.User.RemoveRange(this.User);
            this.Tasks.RemoveRange(this.Tasks);
            this.UserTask.RemoveRange(this.UserTask);
            this.Settings.RemoveRange(this.Settings);

            this.User.AddRange(Context.User);
            this.Tasks.AddRange(Context.Tasks);
            this.UserTask.AddRange(Context.UserTask);
            this.Settings.Add(Context.settings);

            base.SaveChanges();
        }

        public void Load()
        {
            Context.User = this.User.ToList();
            Context.Tasks = this.Tasks.ToList();
            Context.UserTask = this.UserTask.ToList();
            Context.settings = this.Settings.FirstOrDefault();
        }
    }

}
