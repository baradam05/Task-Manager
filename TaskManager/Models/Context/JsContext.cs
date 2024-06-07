using Newtonsoft.Json;
using NuGet.Protocol;
using System.Text.Json;
using TaskManager.Models.DbModel;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TaskManager.Models.Context
{
    public class JsContext : IContext
    {
        public void Load()
        {
            string Js;

            CheckFolder();
            using (StreamReader sw = new StreamReader(Context.settings.JsPath + @"\Data.txt"))
            {
                Js = sw.ReadToEnd();
            }

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            if (Js == null || Js == "")
                return;

            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(Js, options);

            if (data.ContainsKey(nameof(User)))
                Context.User = JsonSerializer.Deserialize<List<User>>(data[nameof(User)].ToString(), options);

            if (data.ContainsKey(nameof(Tasks)))
                Context.Tasks = JsonSerializer.Deserialize<List<Tasks>>(data[nameof(Tasks)].ToString(), options);

            if (data.ContainsKey(nameof(UserTask)))
                Context.UserTask = JsonSerializer.Deserialize<List<UserTask>>(data[nameof(UserTask)].ToString(), options);

            if (data.ContainsKey(nameof(Settings)))
                Context.settings = JsonSerializer.Deserialize<Settings>(data[nameof(Settings)].ToString());
        }

        public void Save()
        {
            object data = new
            {
                Context.User,
                Context.Tasks,
                Context.UserTask,
                Context.settings
            };

            string js = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (StreamWriter sw = new StreamWriter(Context.settings.JsPath + @"\Data.txt"))
            {
                sw.WriteLine(js);
            }
        }

        public void CheckFolder()
        {
            if(!File.Exists(Context.settings.JsPath + @"\Data.txt"))
            {
                using (File.Create(Context.settings.JsPath + @"\Data.txt")) { } ;
            }
        }
    }
}
