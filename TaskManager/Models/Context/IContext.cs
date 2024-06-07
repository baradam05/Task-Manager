namespace TaskManager.Models.Context
{
    public interface IContext
    {
        public void Save();
        public void Load();
    }
}
