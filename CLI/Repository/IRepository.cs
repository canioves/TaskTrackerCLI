namespace CLI.Repository
{
    public interface IRepository
    {
        void Add(Task task);
        void Update(Task task);
        void Delete(int id);
        Task? GetById(int id);
        IEnumerable<Task> GetAll();
    }
}
