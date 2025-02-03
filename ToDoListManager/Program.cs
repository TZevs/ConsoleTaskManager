using Spectre.Console;

namespace ToDoListManager
{
    internal class Program
    {
        public static List<Tasks> allTasks = new List<Tasks>();
        public static List<string> tags = new List<string> { "PSP", "Mobile Dev", "Meeting", "Doctor", "Home", "BDay", "None", "Add" };
        static void Main(string[] args)
        {
            displayTasks();

            var menu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Action:")
                    .AddChoices("New Task", "Complete Task", "Edit Tasks", "Filter", "Quit")
                );

            while (true)
            {
                switch (menu)
                {
                    case "New Task": addTask(); return;
                    case "Edit": editTasks(); return;
                    case "Filter": return;
                    case "Complete": return;
                    case "Quit": return;
                    default: break;
                }
            }
        }

        public static void addTask()
        {
            Console.Clear();
            Console.WriteLine("Create Task");
            var taskName = AnsiConsole.Ask<string>("Task Name:");

            var priority = AnsiConsole.Prompt(
                new TextPrompt<string>("Task Priority:")
                    .AddChoices(["High", "Medium", "Low"]));

            var confirmDate = AnsiConsole.Prompt(
                new TextPrompt<bool>("Add Due Date?")
                .AddChoices([true, false])
                .WithConverter(choice => choice ? "y" : "n"));

            DateOnly? dueDate = new DateOnly();
            if (confirmDate)
            {
                dueDate = AnsiConsole.Prompt(
                    new TextPrompt<DateOnly>("Due Date:"));
            }
            else
            {
                dueDate = null;
            }

            List<string> subTasks = new List<string>();
            var confirmSubTasks = AnsiConsole.Prompt(
                new TextPrompt<bool>("Add SubTasks?")
                .AddChoices([true, false])
                .WithConverter(choice => choice ? "y" : "n"));

            if (confirmSubTasks)
            {
                while(true)
                {
                    var subTask = AnsiConsole.Ask<string>(">>");
                    if (subTask == "0") { break; }
                    else { subTasks.Add(subTask); }
                }
            }
            else
            {
                subTasks.DefaultIfEmpty();
            }

            var taskTag = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Task Tag:")
                    .PageSize(7)
                    .AddChoices(tags));

            Tasks newTask = new Tasks(taskName, priority, dueDate, subTasks, taskTag);
            allTasks.Add(newTask);
            displayTasks();
        }
        public static void displayTasks()
        {
            Console.Clear();
            var taskTable = new Table();
            taskTable.AddColumn("Title");
            taskTable.AddColumn("Priority");
            taskTable.AddColumn("Due Date");
            taskTable.AddColumn("SubTasks");
            taskTable.AddColumn("Tags");
            taskTable.AddColumn("Status");

            foreach (Tasks t in allTasks)
            {
                var dueDate = t.GetDueDate()?.ToString() ?? string.Empty;
                var subTasks = t.GetSubTasks() != null ? string.Join("\n", t.GetSubTasks()) : string.Empty;

                taskTable.AddRow(
                    t.GetTaskTitle(),
                    t.GetTaskPriority(),
                    dueDate,
                    subTasks,
                    t.GetTags(),
                    t.GetStatus()
                );
            }

            AnsiConsole.Write(taskTable);
        }
        public static void editTasks()
        {
            Console.Clear();

        }
    }
}
