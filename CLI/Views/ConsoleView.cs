using CLI.Enums;

namespace CLI.Views
{
    public class ConsoleView
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("1. Add new task");
            Console.WriteLine("2. Update task");
            Console.WriteLine("3. Delete task");
            Console.WriteLine("4. Show all tasks");
            Console.WriteLine("0. Exit");
        }

        public Task ShowTaskCreateDetailsMenu()
        {
            Console.WriteLine("Enter task title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter task description: ");
            string description = Console.ReadLine();

            return new Task { Title = title, Description = description };
        }

        public Task ShowTaskUpdateDetailsMenu()
        {
            Console.WriteLine("Enter task title or press Enter to continue: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter task description  or press Enter to continue: ");
            string description = Console.ReadLine();

            Console.WriteLine("Pick status:");
            Console.WriteLine("1. To Do");
            Console.WriteLine("2. In Progress");
            Console.WriteLine("3. Done");
            int statusNum = int.Parse(Console.ReadLine());

            return new Task
            {
                Title = title,
                Description = description,
                Status = (Status)statusNum,
            };
        }

        public int GetTaskId(string action)
        {
            Console.WriteLine($"Enter task id to {action} it:");
            int id = int.TryParse(Console.ReadLine(), out int value) ? value : -1;
            return id;
        }

        public void DisplayTasks(IEnumerable<Task> tasks)
        {
            foreach (Task task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine($"Created At: {task.CreatedAt}");
                Console.WriteLine("--------------------------------");

                if (task.UpdatedAt is not null)
                {
                    Console.WriteLine($"Updated At: {task.UpdatedAt}");
                }
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
