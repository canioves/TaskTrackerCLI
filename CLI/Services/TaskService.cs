using CLI.Repository;

namespace CLI.Services
{
    public class TaskService
    {
        private readonly IRepository repository;

        public TaskService(IRepository repository)
        {
            this.repository = repository;
        }

        public void CreateTask(string title, string description)
        {
            Task task = new Task { Title = title, Description = description };
            repository.Add(task);
        }
    }
}
