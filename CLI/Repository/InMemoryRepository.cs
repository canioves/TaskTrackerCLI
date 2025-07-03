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
            Task? existingTask = tasks.FirstOrDefault(x => x.Id == id);

            if (existingTask != null)
                tasks.Remove(existingTask);
        }

        public IEnumerable<Task> GetAll() => tasks;

        public Task GetById(int id) => tasks.FirstOrDefault(x => x.Id == id);

        public void Update(Task task)
        {
            Task? existingTask = tasks.FirstOrDefault(x => x.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.IsCompleted = task.IsCompleted;
                existingTask.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
