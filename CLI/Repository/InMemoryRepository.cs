namespace CLI.Repository
{
    public class InMemoryRepository : IRepository
    {
        private readonly List<Task> tasks = [];
        private int nextId = 1;

        public void Add(Task task)
        {
            task.Id = nextId++;
            tasks.Add(task);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
