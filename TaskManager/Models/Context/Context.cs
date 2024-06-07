using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using TaskManager.Models.DbModel;

namespace TaskManager.Models.Context
{
    public static class Context
    {
        public static IContext active { get; set; }
        public static Settings settings { get; set; } = new Settings() { JsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)};

        public static List<User> User { get; set; } = new List<User>();

        public static List<Tasks> Tasks { get; set; } = new List<Tasks>();
        public static List<UserTask> UserTask { get; set; } = new List<UserTask>();

        public static void SetContext(IContext newContext)
        {
            Context.active = newContext;
        }

        public static void Save()
        {
            active.Save();
        }

        public static void Load()
        {
            active.Load();
        }


        public static int AutoIncrement()
        {
            return settings.autoIncrement++;
        }
    }
}
