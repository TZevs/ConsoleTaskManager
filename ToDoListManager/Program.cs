using Spectre.Console;

namespace ToDoListManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taskTable = new Table();
            taskTable.AddColumn("Title");
            taskTable.AddColumn("Priority");
            taskTable.AddColumn("Due Date");
            taskTable.AddColumn("SubTasks");
            taskTable.AddColumn("Tags");
            taskTable.AddColumn("Status");

            addTask();
        }

        public static void addTask()
        {
            Console.WriteLine("Create Task");
            var taskName = AnsiConsole.Ask<string>("Task Name:");

            var priority = AnsiConsole.Prompt(
                new TextPrompt<string>("Task Priority:")
                    .AddChoices(["High", "Medium", "Low"]));

            // Date
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
                    if (subTask == null) { break; }
                    else { subTasks.Add(subTask); }
                }
            }

            List<string> tags = new List<string>
            {
                "PSP", "Mobile Dev", "Meeting", "Doctor", "Home", "BDay", "None"
            };

            var taskTag = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Task Tag:")
                    .PageSize(7)
                    .AddChoices(tags));

        }
    }
}
