using CLI.Controllers;
using CLI.Repository;
using CLI.Services;
using CLI.Views;

namespace CLI;

class Program
{
    static void Main(string[] args)
    {
        IRepository repository = new JsonRepository(@"Data\tasks.json");
        TaskService taskService = new TaskService(repository);
        ConsoleView view = new ConsoleView();
        TaskController taskController = new TaskController(taskService, view);

        taskController.Run();
    }
}
