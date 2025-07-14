using System.Text.Json;
using CLI.Serialization;

namespace CLI.Repository
{
    public class JsonRepository : IRepository
    {
        private readonly string fullPath;
        private List<Task> tasks;
        private int nextId;
        public JsonRepository(string filePath)
        {
            fullPath = MakeFullPath(filePath);
            LoadTasks();
            nextId = tasks.Any() ? tasks.Max(x => x.Id) + 1 : 1;
        }

        private string MakeFullPath(string filePath)
        {
            string currentDir = AppContext.BaseDirectory;
            string projectDir = Path.GetFullPath(@"..\..\..\..\", currentDir);
            string fullPath = Path.Combine(projectDir, "CLI", filePath);
            return fullPath;
        }

        private void LoadTasks()
        {
            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                tasks = JsonSerializer.Deserialize<List<Task>>(json, JsonOptions.Default) ?? [];
            }
            else
            {
                tasks = [];
            }
        }

        private void SaveTasks()
        {
            string json = JsonSerializer.Serialize(tasks, JsonOptions.Default);
            File.WriteAllText(fullPath, json);
        }

        public void Add(Task task)
        {
            task.Id = nextId++;
            tasks.Add(task);
            SaveTasks();
        }

        public void Delete(int id)
        {
            Task task = tasks.FirstOrDefault(x => x.Id == id);
            if (task is not null)
            {
                tasks.Remove(task);
                SaveTasks();
            }
        }

        public IEnumerable<Task> GetAll() => tasks;

        public Task GetById(int id) => tasks.FirstOrDefault(x => x.Id == id);

        public void Update(Task task)
        {
            Task existingTask = tasks.FirstOrDefault(x => x.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
                existingTask.UpdatedAt = DateTime.UtcNow;
            }
            SaveTasks();
        }
    }
}
