using Org.BouncyCastle.Bcpg.OpenPgp;

namespace TaskManager.Models.DbModel
{
    public class Settings
    {
        public string Context { get; set; }
        public string JsPath { get; set; }
        public string DbServer { get; set; }
        public string DbDatabase { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
        public int autoIncrement { get; set; } = 1;

    }
}
