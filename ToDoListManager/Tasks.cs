using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListManager
{
    internal class Tasks
    {
        private string taskTitle;
        private string taskPriority;
        private DateTime? dueDateTime;
        private List<string>? subTasks;
        private string taskStatus;
        private string taskTags;

        public Tasks(string title, string priority, DateTime? due, List<string> subs, string tag)
        {
            taskTitle = title;
            taskPriority = priority;
            if (due != null) { dueDateTime = due; }
            if (subs != null) { subTasks = subs.ToList(); }
            taskStatus = "Inbox";
            taskTags = tag;
        }

        public string GetTaskTitle() { return taskTitle; }
        public string GetTaskPriority() { return taskPriority; }
        public DateTime GetDueDate() { return (DateTime)dueDateTime; }
        public List<string> GetSubTasks() { return subTasks; }
        public string GetStatus() { return taskStatus; }
        public string GetTags() { return taskTags; }

    }
}
