﻿using System;
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
        private DateOnly? dueDateTime;
        private List<string>? subTasks;
        private string taskStatus;
        private string taskTags;

        public Tasks(string title, string priority, DateOnly? due, List<string>? subs, string tag)
        {
            taskTitle = title;
            taskPriority = priority;
            dueDateTime = due;
            subTasks = subs.ToList();
            taskTags = tag;
            taskStatus = "Inbox";
        }

        public string GetTaskTitle() { return taskTitle; }
        public string GetTaskPriority() { return taskPriority; }
        public DateOnly? GetDueDate()
        {
            if (dueDateTime == null) { return null; }
            else { return (DateOnly)dueDateTime; }
        }
        public List<string>? GetSubTasks()
        {
            if (subTasks == subTasks.DefaultIfEmpty()) { return null; }
            else { return subTasks; }
        }
        public string GetStatus() { return taskStatus; }
        public string GetTags() { return taskTags; }

    }
}
