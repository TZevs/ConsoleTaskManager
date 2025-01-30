using Spectre.Console;
using Terminal.Gui;

namespace ToDoListManager
{
    internal class Program
    {
        public static List<Tasks> allTasks = new List<Tasks>();
        public static List<string> tags = new List<string> { "PSP", "Mobile Dev", "Meeting", "Doctor", "Home", "BDay", "None", "Add" };
        static void Main(string[] args)
        {
            var taskTable = new Table();
            taskTable.AddColumn("Title");
            taskTable.AddColumn("Priority");
            taskTable.AddColumn("Due Date");
            taskTable.AddColumn("SubTasks");
            taskTable.AddColumn("Tags");
            taskTable.AddColumn("Status");

            foreach (Tasks t in allTasks)
            {
                taskTable.AddRow(t.GetTaskTitle());
                taskTable.AddRow(t.GetTaskPriority());
                taskTable.AddRow(t.GetDueDate().ToString());
                foreach (var sub in t.GetSubTasks())
                {
                    taskTable.AddRow(sub);
                }
                taskTable.AddRow(t.GetStatus());
                taskTable.AddRow(t.GetTags());
            }

        }

        public static void addTask()
        {
            Console.WriteLine("Create Task");
            var taskName = AnsiConsole.Ask<string>("Task Name:");

            var priority = AnsiConsole.Prompt(
                new TextPrompt<string>("Task Priority:")
                    .AddChoices(["High", "Medium", "Low"]));

            var confirmDate = AnsiConsole.Prompt(
                new TextPrompt<bool>("Add Due Date?")
                .AddChoices([true, false])
                .WithConverter(choice => choice ? "y" : "n"));

            DateTime? dueDate = new DateTime();
            if (confirmDate)
            {
                dueDate = AnsiConsole.Prompt(
                    new TextPrompt<DateTime>("Due Date:"));
            }

            List<string>? subTasks = new List<string>();
            var confirmSubTasks = AnsiConsole.Prompt(
                new TextPrompt<bool>("Add SubTasks?")
                .AddChoices([true, false])
                .WithConverter(choice => choice ? "y" : "n"));

            if (confirmSubTasks)
            {
                while(true)
                {
                    var subTask = AnsiConsole.Ask<string>(">>");
                    if (subTask == String.Empty) { break; }
                    else { subTasks.Add(subTask); }
                }
            }

            var taskTag = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Task Tag:")
                    .PageSize(7)
                    .AddChoices(tags));

            Tasks newTask = new Tasks(taskName, priority, dueDate, subTasks, taskTag);
            allTasks.Add(newTask);
        }
        
    }
}
