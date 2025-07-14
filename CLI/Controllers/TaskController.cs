using CLI.Services;
using CLI.Views;

namespace CLI.Controllers
{
    public class TaskController
    {
        private readonly TaskService service;
        private readonly ConsoleView view;

        public TaskController(TaskService service, ConsoleView view)
        {
            this.service = service;
            this.view = view;
        }

        public void Run()
        {
            while (true)
            {
                view.ShowMainMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Task newTask = view.ShowTaskCreateDetailsMenu();
                        service.CreateTask(newTask.Title, newTask.Description);
                        view.ShowMessage("Task is added!");
                        break;
                    case "2":
                        int updateId = view.GetTaskId("update");
                        Task existingTask = service.GetTaskById(updateId);

                        if (existingTask != null)
                        {
                            Task updatedTask = view.ShowTaskUpdateDetailsMenu();
                            
                            existingTask.Title = string.IsNullOrEmpty(updatedTask.Title)
                                ? existingTask.Title
                                : updatedTask.Title;
                            existingTask.Description = string.IsNullOrEmpty(updatedTask.Description)
                                ? existingTask.Description
                                : updatedTask.Description;
                            existingTask.Status = updatedTask.Status;

                            service.UpdateTask(existingTask);
                            view.ShowMessage("Task is updated!");
                        }
                        else
                            view.ShowMessage("Task is not found.");
                        break;
                    case "3":
                        int deleteId = view.GetTaskId("delete");
                        service.DeleteTask(deleteId);
                        view.ShowMessage("Task is deleted!");
                        break;
                    case "4":
                        IEnumerable<Task> tasks = service.GetAllTasks();
                        view.DisplayTasks(tasks);
                        break;
                    case "0":
                        return;
                    default:
                        view.ShowMessage("Unknown choice.");
                        break;
                }
            }
        }
    }
}
