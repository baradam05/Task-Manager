using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models.dbModel;
using System.Runtime.CompilerServices;

namespace TaskManager.Models.Contexts
{
    public static class MyContext //: DbContext
    {
        //public DbSet<dbModel.Task> Task { get; set; }
        //public DbSet<User> User { get; set; }
        //public DbSet<UserTask> UserTask { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=yourdatabase;user=yourusername;password=yourpassword;SslMode=none");
        //}

        public static List<User> User { get; set; } = new List<User>();
        public static List<UserTask> UserTask { get; set; } = new List<UserTask>();
        public static List<Tasks> Tasks { get; set; } = new List<Tasks>();
    }

}
